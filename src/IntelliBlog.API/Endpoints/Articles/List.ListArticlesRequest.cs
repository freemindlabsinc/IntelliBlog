namespace IntelliBlog.API.Endpoints.Articles;

public readonly record struct ListArticlesRequest( 
    int? Skip,
    int? Take): IQuery<ListArticlesResponse>;
