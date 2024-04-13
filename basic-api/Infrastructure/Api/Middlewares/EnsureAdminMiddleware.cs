using basic_api.Application.Account.UseCases;
using basic_api.Data.Entities.Enum;
using basic_api.Data.Services;
using basic_api.Infrastructure.Services;
namespace basic_api.Infrastructure.Api.Middlewares
{
    public class EnsureAdminMiddleware(RequestDelegate next, IAuthService<AuthPayload> authService)
    {
        private readonly RequestDelegate _next = next;
        private readonly IAuthService<AuthPayload> _authService = authService;

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
                if(usuario.role != RoleNameEnum.Administrator)
                {
                    throw new Exception();
                }
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
