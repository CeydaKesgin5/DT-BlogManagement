namespace Services.Contracts
{
    public interface IService
    {
        IBlogService BlogService { get;}
        ICategoryService CategoryService { get; }

        IAuthService AuthService { get; }

        ICommentService CommentService { get; }

    }
}
