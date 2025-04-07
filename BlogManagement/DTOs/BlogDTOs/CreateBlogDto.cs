namespace BlogManagement.DTOs.BlogDTOs
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string? Image { get; set; }

        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
