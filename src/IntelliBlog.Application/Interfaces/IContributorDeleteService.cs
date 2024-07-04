using Ardalis.Result;

namespace IntelliBlog.Application.Interfaces;

public interface IContributorDeleteService
{
    public Task<Result> DeleteContributor(int contributorId);    
}
