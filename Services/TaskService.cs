using Coding_Challenge.Data;
using Coding_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Coding_Challenge.Services
{
    // Define the TaskService class that implements the ITaskService interface
    public class TaskService : ITaskService
    {
        // Define a private readonly variable to hold the database context
        private readonly TaskDbContext _context;

        // Constructor that initializes the _context variable with the provided database context
        public TaskService(TaskDbContext context)
        {
            _context = context;
        }

        // Method to retrieve all tasks asynchronously
        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            // Fetch all tasks from the database and return as a list
            return await _context.Tasks.ToListAsync();
        }

        // Method to retrieve a specific task by its ID asynchronously
        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            // Find and return the task with the given ID, or null if not found
            return await _context.Tasks.FindAsync(id);
        }

        // Method to create a new task asynchronously
        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            // Add the new task to the database
            _context.Tasks.Add(task);
            // Save changes to the database
            await _context.SaveChangesAsync();
            // Return the created task
            return task;
        }

        // Method to update an existing task asynchronously
        public async Task<bool> UpdateTaskAsync(int id, TaskItem task)
        {
            // Check if the ID of the task to update matches the given ID
            if (id != task.Id) return false;
            // Mark the task as modified in the database context
            _context.Entry(task).State = EntityState.Modified;
            // Save changes to the database
            await _context.SaveChangesAsync();
            // Return true to indicate success
            return true;
        }

        // Method to delete a task by its ID asynchronously
        public async Task<bool> DeleteTaskAsync(int id)
        {
            // Find the task with the given ID
            var task = await _context.Tasks.FindAsync(id);
            // If the task is not found, return false
            if (task == null) return false;
            // Remove the task from the database
            _context.Tasks.Remove(task);
            // Save changes to the database
            await _context.SaveChangesAsync();
            // Return true to indicate success
            return true;
        }
    }

}
