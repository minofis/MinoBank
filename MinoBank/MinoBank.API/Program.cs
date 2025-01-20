using Microsoft.EntityFrameworkCore;
using MinoBank.API.Helpers;
using MinoBank.Business.Services;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;
using MinoBank.Infrastructure.Data;
using MinoBank.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
builder.Services.AddScoped<IBankCardsRepository, BankCardsRepository>();
builder.Services.AddScoped<IBankTransactionsRepository, BankTransactionsRepository>();
builder.Services.AddScoped<IBankAccountsService, BankAccountsService>();
builder.Services.AddScoped<IBankCardsService, BankCardsService>();
builder.Services.AddScoped<IBankTransactionsService, BankTransactionsService>();
builder.Services.AddAutoMapper(typeof(BankAccountProfile));
builder.Services.AddAutoMapper(typeof(BankCardProfile));
builder.Services.AddAutoMapper(typeof(BankTransactionProfile));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();