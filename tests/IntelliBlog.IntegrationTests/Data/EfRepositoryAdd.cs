using Xunit;
using IntelliBlog.Domain.Contributor;
using IntelliBlog.Domain.Article;

namespace IntelliBlog.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
    [Fact]
    public async Task AddsContributorAndSetsId()
    {
        var testContributorName = "testContributor";
        var testContributorStatus = ContributorStatus.NotSet;
        var repository = GetContributorRepository();
        var Contributor = new Contributor(testContributorName);

        await repository.AddAsync(Contributor);

        var newContributor = (await repository.ListAsync())
                        .FirstOrDefault();

        Assert.Equal(testContributorName, newContributor?.Name);
        Assert.Equal(testContributorStatus, newContributor?.Status);
        Assert.True(newContributor?.Id > 0);
    }

    [Fact]
    public async Task AddsArticleAndSetsId()
    {
        var testArticleTitle = "testArticle";
        var testArticleTags = new string[] { "testTag1", "testTag2" };
        var repository = GetArticlesRepository();
        var Article = new Article(testArticleTitle, testArticleTags);

        await repository.AddAsync(Article);

        var newArticle = (await repository.ListAsync())
                        .FirstOrDefault();

        Assert.Equal(testArticleTitle, newArticle?.Title);
        Assert.Equal(testArticleTags, newArticle?.Tags);
        Assert.True(newArticle?.Id.Value > 0);
    }
}
