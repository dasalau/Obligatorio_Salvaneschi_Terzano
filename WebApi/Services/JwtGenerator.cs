using Microsoft.IdentityModel.Tokens;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Services
{
    public class JwtGenerator : IJwtGenerator<UsuarioDtoApi>
    {

        private readonly JwtSettings _settings;

        public JwtGenerator(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(UsuarioDtoApi usuario)
        {
            var key = Encoding.UTF8.GetBytes(_settings.Key);

            var claims = new[]
            {new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
