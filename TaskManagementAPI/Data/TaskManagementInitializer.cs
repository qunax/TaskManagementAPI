using TaskManagementAPI.Models;
using Task = TaskManagementAPI.Models.Task;



namespace TaskManagementAPI.Data
{
    public static class TaskManagementInitializer
    {
        public static void Initialize(TaskManagementDataContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Username = "john_doe",
                    PasswordHash = "hashedpassword1", // Replace with actual hash if hashing is implemented
                    Email = "john.doe@example.com",
                    Tasks = new List<Task>
                    {
                        new Task
                        {
                            Title = "Complete project documentation",
                            Description = "Write detailed API documentation for the task management system.",
                            Deadline = DateTime.Now.AddDays(5),
                            IsCompleted = false
                        },
                        new Task
                        {
                            Title = "Team meeting",
                            Description = "Discuss project updates and next steps.",
                            Deadline = DateTime.Now.AddDays(2),
                            IsCompleted = false
                        }
                    }
                },
                new User
                {
                    Username = "jane_smith",
                    PasswordHash = "hashedpassword2",
                    Email = "jane.smith@example.com",
                    Tasks = new List<Task>
                    {
                        new Task
                        {
                            Title = "Prepare presentation",
                            Description = "Create slides for the client meeting.",
                            Deadline = DateTime.Now.AddDays(3),
                            IsCompleted = false
                        },
                        new Task
                        {
                            Title = "Code review",
                            Description = "Review code submissions from team members.",
                            Deadline = DateTime.Now.AddDays(1),
                            IsCompleted = true
                        }
                    }
                }
            };

            users.ForEach(user => context.Users.Add(user));

            context.SaveChanges();
        }
    }
}

