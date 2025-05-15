using MassTransit;
using Microsoft.EntityFrameworkCore;
using SenderWallet.Application.Common.Data;
using SenderWallet.Application.Common.Interfaces;
using SenderWallet.Application.Common.Mappers.Wallets;
using SenderWallet.Application.SenderWallet.Application;
using SenderWallet.Infrastrucrure.Data;
using SenderWallet.Infrastrucrure.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<WalletDbContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
                      .LogTo(Console.Write, LogLevel.Information));

builder.Services.AddApplication();

builder.Services.AddScoped<IWalletDbContext, WalletDbContext>();
builder.Services.AddAutoMapper(typeof(WalletMappingProfile));

    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEventBusPublisher, EventBusPublisher>();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix: "wallet", includeNamespace: false));

    x.UsingRabbitMq((context, cfg) =>
    {
        RabbitMqConfigurator.Configure(cfg, builder.Configuration);
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<WalletDbContext>();
    if (context != null) 
    {
        context.Database.Migrate();
    }
    else
    {
        throw new InvalidOperationException("WalletDbContext could not be resolved from the service provider.");
    }
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