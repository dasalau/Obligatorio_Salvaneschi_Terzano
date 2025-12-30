using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.Infraestructura.AccespDatos.EF;
using Obligatorio.LogicaAplicacion.CasosUso.EquiposDeTrabajo;
using Obligatorio.LogicaAplicacion.CasosUso.MetodosDePago;
using Obligatorio.LogicaAplicacion.CasosUso.Pagos;
using Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto;
using Obligatorio.LogicaAplicacion.CasosUso.Usuarios;
using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using System.Text;
using WebApi.Services;


namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddSession();
            //builder.Services.AddDistributedMemoryCache();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // inyectar repositorios
            builder.Services.AddScoped<IRepositorioPagos, RepositorioPagos>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioEquipoTrabajo, RepositorioEquipoTrabajo>();
            builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();

            // inyectar caso de uso Pagos
            builder.Services.AddScoped<ICUGetById<PagosDtoListado>, GetPagoById>();
            builder.Services.AddScoped<ICUGetPagosByUsuarioId<PagosDtoListado>, GetPagosByUsuarioId>();
            builder.Services.AddScoped<ICUAddPagoUnico<PagoUnicoDtoAlta>, AddPagoUnico>();
            builder.Services.AddScoped<ICUAddPagoRecurrente<PagoRecurrenteDtoAlta>, AddPagoRecurrente>();
            builder.Services.AddScoped<ICUGetPagosByTipoGastoId<PagosByTipoGastoDtoReporte>, GetPagosByTipoGastoId>();

            // inyectar los casos de uso de Usuarios
            builder.Services.AddScoped<ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado>, UsuarioLogin>();
            builder.Services.AddScoped<ICUGetById<UsuarioDtoListado>, GetByIdUsuario>();
            builder.Services.AddScoped<ICUChangePassword<int>, ChangePassword>();

            // inyectar los casos de uso de Equipo de Trabajo
            builder.Services.AddScoped<ICUGetEquiposPagosUnicosByMonto<EquipoTrabajoDtoListado>, GetEquiposPagosUnicosByMonto>();
            builder.Services.AddScoped<ICUGetAll<EquipoTrabajoDtoListado>, GetAllEquipoTrabajo>();

            // inyectar los casos de uso de Metodo de Pago
            builder.Services.AddScoped<ICUGetById<MetodosDePagoDtoListado>, GetByIdMetodoPago>();

            // inyectar los casos de uso de Tipos de Gasto
            builder.Services.AddScoped<ICUGetById<TiposDeGastoDtoListado>, GetByIdTipoGasto>();

            // inyectar el contexto
            builder.Services.AddDbContext<ObligatorioContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("Obligatorio.N3C.323559-317837"))
                );

            // Para darle seguridad a la API
            // 1. Obtener configuración JWT desde appsettings.json
            var jwtSection = builder.Configuration.GetSection("Jwt");
            builder.Services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);

            // 2. Agregar servicio que genera tokens
            builder.Services.AddScoped<IJwtGenerator<UsuarioDtoApi>, JwtGenerator>();

            // 3. Configurar autenticación JWT
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

            builder.Services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // ?? poner en true para producción
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,   // podés poner en true si usás Issuer
                    ValidateAudience = false, // podés poner en true si usás Audience
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //app.UseSession();

            app.Run();
        }
    }
}
