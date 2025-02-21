using System.Collections.Generic;
using Coding_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Coding_Challenge.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
