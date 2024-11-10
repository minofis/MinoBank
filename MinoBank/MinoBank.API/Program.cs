using Microsoft.EntityFrameworkCore;
using MinoBank.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();