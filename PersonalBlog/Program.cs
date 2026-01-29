using Microsoft.EntityFrameworkCore;
using PersonalBlog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddScoped<ArticleService>();

var storageMode = builder.Configuration["StorageMode"];

if (storageMode == "Json")
{
    builder.Services.AddSingleton<IArticleRepository, JsonArticleRepository>();
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

    builder.Services.AddScoped<IArticleRepository, SqliteArticleRepository>();
}

var app = builder.Build();

if (storageMode != "Json")
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
