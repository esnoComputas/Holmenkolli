using AspireApp.ServiceDefaults;
using AspireApp.WebApp.Components;
using AspireApp.WebApp.Database;
using AspireApp.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<HolmenkollenDbContext>(connectionName: "postgresdb");
builder.Services.AddScoped<HolmenkollenService>();
builder.Services.AddSingleton<DistributeStagesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HolmenkollenDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.Run();
