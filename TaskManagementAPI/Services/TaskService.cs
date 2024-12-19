using System;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;

namespace TaskManagementAPI.Services
{
	public class TaskService : ITaskService
	{
        private readonly TaskManagementDataContext _context;

        public TaskService(TaskManagementDataContext context)
        {
            _context = context;
        }


        public async Task<Models.Task> CreateTaskAsync(int userId, Models.Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            task.UserID = userId;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }
        


        public async Task<Models.Task?> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.ID == taskId);
        }



        public async Task<IList<Models.Task>> GetAllTasksAsync(int userId, bool? isCompleted = false)
        {
            var query = _context.Tasks.Where(t => t.UserID == userId);

            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }
            return await query.ToListAsync();
        }
    }
}

