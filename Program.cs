using Microsoft.EntityFrameworkCore;
using mitesh_gandhi_pratical_test.DataStore;
using mitesh_gandhi_pratical_test.Interface;
using mitesh_gandhi_pratical_test.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContextData>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("mitesh_gandhi_pratical_test")));
builder.Services.AddAutoMapper(typeof(MappingDataProfilecs));
builder.Services.AddScoped<IPerson,PersonManagementService>();
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
    pattern: "{controller=Person}/{action=Index}/{id?}");

app.Run();
