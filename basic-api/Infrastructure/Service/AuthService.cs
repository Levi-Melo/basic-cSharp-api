using basic_api.Data.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace basic_api.Infrastructure.Service
{
    public class AuthService<T>(IConfiguration config, int minutes) : IAuthService<T>
        where T : struct
    {
        IConfiguration _config = config;
        int _minutes = minutes;

        public string SignIn(T content)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            // Usando reflexão para iterar sobre as propriedades do objeto
            foreach (var prop in content.GetType().GetProperties())
            {
                var value = prop.GetValue(content)?.ToString();
                if (value != null)
                {
                    claims.Add(new Claim(prop.Name, value));
                }
            }


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(_minutes),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public T Verify(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            var readToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            SecurityToken validatedToken;

            var result = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);

            T payload = new T();
            var properties = typeof(T).GetProperties();
            foreach (var claim in readToken.Claims)
            {
                var property = properties.FirstOrDefault(p => p.Name.Equals(claim.Type, StringComparison.OrdinalIgnoreCase));
                if (property != null && property.CanWrite)
                {
                    var value = Convert.ChangeType(claim.Value, property.PropertyType);
                    property.SetValue(payload, value);
                }
            }

            return payload;
        }
        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua_chave_secreta")),
                ValidateIssuer = false, // Defina como true se você quiser validar o emissor
                ValidateAudience = false, // Defina como true se você quiser validar o público
                                          // Você pode adicionar outras configurações conforme necessário
            };
        }
    }
}
