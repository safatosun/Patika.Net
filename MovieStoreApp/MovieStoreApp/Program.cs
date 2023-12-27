using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.Application.ActorOperations.Queries.GetActors;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateToken;
using MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreApp.Application.CustomerOperations.Commands.RefreshToken;
using MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApp.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreApp.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreApp.Application.MovieOperations.Queries.GetMovies;
using MovieStoreApp.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderByCustomerId;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderById;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Middlewares;
using MovieStoreApp.Services;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetSection("JwtSettings")["Issuer"],
                    ValidAudience = builder.Configuration.GetSection("JwtSettings")["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings")["SecurityKey"])),
                    ClockSkew = TimeSpan.Zero

                });

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<CreateMovieCommandValidator>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieStoreDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IMovieStoreDbContext,MovieStoreDbContext>();
builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();

builder.Services.AddScoped<CreateMovieCommand>();
builder.Services.AddScoped<UpdateMovieCommand>();
builder.Services.AddScoped<DeleteMovieCommand>();
builder.Services.AddScoped<GetMoviesQuery>();

builder.Services.AddScoped<DeleteCustomerCommand>();
builder.Services.AddScoped<CreateCustomerCommand>();

builder.Services.AddScoped<CreateActorCommand>();
builder.Services.AddScoped<UpdateActorCommand>();
builder.Services.AddScoped<DeleteActorCommand>();
builder.Services.AddScoped<GetActorsQuery>();

builder.Services.AddScoped<CreateDirectorCommand>();
builder.Services.AddScoped<UpdateDirectorCommand>();
builder.Services.AddScoped<DeleteDirectorCommand>();
builder.Services.AddScoped<GetDirectorsQuery>();

builder.Services.AddScoped<GetOrderByIdQuery>();
builder.Services.AddScoped<CreateOrderCommand>();
builder.Services.AddScoped<GetOrderByCustomerIdQuery>();

builder.Services.AddScoped<CreateTokenCommand>();
builder.Services.AddScoped<RefreshTokenCommand>();

var app = builder.Build();

app.UseCustomExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieStoreDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
