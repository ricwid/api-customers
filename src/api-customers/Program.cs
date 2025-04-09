using api_customers;

var customers = new List<Customer>
{
    new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Age = 30 },
    new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Age = 25 },
    new Customer { Id = 3, Name = "Sam Wilson", Email = "sam.wilson@example.com", Age = 35 }
};

var customerEngagements = new List<CustomerEngagements>
{
    new CustomerEngagements {Id = 1, Name = "John Doe", Engagements = ["Bilförsäkring", "Hemförsäkring"]}
};

var customerEngagements2 = new List<CustomerEngagements2>
{
    new CustomerEngagements2 {Id = 10, Name = "John Doe",  Email = "John.Doe@hotmail.com", Engagements = ["Bilförsäkring", "Hemförsäkring"] }
};


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet("/customers", () => Results.Ok(customers))
    .WithName("GetAllCustomers")
    .WithTags("Customers");

app.MapGet("/customers/{id:int}", (int id) =>
    {
        var customer = customers.FirstOrDefault(c => c.Id == id);
        if (customer is null)
            return Results.NotFound(new { Message = $"Customer with ID {id} not found" });
        return Results.Ok(customer);
    })
    .WithName("GetCustomerById")
    .WithTags("Customers");

app.MapGet("/customerEngagements", () => { return Results.Ok(customerEngagements.OrderBy(e => e.Id)); })
    .WithName("GetAllCustomerEngagements")
    .WithTags("Customers")
    .Produces<List<CustomerEngagements>>(200);

app.MapPost("/customers", (Customer newCustomer) =>
    {
        newCustomer.Id = customers.Count > 0 ? customers.Max(c => c.Id) + 1 : 1;
        customers.Add(newCustomer);
        return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
    })
    .WithName("CreateCustomer")
    .WithTags("Customers");

app.MapPut("/customers/{id:int}", (int id, Customer updatedCustomer) =>
    {
        var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
        if (existingCustomer is null)
            return Results.NotFound(new { Message = $"Customer with ID {id} not found" });

        existingCustomer.Name = updatedCustomer.Name;
        existingCustomer.Email = updatedCustomer.Email;
        existingCustomer.Age = updatedCustomer.Age;

        return Results.Ok(existingCustomer);
    })
    .WithName("UpdateCustomer")
    .WithTags("Customers");

app.MapDelete("/customers/{id:int}", (int id) =>
    {
        var customer = customers.FirstOrDefault(c => c.Id == id);
        if (customer is null)
            return Results.NotFound(new { Message = $"Customer with ID {id} not found" });

        customers.Remove(customer);
        return Results.NoContent();
    })
    .WithName("DeleteCustomer")
    .WithTags("Customers");

app.MapGet("/ping", () => Results.Ok("pong"))
    .WithName("Ping")
    .WithTags("Customers");

app.Run();