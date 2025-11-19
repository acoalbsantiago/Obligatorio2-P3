using LogicaDeAplicacion.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class TokenHandler
    {
        private string _clave;

        public TokenHandler(IConfiguration config)
        {
            _clave = config["Jwt:Key"];
        }

        public string GenerarToken(UsuarioDTO dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claveSecreta = Encoding.UTF8.GetBytes(_clave);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, dto.Email),
                        new Claim(ClaimTypes.Name, dto.Nombre),
                        new Claim(ClaimTypes.Role, dto.Rol)
                    }
                ),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(claveSecreta),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

