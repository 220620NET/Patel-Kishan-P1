using DataAccess;
using Services;
using customExceptions;
using Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ReimbursmentDB")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TicketService>();

builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<TicketController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => " /swagger/index.html ");


app.MapPost("/register", (User UserToRegister, AuthController controller) =>controller.Register(UserToRegister));
app.MapPost("/login", (User UserToLogin, AuthController controller) => controller.Login(UserToLogin));

app.MapGet("/users", (UserController controller) =>controller.GetAllUsers());
app.MapGet("/users/id/{id}", (int id, UserController controller) => controller.GetUserById(id));
app.MapGet("/users/name/{username}", (string username, UserController controller) => controller.GetUserByUsername(username));

app.MapPost("/submit", (ticket newTicket, TicketController controller) => controller.Submit(newTicket));
app.MapPost("/process", (ticket exTicket, TicketController controller) => controller.Process(exTicket));
app.MapGet("/tickets/status/{status}", (string status, TicketController controller) => controller.GetTicketByStatus(status));
app.MapGet("/tickets/author/{authID}", (int authID, TicketController controller) => controller.GetTicketByAuthor(authID));
app.MapGet("/tickets/id/{id}", (int id, TicketController controller) => controller.GetTicketByID(id));
app.MapGet("/tickets", (TicketController controller) => controller.GetAllTickets());


app.Run();
