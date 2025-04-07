using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogManagement.Models
{
    public class User:IdentityUser
    {
        
        [Required(ErrorMessage = "FullName is required. ")]
        public string FullName { get; set; }
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
