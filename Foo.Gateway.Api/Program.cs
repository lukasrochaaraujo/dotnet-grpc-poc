using Foo.Gateway.Api.Services;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet("v1/customers", async () => 
{
    using var channel = GrpcChannel.ForAddress("http://localhost:5050");
    var client = new CustomersService.CustomersServiceClient(channel);
    var reply = await client.GetAllAsync(new CustomerRequest());
    return reply;
});

app.Run();
