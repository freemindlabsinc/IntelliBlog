﻿
namespace IntelliBlog.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById(CustomWebApplicationFactory<Program> factory) 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public Task ReturnsSeedContributorGivenId1()
  {
        throw new Exception("Not implemented");
        //var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));
        //
        //Assert.Equal(1, result.Id);
        //Assert.Equal(SeedData.Contributor1.Name, result.Name);        
  }

  [Fact]
  public Task ReturnsNotFoundGivenId1000()
  {
        throw new Exception("Not implemented");
        //string route = GetContributorByIdRequest.BuildRoute(1000);
        //_ = await _client.GetAndEnsureNotFoundAsync(route);
    }
}
