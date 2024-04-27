using basic_api.Infrastructure.Api.Extensions;
using basic_api.Infrastructure.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Inject(builder.Configuration);

var app = builder.Build();

app.MapWhen(context =>
       !context.Request.Path.StartsWithSegments("/accounts/signIn") &&
       !context.Request.Path.StartsWithSegments("/swagger"),
       builder => builder.UseMiddleware<AuthMiddleware>());


app.MapWhen(context =>
       context.Request.Path.StartsWithSegments("/orders/reply") ||
       context.Request.Path.StartsWithSegments("/orders/devolve") ||
       context.Request.Path.StartsWithSegments("/orders/stocks"),
       builder => builder.UseMiddleware<EnsureOperatorMiddleware>());

app.MapWhen(
    context =>
    context.Request.Path.StartsWithSegments("/accounts") &&
    context.Request.Method.Equals("POST", StringComparison.CurrentCultureIgnoreCase),
    appBuilder => appBuilder.UseMiddleware<EnsureAdminMiddleware>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
