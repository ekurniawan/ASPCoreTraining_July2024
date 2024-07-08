using ASPCoreTraining.Web.Middleware;
using ASPCoreTraining.Web.Services;

var builder = WebApplication.CreateBuilder(args);

//cara untuk menginject object
//builder.Services.AddSingleton<IGreeter, Greeting>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseMiddleware<LoggingMiddleware>();

//app.MapGet("/", (IGreeter greeter) => greeter.GetMessageOfTheDay());
app.MapControllerRoute(
    name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();