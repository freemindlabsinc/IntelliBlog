using Ardalis.Result;
using Ardalis.SharedKernel;
using IntelliBlog.Application.UseCases.Contributors;

namespace IntelliBlog.Application.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
