using TaskList.Domain.Entities.Tasks;

namespace TaskList.Presentation.Extensions;

public static class FilterExtensions
{
    public static IQueryable<UserTask> ApplyFilters(
        this IQueryable<UserTask> query,
        TaskFilters filters)
    {
        if (filters.StatusDone is not null)
            query = query.Where(t => t.Done == filters.StatusDone);

        if (filters.CreatedUntilDaysBehind is not null)
        {
            var date = DateTime.Now.AddDays(-(int)filters.CreatedUntilDaysBehind);
            query = query.Where(t => t.CreatedDateTime >= date);
        }

        if (filters.SpecificCreatedDateTime is not null)
            query = query.Where(t => t.CreatedDateTime == filters.SpecificCreatedDateTime);

        return query;
    }
}
