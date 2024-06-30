using IntelliBlog.Core.Domain.Contributor;
using Xunit;

namespace IntelliBlog.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetContributorRepository();
    var initialName = Guid.NewGuid().ToString();
    var Contributor = new Contributor(initialName);
    await repository.AddAsync(Contributor);

    // delete the item
    await repository.DeleteAsync(Contributor);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Contributor => Contributor.Name == initialName);
  }
}
