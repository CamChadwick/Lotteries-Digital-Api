using LotteriesDigitalApi.API;
using LotteriesDigitalApi.Application;
using LotteriesDigitalApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentationLayer()
        .AddApplication()
        .AddInfastructure(builder.Configuration);
    
}

var app = builder.Build();
{

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}




