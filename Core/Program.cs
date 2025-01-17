using Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
 * Output ->
 * a. if url is localhost:3000/short then if condition will work and Request short-circuited display on browser.
 * b. if url is differ from above then else condition run & bcoz of await next(), the next middleware component get's called.
 */

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/short")
    {
        await context.Response.WriteAsync("Request short-circuited");
    }
    else
    {
        await next();
    }
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Welcome Shishir to .Net world");

app.Run();
