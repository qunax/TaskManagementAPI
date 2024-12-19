using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class Task
	{
        [Key]
        public int ID { get; set; } 
        [Required]
        public string Title { get; set; }  
        public string? Description { get; set; } 
        public DateTime Deadline { get; set; } 
        public bool IsCompleted { get; set; } 

        // Foreign key for the User who owns the task
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User? User { get; set; } 
    }
}

