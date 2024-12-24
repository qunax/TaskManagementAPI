using System;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TaskController : ControllerBase
	{
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;



        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
		{
            _taskService = taskService;
            _logger = logger;
		}



        [HttpPost]
        public async Task<IActionResult> CreateTask(int userID, Models.Task task)
        {
            try
            {
                Models.Task newTask = await _taskService.CreateTaskAsync(userID, task);
                return CreatedAtRoute("TaskManagementApi", new { id = newTask.ID }, newTask);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }



        [HttpGet()]
        [Route("{taskId:int}")]
        public async Task<IActionResult> GetTaskById([FromRoute]int taskId)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetTasksAsync(int userId, bool? isCompleted = false)
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync(userId, isCompleted);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{taskId:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute]int taskId,[FromBody] Models.Task newTask)
        {
            try
            {
                var updated = await _taskService.UpdateTaskAsync(taskId, newTask);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }



        [HttpDelete("{taskId:int}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                await _taskService.DeleteTaskAsync(taskId);
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}

