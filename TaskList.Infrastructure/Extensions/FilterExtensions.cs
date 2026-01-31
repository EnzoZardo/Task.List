using TaskList.Domain.Entities.Tasks;

namespace TaskList.Infrastructure.Extensions;

public static class FilterExtensions
{
    public static IQueryable<UserTask> ApplyFilters(
        this IQueryable<UserTask> query,
        TaskFilters filters)
    {
        if (filters.StatusDone is not null)
        {
            query = query.Where(t => t.Done == filters.StatusDone);
        }

        if (filters.CreatedUntilDaysBehind is not null)
        {
            var date = DateTime.Now
                .AddDays(-(int)filters.CreatedUntilDaysBehind)
                .Date;

            return query.Where(t => t.CreatedDateTime.Date >= date);
        }

        if (filters.SpecificCreatedDateTime is not null)
        {
            var date = (DateTime) filters.SpecificCreatedDateTime;
            return query.Where(t => t.CreatedDateTime.Date == date.Date);
        }

        return query;
    }
}
