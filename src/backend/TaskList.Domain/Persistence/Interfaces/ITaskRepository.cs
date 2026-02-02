using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Domain.Persistence.Interfaces;

public interface ITaskRepository
{
    public Task<Result<IEnumerable<UserTask>>> FindManyAsync(TaskFilters filters);
    public Task<Result<UserTask>> FindByIdAsync(int id);
    public Task<Result> UpdateTaskByIdAsync(int id, UserTask value);
    public Task<Result> DeleteTasksByIdAsync(IEnumerable<int> ids);
    public Task<Result> ConcludeTasksByIdAsync(IEnumerable<int> ids);
    public Task<Result<int>> AddAsync(UserTask value);
}
