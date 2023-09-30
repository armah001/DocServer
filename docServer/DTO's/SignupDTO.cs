using System;
using System.ComponentModel.DataAnnotations;

namespace docServer.DTOs
{
	public class SignupDTO
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

