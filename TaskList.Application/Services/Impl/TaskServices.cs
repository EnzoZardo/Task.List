using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Domain.Services.Interfaces;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Application.Services.Impl;

public class TaskServices(ITaskRepository repository) : ITaskServices
{
    public async Task<Result> Conclude(IEnumerable<int> ids)
        => await repository.ConcludeTasksByIdAsync(ids);

    public async Task<Result> Update(int id, UserTask value)
        => await repository.UpdateTaskByIdAsync(id, value);

    public async Task<Result<UserTask>> Find(int id)
        => await repository.FindByIdAsync(id);

    public async Task<Result<IEnumerable<UserTask>>> FindMany(TaskFilters filters)
        => await repository.FindManyAsync(filters);

    public async Task<Result> Delete(IEnumerable<int> ids)
        => await repository.DeleteTasksByIdAsync(ids);

    public async Task<Result<int>> Add(UserTask value)
        => await repository.AddAsync(value);
}
