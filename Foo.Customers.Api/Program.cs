using Foo.Customers.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<CustomersService>();
app.Run();
