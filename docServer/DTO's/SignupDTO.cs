using System;
using System.ComponentModel.DataAnnotations;

namespace docServer.DTOs
{
	public class SignupDTO
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

