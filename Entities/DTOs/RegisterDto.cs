﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public String? UserName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public String? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }


        [Required(ErrorMessage = "FullName is required")]
        public String? FullName { get; init; }
    }
}
