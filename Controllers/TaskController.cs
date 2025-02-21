using Coding_Challenge.Data;
using Coding_Challenge.Models;
using Coding_Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coding_Challenge.Controllers
{
    // Define the route for the TasksController and mark it as an API controller
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // Define a private readonly variable to hold the task service
        private readonly ITaskService _taskService;

        // Constructor that initializes the _taskService variable with the provided task service
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary> Retrieves all tasks </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            // Fetch all tasks using the task service and return an OK response
            return Ok(await _taskService.GetAllTasksAsync());
        }

        /// <summary> Retrieves a task by ID </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            // Fetch the task with the given ID using the task service
            var task = await _taskService.GetTaskByIdAsync(id);
            // If the task is not found, return a NotFound response
            if (task == null) return NotFound();
            // Return an OK response with the found task
            return Ok(task);
        }

        /// <summary> Creates a new task </summary>
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask([FromBody] TaskItem task)
        {
            // Check if the model state is valid; if not, return a BadRequest response
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // Create the new task using the task service
            var createdTask = await _taskService.CreateTaskAsync(task);
            // Return a Created response with the location of the created task
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        /// <summary> Updates an existing task </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            // Check if the model state is valid; if not, return a BadRequest response
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // Update the task using the task service; if not successful, return a NotFound response
            if (!await _taskService.UpdateTaskAsync(id, task)) return NotFound();
            // Return a NoContent response to indicate success
            return NoContent();
        }

        /// <summary> Deletes a task </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            // Delete the task using the task service; if not successful, return a NotFound response
            if (!await _taskService.DeleteTaskAsync(id)) return NotFound();
            // Return a NoContent response to indicate success
            return NoContent();
        }
    }

}
