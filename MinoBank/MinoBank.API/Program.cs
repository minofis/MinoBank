using Microsoft.EntityFrameworkCore;
using MinoBank.API.Helpers;
using MinoBank.Business.Services;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;
using MinoBank.Infrastructure.Data;
using MinoBank.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
builder.Services.AddScoped<IBankAccountsService, BankAccountsService>();
builder.Services.AddAutoMapper(typeof(BankAccountProfile));
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