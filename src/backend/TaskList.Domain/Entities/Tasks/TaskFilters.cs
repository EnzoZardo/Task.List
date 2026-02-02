namespace TaskList.Domain.Entities.Tasks;

public sealed record TaskFilters
{
    public int? CreatedUntilDaysBehind { get; set; } = null;
    public bool? StatusDone { get; set; } = null;
    public DateTime? SpecificReleaseDateTime { get; set; } = null;
}
