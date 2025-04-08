namespace api_customers;

public record CustomerEngagements
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required List<string> Engagements { get; set; } = new List<string>();
}

public record CustomerEngagements2
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required List<string> Engagements { get; set; } = new List<string>();
}