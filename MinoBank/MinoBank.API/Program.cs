using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Infrastructure.Data;
using MinoBank.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();