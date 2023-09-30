using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace docServer.Models
{
    public class User
    {
        [Key]
        public long Id;

        [Required]
        public String FullName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        //prevents the password property from being serialized and returned in api response
        [JsonIgnore]
        [Required]
        [MinLength(6)]
        public String Password { get; set; }

        // Property to store user roles from role class for type safety/code readability 
        public Role UserRole { get; set; }

        public User(long id, string fullName, string email, string password, Role userRole)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            UserRole = userRole;
        }
    }
}

