using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
	public class TaskManagementDataContext : DbContext
	{
		public TaskManagementDataContext(DbContextOptions<TaskManagementDataContext> options) : base(options)
		{
		}



		public DbSet<User> Users { get; set; }
		public DbSet<Models.Task> Tasks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<Models.Task>().ToTable("Tasks");
            base.OnModelCreating(modelBuilder);
        }
    }
}

