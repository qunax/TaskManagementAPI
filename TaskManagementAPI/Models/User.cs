using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }  // Primary key
        public string Username { get; set; }
        public string PasswordHash { get; set; }  // Store hashed password, not plain text!
        public string Email { get; set; }

        // Navigation property to related tasks
        public ICollection<Task>? Tasks { get; set; }
    }
}

