namespace GraphQL.Posts;

public class PostCommentExtensions : ObjectTypeExtension<PostComment>
{
    protected override void Configure(IObjectTypeDescriptor<PostComment> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).ID();
        descriptor.Ignore(x => x.PostId);
    }
}
