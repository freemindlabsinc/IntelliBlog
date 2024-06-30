using Ardalis.Result;
using Ardalis.SharedKernel;
using IntelliBlog.Application.UseCases.Contributors;

namespace IntelliBlog.Application.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
