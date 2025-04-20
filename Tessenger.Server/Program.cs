using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Tessenger.Server.Data;
using Tessenger.Server.Hubs;
using Tessenger.Server.Algorithoms;
using Tessenger.Server.Authentications;
using Tessenger.Server.Users_Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<TessengerServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TessengerServerContext") ?? throw new InvalidOperationException("Connection string 'TessengerServerContext' not found.")), ServiceLifetime.Transient);

builder.Services.AddDbContext<TessengerServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TessengerServerContext") ?? throw new InvalidOperationException("Connection string 'TessengerServerContext' not found.")), ServiceLifetime.Transient);


builder.Services.AddSingleton<IAlgorithoms, Algorithoms>();
builder.Services.AddScoped<Service_AuthFillter>();
builder.Services.AddScoped<Service_AuthFillter_Without_Connect>();
builder.Services.AddScoped<User_Usernames_By_Connection>();


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
app.MapHub<AuthHub>("/hubs/authhub");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => """
    Welcome To Tessenger Api. 
    {
       "AppVersion" : "1.0.0"
    }
    """);

app.Run();
