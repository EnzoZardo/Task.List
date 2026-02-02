using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Domain.Services.Interfaces;

public interface ITaskServices
{
    public Task<Result<IEnumerable<UserTask>>> FindMany(TaskFilters filters);
    public Task<Result<UserTask>> Find(int id);
    public Task<Result> Update(int id, UserTask value);
    public Task<Result> Delete(IEnumerable<int> ids);
    public Task<Result> Conclude(IEnumerable<int> ids);
    public Task<Result<int>> Add(UserTask value);
}
