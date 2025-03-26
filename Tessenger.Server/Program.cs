using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tessenger.Server.Data;

using Tessenger.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TessengerServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TessengerServerContext") ?? throw new InvalidOperationException("Connection string 'TessengerServerContext' not found.")));

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

// Map Hubs
app.MapHub<ChatHub>("/hubs/chathub");
app.MapHub<CallHub>("/hubs/callhub");
app.MapHub<FriendHub>("/hubs/friendhub");
app.MapHub<GroupHub>("/hubs/grouphub");
app.MapHub<NotificationHub>("/hubs/notificationhub");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
