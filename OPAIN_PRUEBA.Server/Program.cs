using Microsoft.EntityFrameworkCore;
using OPAIN_PRUEBA.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Diego: Se configuracla conexión
builder.Services.AddDbContext<OpainDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionOPAIN"));
});

//Diego: Se agregan CORS para el navegador
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
