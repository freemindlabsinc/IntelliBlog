﻿namespace Application.Features.Sources.Commands.Delete;

public readonly record struct DeleteSourceCommand(int SourceId) : ICommand<Result>
{
    internal class DeleteSourceCommandValidator : AbstractValidator<DeleteSourceCommand>
    {
        public DeleteSourceCommandValidator()
        {
            RuleFor(x => x.SourceId).NotEmpty();
        }
    }
}