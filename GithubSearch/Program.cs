using GithubSearch.Core.Services.Bookmark;
using GithubSearch.Core.Services.Github;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession();


builder.Services.AddScoped<IGithubService, GithubService>();
builder.Services.AddSingleton<IBookmarkService, BookmarkService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.Use(async (context, next) =>
{
    var userId = context.Request.Cookies["x-user-id"];

    if (string.IsNullOrWhiteSpace(userId))
    {
        userId = Guid.NewGuid().ToString();
        context.Response.Cookies.Append("x-user-id", userId, new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });
    }

    context.User = new GenericPrincipal(new GenericIdentity(userId), new string[0]);

    await next.Invoke();
});

app.MapControllers();

app.Run();
