﻿namespace IntelliBlog.Application.UseCases.Articles.UpdateTags;
public readonly record struct AddTagsCommand(
    ArticleId Id,
    string[] NewTags) 
    : ICommand<Result>;