using MailWebApi.Config;
using MailWebApi.Models;
using MailWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MailDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IDataStorage<Mail>, MailData>();
builder.Services.AddTransient<IMailService, MailService>();

var app = builder.Build();

builder.Configuration.AddJsonFile("mailsettings.json");
var mailConfig = new MailConfig();
app.Configuration.Bind(mailConfig);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
