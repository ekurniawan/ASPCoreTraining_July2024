namespace ASPCoreTraining.Web.Middleware
{
    public class LoggingMiddleware
    {
        private RequestDelegate nextDelegate;
        public LoggingMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("==Before Run==");
            if (context.Request.Path.Value.Contains("home"))
            {
                await context.Response.WriteAsync("Response generated from middleware");
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
            Console.WriteLine("==After Run==");
        }
    }
}
