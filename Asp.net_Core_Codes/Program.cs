using Asp.net_Core_Codes.Asp.net_Core_Codes_Database;
using Asp.net_Core_Codes.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//To use our context file we neeed to do this

builder.Services.AddDbContext<BookNestContext>(options => options.UseSqlServer("Data Source=DESKTOP-V1I2RVP\\SQLEXPRESS; Database=BookNest ;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;"));
;
//Here we rae directly using DI , because DI is inbuilt in asp.netcore
//First we passed service and then implementation
builder.Services.AddScoped<BookRepository , BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//after this mcs will addedd to an application , we can use model , views & controllers and lots of other features 
//builder.Services.AddMvc();

//This is for when we only need controllers & models
//builder.Services.AddControllers();

//When we only want use controllers with views 
//builder.Services.AddControllersWithViews();


app.UseRouting();

//For default controller route :- to map route our default home controller and default index method 
app.UseEndpoints(endpoints => endpoints.MapControllerRoute
(
    name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}")
);

//For creating custom middleware 
//We are using async because asp.net core works on async programming
//app.Use( async (context, next) =>
//{
//    await context.Response.WriteAsync("First Custom Middleware");
/*
 For calling next middleware and using await because of async 
 await next();
 */

//});




app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
