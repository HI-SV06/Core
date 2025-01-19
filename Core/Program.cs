using Core;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(Options =>
{
    Options.Name = "Watermelon";
});

var app = builder.Build();

//app.MapGet("/fruits", async (HttpContext context, IOptions<FruitOptions> FruitOptions) =>
//{
//    FruitOptions options = FruitOptions.Value;
//    await context.Response.WriteAsync(options.Name + " " + options.Colour);
//});

app.UseMiddleware<Middleware>();
app.UseMiddleware<FruitOptionsMiddleware>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Welcome Shishir to .Net world");

app.Run();
