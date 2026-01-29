using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Domain.Services.Interfaces;

public interface ITaskServices
{
    public Task<Result<IEnumerable<UserTask>>> FindAll();
    public Task<Result<UserTask>> Find(int id);
    public Task<Result> Update(int id, UserTask value);
    public Task<Result> Delete(int id);
    public Task<Result> Conclude(int id);
    public Task<Result<int>> Add(UserTask value);
}
