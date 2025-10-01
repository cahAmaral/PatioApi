using Microsoft.EntityFrameworkCore;
using PatioApi.Data;
using PatioApi.Services;
using PatioApi.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PatioContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<MovimentacaoService>();
builder.Services.AddScoped<OperadorService>();

    
builder.Services.AddScoped<MotoRepository>();
builder.Services.AddScoped<MovimentacaoRepository>();
builder.Services.AddScoped<OperadorRepository>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();