﻿namespace Blogging.Application.UseCases.Sources.Delete;

public readonly record struct DeleteSourceCommand(SourceId SourceId) : ICommand<Result>;
