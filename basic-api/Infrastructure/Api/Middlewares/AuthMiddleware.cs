using basic_api.Application.Account.UseCases;
using basic_api.Data.Services;
using basic_api.Infrastructure.Services;
namespace basic_api.Infrastructure.Api.Middlewares
{
    public class AuthMiddleware(RequestDelegate next, AuthService<AuthPayload> authService)
    {
        private readonly RequestDelegate _next = next;
        private readonly AuthService<AuthPayload> _authService = authService;

        // Método do middleware que usa o serviço de autenticação
        public async Task InvokeAsync(HttpContext context)
        {
            
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Token de autorização ausente.");
                return;
            }

            string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            // Verifica se o token está presente
            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Token de autorização inválido.");
                return;
            }

            try
            {
                var usuario = _authService.Verify(token);

                context.Items["TokenPayload"] = usuario;

                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Falha ao verificar o token de autorização.");
            }
        }
    }
}
