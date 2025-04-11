using Entities.Models;

namespace BlogManagement.Models
{
    public class BlogListViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; } = Enumerable.Empty<Blog>();
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}
