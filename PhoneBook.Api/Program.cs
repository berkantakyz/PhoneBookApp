using PhoneBook.Services.IServices;
using PhoneBook.Services;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PhoneBookContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("cs")));

builder.Services.AddControllers();

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();