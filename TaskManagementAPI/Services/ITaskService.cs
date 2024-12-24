using System;
namespace TaskManagementAPI.Services
{
	public interface ITaskService
	{
        public Task<Models.Task> CreateTaskAsync(int userId, Models.Task task);

        public Task<Models.Task?> GetTaskByIdAsync(int taskId);

        public Task<IList<Models.Task>> GetAllTasksAsync(int userId, bool? isCompleted);

        public Task<Models.Task> UpdateTaskAsync(int taskId, Models.Task updatedTask);

        public Task DeleteTaskAsync(int taskId);
    }
}

