namespace TaskList.Domain.Entities.Tasks;

public class UserTask
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedDateTime { get; set; }
    public DateTime ConslusionDateTime { get; set; }
    public bool Done { get; set; } = false;

    public static UserTask Create(string title, string description)
        => new()
        {
            Title = title,
            Description = description,
            CreatedDateTime = DateTime.Now,
        };
}
