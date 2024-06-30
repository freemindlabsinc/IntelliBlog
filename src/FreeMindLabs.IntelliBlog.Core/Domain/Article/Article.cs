using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using FreeMindLabs.IntelliBlog.Core.Utilities;

namespace FreeMindLabs.IntelliBlog.Core.Domain.Article;

public readonly record struct ArticleId(int Value)
{
    public static ArticleId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<ArticleId, int>.Serialize(Value);
    public static ArticleId? TryParse(string? value) => StrongIdHelper<ArticleId, int>.Deserialize(value);
}

public class Article(string Title, string[] Tags) : EntityBase<ArticleId>, IAggregateRoot
{
    public string Title { get; private set; } = Guard.Against.NullOrEmpty(Title, nameof(Title));
    public string[] Tags { get; private set; } = Tags ?? Array.Empty<string>();

    //public Article SetTags(IEnumerable<string> tags)
    //{ 
    //    this.Tags = tags.Distinct().ToArray();
    //    return this;
    //}

    public static Article CreateNew(string title, string[] tags) => new(Title: title, Tags: tags);
}
