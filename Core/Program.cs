using Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch =>
{
    app.Use(async (HttpContext context, Func<Task> next) =>
    {
        await context.Response.WriteAsync("Branch Middleware");
    });
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Welcome Shishir to .Net world");

app.Run();
