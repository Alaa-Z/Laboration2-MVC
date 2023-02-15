var builder = WebApplication.CreateBuilder(args);

// Activate MVC pattern 
builder.Services.AddControllersWithViews();

// add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Support for static files
app.UseStaticFiles(); 

// Enable routing
app.UseRouting();

// Enable Session
app.UseSession();

// Specify Routing 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
 
app.Run();
