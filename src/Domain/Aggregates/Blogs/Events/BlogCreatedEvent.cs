﻿namespace Blogging.Domain.Aggregates.Blogs.Events;
public readonly record struct BlogCreatedEvent(Blog Sender) : INotification;
