﻿namespace API.Endpoints.Blogs;

public readonly record struct BlogResult(
    int Id,
    string Name,
    string Description,
    string Author,
    DateTime CreatedAt,
    DateTime UpdatedAt);
