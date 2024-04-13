using basic_api.Infrastructure.Api.Extensions;
using basic_api.Infrastructure.Api.Middlewares;
using basic_api.Infrastructure.Database.Context;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Inject(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<AuthMiddleware>();


app.MapWhen(context => !context.Request.Path.StartsWithSegments("/accounts/signin"), appBuilder =>
{
    appBuilder.UseRouting();
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});


app.UseMiddleware<EnsureOperatorMiddleware>();

app.MapWhen(
    context => !context.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase) || 
    context.Request.Path.StartsWithSegments("/accounts/signin") || 
    !(context.Request.Path.StartsWithSegments("/accounts") && context.Request.Method.Equals("POST", StringComparison.CurrentCultureIgnoreCase)), 
    appBuilder =>
    {
    appBuilder.UseRouting();
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});


app.UseMiddleware<EnsureAdminMiddleware>();
app.MapWhen(
    context => !context.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase) || 
    !context.Request.Path.StartsWithSegments("/accounts/signin") || 
    (context.Request.Path.StartsWithSegments("/accounts") && context.Request.Method.Equals("POST", StringComparison.CurrentCultureIgnoreCase)), 
    appBuilder =>
{
    appBuilder.UseRouting();
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
