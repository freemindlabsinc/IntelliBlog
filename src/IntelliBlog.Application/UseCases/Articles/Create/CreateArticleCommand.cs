﻿
namespace IntelliBlog.Application.UseCases.Articles.Create;
public readonly record struct CreateArticleCommand() : ICommand<Result<BlogId>>;