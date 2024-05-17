using Services.Helper;
using Services.Interface;
using Services.Repository;
using StudentMgtSystem;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IStudentRepository,StudentRepository>();
builder.Services.AddSingleton<IEmailService,EmailService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
