using System;
using System.ComponentModel.DataAnnotations;

namespace docServer.DTOs
{
	public class UserDTO
	{
        public long Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Property to store user roles as a string for DTO
        public string UserRole { get; set; }
    }
}

