using Ardalis.Result;
using Ardalis.SharedKernel;

namespace IntelliBlog.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
