using Ardalis.Result;
using Ardalis.SharedKernel;

namespace IntelliBlog.Application.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
