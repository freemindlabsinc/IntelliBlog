using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

public class SourceType : ObjectType<Source>
{
    protected override void Configure(IObjectTypeDescriptor<Source> descriptor)
    {
        
    }

    //[DataLoader]
    //internal static async Task<Source> GetSourceByIdAsync(
    //    [ID(nameof(Source))] int id,
    //    ISourceByIdDataLoader sourceById,
    //    CancellationToken cancellationToken)

    //    => await sourceById.LoadAsync(id, cancellationToken);

    //[DataLoader]
    //internal static async Task<IEnumerable<Source>> GetSourcesById(
    //    [ID(nameof(Source))] int[] ids,
    //    ISourceByIdDataLoader sourceById,
    //    IEntityRepository<Source> repository,
    //    CancellationToken cancellationToken)

    //    => await sourceById.LoadAsync(ids, cancellationToken);
}
