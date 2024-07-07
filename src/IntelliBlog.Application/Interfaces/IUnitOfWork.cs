namespace IntelliBlog.Application.Interfaces;

// Inspired by
//  https://medium.com/@josiahmahachi/how-to-use-iunitofwork-single-responsibility-principle-2821398addee
//  https://steven-giesel.com/blogPost/ae55581a-9722-4735-8d0e-bfcfe4f6ad5a
public interface IUnitOfWork
{
    public Task<int> CompleteAsync(CancellationToken cancellationToken = default);

    public IRepository<TAGGREGATE> GetRepository<TAGGREGATE>()
        where TAGGREGATE : class, IAggregateRoot;
}
