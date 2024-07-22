using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Sources;

public class SourceNode : ObjectTypeExtension<Source>
{
    protected override void Configure(IObjectTypeDescriptor<Source> descriptor)
    {
        base.Configure(descriptor);

        descriptor.BindFieldsExplicitly();
        //descriptor.Field("BogusField")
        //          .Resolve(() => "Source-BogusFieldValue");
    }

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Source>> GetSourcesByIdAsync(
        IReadOnlyList<int> ids,
        IEntityRepository<Source> repository,
        CancellationToken cancellationToken)

    => await repository.Source
        .Where(a => ids.Contains(a.Id))
        .ToDictionaryAsync(x => x.Id, cancellationToken);
}
