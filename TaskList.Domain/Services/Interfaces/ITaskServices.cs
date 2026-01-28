using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Domain.Services.Interfaces;

public interface ITaskServices
{
    public Task<Result<IEnumerable<UserTask>>> FindAll();
    public Task<Result<IEnumerable<UserTask>>> Find(int id);
    public Task<Result> Edit(int id, UserTask value);
    public Task<Result> Remove(int id);
    public Task<Result> Conclude(int id);
}
