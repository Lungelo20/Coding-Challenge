using System.ComponentModel.DataAnnotations;

namespace Coding_Challenge.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
        public DateTime GetDueDate()
        {
            return DueDate.Date; // This removes the time part
        }

        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        [Required]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(100, ErrorMessage = "Assignee name cannot exceed 100 characters.")]
        public string? AssignedTo { get; set; }

        public void MarkComplete()
        {
            Status = TaskStatus.Completed;
            CompletionDate = DateTime.UtcNow;
        }

        public void UpdateTask(string title, string description, DateTime dueDate, TaskPriority priority, TaskStatus status, string assignedTo)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
            AssignedTo = assignedTo;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
