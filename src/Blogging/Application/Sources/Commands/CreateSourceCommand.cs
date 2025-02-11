﻿namespace Blogging.Application.Sources.Commands;
public record CreateSourceCommand(
    int BlogId,
    string Name,
    string? Url = default,
    string? Description = default,
    string[]? Tags = default) : ICommand<Result<int>>
{
    internal class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
    {
        public CreateSourceCommandValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty();

            // TODO review length            
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
