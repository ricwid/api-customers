namespace api_customers;

public record Customer(int Id, string Name, string Email, int Age)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}
