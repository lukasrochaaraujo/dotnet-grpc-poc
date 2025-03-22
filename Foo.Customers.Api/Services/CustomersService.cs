using Grpc.Core;
using Bogus;

namespace Foo.Customers.Api.Services;

public class CustomersService : Api.CustomersService.CustomersServiceBase
{
    private readonly ILogger<CustomersService> _logger;

    public CustomersService(ILogger<CustomersService> logger)
    {
        _logger = logger;
    }

    public override Task<CustomerReply> GetAll(CustomerRequest request, ServerCallContext context)
    {
        var reply = new CustomerReply();

        var customers = new Faker<Customer>()
            .RuleFor(x => x.Id, f => f.Random.Int(1, 100_000))
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .Generate(50)
            .ToArray();

        reply.Customers.AddRange(customers);

        return Task.FromResult(reply);
    }
}
