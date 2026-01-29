using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Infrastructure.Persistence.Impl;

public class TaskRepository : ITaskRepository
{
    private List<UserTask> UserTasks = [];

    public async Task<Result<int>> AddAsync(UserTask value)
    {
        int id = UserTasks.Count + 1;
        value.Id = id;
        UserTasks.Add(value);
        return id;
    }

    public async Task<Result> ConcludeTaskByIdAsync(int id)
    { 
        var task = UserTasks.First(x => x.Id == id);

        if (task is null)
        {
            return Result.Fail($"Não foi encontrada task com o Id {id}");
        }

        task.Done = true;
        return Result.Ok();
    }

    public async Task<Result> DeleteTaskByIdAsync(int id)
    {
        UserTasks = [.. UserTasks.Where(x => x.Id != id)];
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<UserTask>>> FindAsync()
        => Result<IEnumerable<UserTask>>.Ok(UserTasks);

    public async Task<Result<UserTask>> FindByIdAsync(int id)
    {
        var task = UserTasks.First(x => x.Id == id);
        if (task is null)
        {
            return Result<UserTask>.Fail($"Não foi encontrada task com o Id {id}");
        }
        return Result<UserTask>.Ok(task);
    }

    public async Task<Result> UpdateTaskByIdAsync(int id, UserTask value)
    {
        UserTasks = [.. UserTasks.Where(x => x.Id != id)];
        UserTasks.Add(value);
        return Result.Ok();
    }
}
