using MassTransit;
using Microsoft.EntityFrameworkCore;
using SenderWallet.Application.Common.Data;
using SenderWallet.Application.Common.Interfaces;
using SenderWallet.Application.UseCases.Wallets.Commands.CreateWallet;
using SenderWallet.Application.UseCases.Wallets.Commands.ExchangeCurrencyWallet;
using SenderWallet.Infrastrucrure.Data;
using SenderWallet.Infrastrucrure.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<WalletDbContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
                      .LogTo(Console.Write, LogLevel.Information));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ExchangeCurrencyCommand).Assembly));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateWalletCommand).Assembly));

builder.Services.AddScoped<IWalletDbContext, WalletDbContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEventBusPublisher, EventBusPublisher>();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x =>
{
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix: "wallet", includeNamespace: false));
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(builder.Configuration["RabbitMq:Host"]), h =>
        {
            h.Username(builder.Configuration["RabbitMq:Username"]);
            h.Password(builder.Configuration["RabbitMq:Password"]);
        });
        cfg.ConfigureEndpoints(context);
    });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<WalletDbContext>();
    context.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
