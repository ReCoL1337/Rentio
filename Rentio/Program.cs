using Microsoft.EntityFrameworkCore;
using Rentio.Lib.Validators;
using Rentio.Services;
using Rentio.Lib.Repositories;
using Rentio.Lib.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=Rentio.db", options => options.MigrationsAssembly("Rentio.Lib")), ServiceLifetime.Transient);
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IRentioSeeder, RentioSeeder>();

// Add services to the container.
builder.Services.AddScoped<CreditCardValidator>();
builder.Services.AddScoped<CarService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scope = app.Services.CreateScope();
try {
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
    var seeder = scope.ServiceProvider.GetRequiredService<IRentioSeeder>();
    await seeder.Seed();
}
catch (Exception ex) {
    Console.WriteLine($"Migration/Seeding failed: {ex}");
    throw;
}

app.Run();