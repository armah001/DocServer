using System;
using System.ComponentModel.DataAnnotations;

namespace docServer.DTOs
{
	public class LoginDTO
	{
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

