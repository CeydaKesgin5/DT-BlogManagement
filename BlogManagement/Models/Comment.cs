﻿using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(300)]
        public string CommentText { get; set; }

        public string UserId { get; set; }      
        public User User { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
   
    }
}
