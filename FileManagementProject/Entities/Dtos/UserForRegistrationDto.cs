﻿
using FileManagementProject.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace FileManagementProject.Entities.Dtos
{
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }


        public ICollection<string>? Roles { get; init; }
    }
}
