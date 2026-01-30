using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Tasks;

namespace TaskList.Infrastructure.Context;

public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
{
    public DbSet<UserTask> Tasks { get; set; }
}
