using Microsoft.EntityFrameworkCore;
using Shared.Data;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan layanan ke dalam container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Pastikan Swagger diaktifkan

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");
      
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5108); // Pastikan ini sama dengan port dalam container
    //options.ListenAnyIP(7190, listenOptions => listenOptions.UseHttps());
});

var app = builder.Build();

// Konfigurasi pipeline HTTP request
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Langsung gunakan MapControllers tanpa UseRouting & UseEndpoints

app.Run();