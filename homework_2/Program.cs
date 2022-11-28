using homework_2.Database;
using homework_2.Services.Friends;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add db services
string? friendDbConnectString = builder.Configuration.GetConnectionString("FriendDb");
builder.Services.AddDbContext<FriendContext>(optionsAction =>
optionsAction.UseSqlServer(friendDbConnectString));

if (builder.Environment.IsProduction())
{

    builder.Services.AddTransient<IFriendsService, FriendsDbService>();
}
else
{
    builder.Services.AddSingleton<IFriendsService, StubFriendsService>();
}

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
