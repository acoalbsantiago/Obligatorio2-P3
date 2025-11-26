
using AccesoADatos.EF;
using AccesoADatos.Repositorios;
using LogicaDeAplicacion.CasosDeUso.Auditoria;
using LogicaDeAplicacion.CasosDeUso.Equipo;
using LogicaDeAplicacion.CasosDeUso.Pago;
using LogicaDeAplicacion.CasosDeUso.Usuario;
using LogicaDeAplicacion.InterfacesCU.Auditoria;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //TOKEN
            var key = builder.Configuration["Jwt:Key"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RoleClaimType = ClaimTypes.Role
                    };
                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<DbContext, ObligatorioContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiDB"))
            );
            //$Env:ASPNETCORE_ENVIRONMENT = "Home"
            //Console.WriteLine($"Entorno actual: {builder.Environment.EnvironmentName}");
            //Console.WriteLine($"Connection string: {builder.Configuration.GetConnectionString("MiDB")}");
            
            //Repositorios DI
            builder.Services.AddScoped<IPagoRepository, PagoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IEquipoRepository, EquipoRepository>();
            builder.Services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();

            //PagoDI
            builder.Services.AddScoped<IObtenerPagoPorId, ObtenerPagoPorIdCU>();
            builder.Services.AddScoped<IAgregarPago, AgregarPagoCU>();
            builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();
            builder.Services.AddScoped<IObtenerPagosPorUsuario,ObtenerPagosPorUsuarioCU>();

            //Auditoria DI
            builder.Services.AddScoped<IObtenerAuditoriaPorId, ObtenerAuditoriaPorIdCU>();

            //Equipo DI
            builder.Services.AddScoped<IObtenerEquiposSegunMontoDePagoUnico, ObtenerEquiposSegunMontoDePagoUnicoCU>();
            
            //Usuario-Home DI
            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IResetearPassword, ResetearPasswordCU>();
            builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuariosCU>();
            
            //TokenHandler DI
            builder.Services.AddScoped<TokenHandler>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
