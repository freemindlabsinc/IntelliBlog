﻿namespace Blogging.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public Task ReturnsTwoContributors()
  {
        throw new Exception("Not implemented");
        //var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");
        //
        //Assert.Equal(2, result.Contributors.Count);
        //Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor1.Name);
        //Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor2.Name);
    }
}
