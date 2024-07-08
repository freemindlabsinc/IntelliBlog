namespace API.Endpoints.Articles.List;

public readonly record struct ListArticlesRequest(
    int? Skip,
    int? Take) : IQuery<ListArticlesResponse>;
