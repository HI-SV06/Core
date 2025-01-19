using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});

var app = builder.Build();


//Creating a web service/ web endpoint


//Getting the product based on id from database
const string BASEURL = "/api/products";

app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, DataContext data) =>
{
    // To know more what is RoutValue check end of this page
    string id = context.Request.RouteValues["id"] as string;
    if(id != null)
    {
        Product product = data.Products.Find(long.Parse(id));
        if (product == null)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(product));
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
});


// Getting all products from product table.
app.MapGet($"{BASEURL}", async (HttpContext context, DataContext data) =>
{
    
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products));
});






var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);
/*
 * app.Services.CreateScope() => Creates a new scope for dependency injection (DI).
 * .ServiceProvider => the ServiceProvider retrieves a DataContext instance from the DI container.
 * .GetRequiredService<DataContext>() => Retrieves an instance of DataContext from the service provider.
 * SeedData.SeedDatabase(context) => Calls the SeedDatabase method in the SeedData class and passes the DataContext instance as a parameter.
 * */

app.MapGet("/", () => "Hello World!");

app.Run();
















/*RouteValues:- A dictionary-like property (IDictionary<string, object?>) available in the HttpRequest object.
 * if the route pattern is /products/{id} and the URL /products/42 is requested, 
 * the RouteValues dictionary will contain { "id", "42" }.
 * 
 */