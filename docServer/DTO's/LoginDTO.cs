using System;
using System.ComponentModel.DataAnnotations;

namespace docServer.DTOs
{
	public class LoginDTO
	{
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password limited to ...", MinimumLength = 8)]
        public string Password { get; set; }
    }
}

