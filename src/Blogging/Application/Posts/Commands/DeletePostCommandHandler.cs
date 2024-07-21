﻿namespace Blogging.Application.Posts.Commands;

public class DeletePostCommandHandler(IRepository<Post> _repository) : ICommandHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound("Post not found");
        }

        await _repository.DeleteAsync(Post);

        return Result.Success();
    }
}