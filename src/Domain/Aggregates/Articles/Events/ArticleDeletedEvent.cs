﻿namespace Blogging.Domain.Aggregates.Articles.Events;

public readonly record struct ArticleDeletedEvent(Article Sender) : INotification;