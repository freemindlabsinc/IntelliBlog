namespace Blogging.Application.Interfaces;

// Inspired by
//  https://medium.com/@josiahmahachi/how-to-use-iunitofwork-single-responsibility-principle-2821398addee
//  https://steven-giesel.com/blogPost/ae55581a-9722-4735-8d0e-bfcfe4f6ad5a
public interface IUnitOfWork
{
    public void Setup(Func<Task<object>> work);
    public Task<object> CompleteAsync(CancellationToken cancellationToken = default);    
}
