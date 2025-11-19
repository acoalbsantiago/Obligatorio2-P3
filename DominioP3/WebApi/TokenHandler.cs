using LogicaDeAplicacion.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class TokenHandler
    {
        public static string GenerarToken(UsuarioDTO dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claveSecreta = Encoding.ASCII.GetBytes("unaClaveMUYS3CR3T4del_N3A.SeguimosAgregandoBytesAlaClave45678");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, dto.Email.Correo),
                        new Claim(ClaimTypes.Name, dto.Nombre)
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

