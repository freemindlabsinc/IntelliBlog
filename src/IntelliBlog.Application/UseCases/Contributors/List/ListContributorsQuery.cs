using Ardalis.Result;
using Ardalis.SharedKernel;
using IntelliBlog.Application.UseCases.Contributors;

namespace IntelliBlog.Application.UseCases.Contributors.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
