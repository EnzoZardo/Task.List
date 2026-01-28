using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Domain.Persistence.Interfaces;

public interface ITaskRepository
{
    public Task<Result<IEnumerable<UserTask>>> FindAsync();
    public Task<Result<UserTask>> FindByIdAsync(int id);
    public Task<Result> DeleteTaskByIdAsync(int id);
    public Task<Result> UpdateTaskByIdAsync(int id, UserTask value);
    public Task<Result> ConcludeTaskByIdAsync(int id);
}
