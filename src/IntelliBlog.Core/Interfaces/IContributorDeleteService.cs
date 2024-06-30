using Ardalis.Result;

namespace IntelliBlog.Core.Interfaces;

public interface IContributorDeleteService
{
    public Task<Result> DeleteContributor(int contributorId);    
}
