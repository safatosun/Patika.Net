using PatikaRestfulApi.Controllers.Attributes;
using PatikaRestfulApi.Extensions;
using PatikaRestfulApi.Repositories.Contracts;
using PatikaRestfulApi.Repositories.EFCore;
using PatikaRestfulApi.Services;
using PatikaRestfulApi.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositoryDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<FakeUserAttribute>();



var app = builder.Build();

app.ConfigureExceptionHandler();
app.UseLoggingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
    dbContext.Database.EnsureCreated(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
