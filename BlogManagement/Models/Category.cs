using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "CategoryName is required. ")]

        public string CategoryName { get; set; }

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
