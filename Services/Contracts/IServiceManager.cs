namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBlogService BlogService { get;}
        ICategoryService CategoryService { get; }

        IAuthService AuthService { get; }

        ICommentService CommentService { get; }

    }
}
