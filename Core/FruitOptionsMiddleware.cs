using Microsoft.Extensions.Options;

namespace Core
{
    public class FruitOptionsMiddleware
    {
        private RequestDelegate _next;
        private FruitOptions _options;

        public FruitOptionsMiddleware(RequestDelegate next, IOptions<FruitOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/fruits")
            {
                await context.Response.WriteAsync($"{ _options.Name},{ _options.Colour}");
            }
            else
            {
                await _next(context);
            }
        }

    }
}
