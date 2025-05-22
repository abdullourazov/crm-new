namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string? GroupName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
