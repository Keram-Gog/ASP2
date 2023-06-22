using Lab3.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EFProgrammingLanguageRepository>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddSingleton<IProgrammingLanguageListRepository, InMemoryProgrammingLanguageListRepository>();

//для подключения к бд
//builder.Services.AddScoped<IProgrammingLanguageListRepository>(services => services.GetService<EFProgrammingLanguageRepository>() ?? throw new InvalidOperationException());

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=ProgrammingLanguage}/{action=Index}/{id?}");

app.Run();
