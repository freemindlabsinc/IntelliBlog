﻿namespace Blogging.Application.Sources.Commands;

public record UpdateSourceCommand(
    int SourceId,
    string Name,
    string? Url = default,
    string? Description = default) : ICommand<Result>
{
    internal class UpdateSourceCommandValidator : AbstractValidator<UpdateSourceCommand>
    {
        public UpdateSourceCommandValidator()
        {
            RuleFor(x => x.SourceId).NotEmpty();
            // TODO review length
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
