namespace api_customers;

public record Customer
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required int Age { get; set; }
}
