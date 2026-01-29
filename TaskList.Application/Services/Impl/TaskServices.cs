using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Domain.Services.Interfaces;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Application.Services.Impl;

public class TaskServices(ITaskRepository repository) : ITaskServices
{
    public async Task<Result> Conclude(int id)
        => await repository.ConcludeTaskByIdAsync(id);

    public async Task<Result> Update(int id, UserTask value)
        => await repository.UpdateTaskByIdAsync(id, value);

    public async Task<Result<UserTask>> Find(int id)
        => await repository.FindByIdAsync(id);

    public async Task<Result<IEnumerable<UserTask>>> FindAll()
        => await repository.FindAsync();

    public async Task<Result> Delete(int id)
        => await repository.DeleteTaskByIdAsync(id);

    public async Task<Result<int>> Add(UserTask value)
        => await repository.AddAsync(value);
}
