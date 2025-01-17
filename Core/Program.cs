var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (Context, next) =>
{
    if (Context.Request.Method == HttpMethods.Get && Context.Request.Query["Custom"] == "True")
    {
        Context.Response.ContentType = "text/plain";
        await Context.Response.WriteAsync("Custom Middleware \n");
    }

    await next();
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Welcome Shishir to .Net world");

app.Run();
