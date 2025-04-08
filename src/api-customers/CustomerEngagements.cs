public record CustomerEngagements(int Id, string Name, List<string> Engagements)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Engagements { get; set; } = new List<string>();
}

public record CustomerEngagements2(int Id, string Name, string Email, List<string> Engagements)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Engagements { get; set; } = new List<string>();
}