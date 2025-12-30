using Microsoft.EntityFrameworkCore;
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


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();

        // Inyecto repositorios
        builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
        builder.Services.AddScoped<IRepositorioEquipoTrabajo, RepositorioEquipoTrabajo>();
        builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();
        builder.Services.AddScoped<IRepositorioPagos, RepositorioPagos>();
        builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
        builder.Services.AddScoped<IRepositorioLog, RepositorioLog>();

        // Inyecto los casos de uso de TipoGasto
        builder.Services.AddScoped<ICUAddTipoGastoWithLog<TiposDeGastoDtoAlta>, AddTipoGasto>();
        builder.Services.AddScoped<ICUGetAll<TiposDeGastoDtoListado>, GetAllTipoGasto>();
        builder.Services.AddScoped<ICUGetById<TiposDeGastoDtoListado>, GetByIdTipoGasto>();
        builder.Services.AddScoped<ICUDeleteWithLog<TiposDeGastoDtoAlta>, DeleteTipoGasto>();
        builder.Services.AddScoped<ICUUpdateWithLog<TiposDeGastoDtoAlta>, UpdateTipoGasto>();


        // Inyecto los casos de uso de EquipoTrabajo
        //builder.Services.AddScoped<ICUAddEquipoTrabajo<EquipoTrabajoDtoAlta>, AddEquipoTrabajo>();
        builder.Services.AddScoped<ICUGetAll<EquipoTrabajoDtoListado>, GetAllEquipoTrabajo>();

        //Inyeccion caso de uso de Usuarios
        builder.Services.AddScoped<ICUAddAdministrador<UsuarioDtoAlta>, AddAdministrador>();
        builder.Services.AddScoped<ICUAddGerente<UsuarioDtoAlta>, AddGerente>();
        builder.Services.AddScoped<ICUAddEmpleado<UsuarioDtoAlta>, AddEmpleado>();
        builder.Services.AddScoped<ICUGetAll<UsuarioDtoListado>, GetAllUsuario>();
        builder.Services.AddScoped<ICUGetById<UsuarioDtoListado>, GetByIdUsuario>();
        builder.Services.AddScoped<ICUUpdate<UsuarioDtoAlta>, UpdateUsuario>();
        builder.Services.AddScoped<ICUDelete<int>, DeleteUsuario>();
        builder.Services.AddScoped<ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado>, UsuarioLogin>();
        builder.Services.AddScoped<ICUUsuarioMontoSuperior<UsuarioDtoListado>, UsuarioMontoSuperior>();


        //Inyeccion caso de uso Pagos
        builder.Services.AddScoped<ICUAddPagoRecurrente<PagoRecurrenteDtoAlta>, AddPagoRecurrente>();
        builder.Services.AddScoped<ICUAddPagoUnico<PagoUnicoDtoAlta>, AddPagoUnico>();
        builder.Services.AddScoped<ICUGetAll<PagosDtoListado>, GetAllPagos>();
        builder.Services.AddScoped<ICUGetPagosMesAnio<PagoDtoReporteMensual>, GetPagosMesAnio>();
        //builder.Services.AddScoped<ICUGetById<PagosDtoListado>, GetByIdPagos>();
        //builder.Services.AddScoped<ICUDelete<PagosDtoAlta>, DeletePagos>();
        //builder.Services.AddScoped<ICUUpdate<PagosDtoAlta>, UpdatePagos>();

        //inyeccion metodos de Pago
        builder.Services.AddScoped<ICUGetAll<MetodosDePagoDtoListado>, GetAllMetodoPagos>();

        // Cargar datos inicialse de prueba a la base de datos
        builder.Services.AddScoped<SeedData>();


        //Inyecto el contexto con la conexion a la base de datos

        builder.Services.AddDbContext<ObligatorioContext>(
            option => option.UseSqlServer(builder.Configuration.GetConnectionString("Obligatorio.N3C.323559-317837"))
            );




        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
                seeder.Run();
            }
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Login}/{id?}");

        app.Run();
    }
}