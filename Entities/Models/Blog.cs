using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required. ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required. ")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Author is required. ")]
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Image { get; set; }

        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
        public string UserId {  get; set; }
        public User? User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
