using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;

namespace docServer.Models
{
    

    public class User
    {
        public User()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public User(int id, string fullName, string email, string password, Role userRole)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;

            //PasswordHash = HashPassword(plainTextPassword);

            UserRole = userRole;
        }

        //private string HashPassword(string plainTextPassword)
        //{
        //    // Adjust the work factor (12 is a reasonable starting point)
        //    return BCrypt.Net.BCrypt.HashPassword(plainTextPassword, 12);
        //}


    }
}

