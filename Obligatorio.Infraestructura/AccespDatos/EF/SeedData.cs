
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class SeedData
    {
        private ObligatorioContext _context;
        public SeedData(ObligatorioContext context)
        {
            _context = context;
        }
        public void Run()
        {
            if (!_context.EquiposTrabajo.Any()) CreateEquiposTrabajo();
            if (!_context.Usuarios.Any()) CreateUsuarios();
            if (!_context.TipoGastos.Any()) CreateTipoGastos();
            if (!_context.MetodosPago.Any()) CreateMetodoPago();
            if (!_context.Pagos.Any()) CreatePagos();
        }

        private void CreateTipoGastos()
        {
            _context.Add(
                new TipoGasto(
                   new VoDescripcion("Auto")));
            _context.Add(
              new TipoGasto(
                   new VoDescripcion("Casa")));
            _context.Add(
              new TipoGasto(
                   new VoDescripcion("Salidas")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Auto")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Alquiler")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Supermercado")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Transporte")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Educación")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Salud")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Entretenimiento")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Restaurantes")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Servicios Públicos")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Internet y Telefonía")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Ropa")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Mascotas")));
            _context.Add(
                new TipoGasto(
                    new VoDescripcion("Viajes")));
            _context.Add(
                new TipoGasto(new VoDescripcion("Impuestos")));
            _context.Add(
                new TipoGasto(new VoDescripcion("Otros")));

            _context.SaveChanges();

        }

        private void CreateMetodoPago()
        {
            _context.Add(
                new Credito());
            _context.Add(
                new Contado());
            _context.SaveChanges();

        }


        private void CreateEquiposTrabajo()
        {
            _context.EquiposTrabajo.Add(
                new EquipoTrabajo(
                                new VoNombre("Zona Norte")
                                ));
            _context.EquiposTrabajo.Add(
                new EquipoTrabajo(
                                new VoNombre("Zona Sur")
                                ));
            _context.EquiposTrabajo.Add(
                new EquipoTrabajo(
                                new VoNombre("Zona Oeste")
                                ));
            _context.EquiposTrabajo.Add(
                new EquipoTrabajo(
                                new VoNombre("Zona Este")
                                ));
            _context.EquiposTrabajo.Add(
                new EquipoTrabajo(
                                new VoNombre("Zona Centro")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(
                                new VoNombre("Zona Metropolitana")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Rural")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Industrial")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Comercial")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Costera")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Frontera")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Alta")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Baja")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Urbana")
                                ));
            _context.EquiposTrabajo.Add(
                                new EquipoTrabajo(new VoNombre("Zona Residencial")
                                ));


            _context.SaveChanges();
        }

        private void CreateUsuarios()
        {
            _context.Usuarios.Add(
                new Gerente(
                               new VoNombre("Daniel"),
                               new VoApellido("Salvaneschi"),
                               new VoContrasenia("pass1"),
                               new VoEmail("dansal@empresa.com"),
                               2
                               ));

            _context.Usuarios.Add(
                new Administrador(
                               new VoNombre("Jaime"),
                               new VoApellido("Terzano"),
                               new VoContrasenia("pass1"),
                               new VoEmail("jaiter@empresa.com"),
                               1
                               ));

            _context.Usuarios.Add(
                new Empleado(
                               new VoNombre("Paula"),
                               new VoApellido("Salvaneschi"),
                               new VoContrasenia("pass1"),
                               new VoEmail("pausal@empresa.com"),
                               3
                               ));

            _context.Usuarios.Add(
                new Administrador(
                    new VoNombre("Admin1"),
                    new VoApellido("Sistema"),
                    new VoContrasenia("adminpass1"),
                    new VoEmail("admsis@empresa.com"),
                    4
                    ));

            _context.Usuarios.Add(
                new Administrador(
                    new VoNombre("Admin2"),
                    new VoApellido("Sistema"),
                    new VoContrasenia("adminpass2"),
                    new VoEmail("admsis@empresa.com"),
                    2
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Laura"),
                    new VoApellido("Fernández"),
                    new VoContrasenia("pass2"),
                    new VoEmail("laufer@empresa.com"),
                    3
                    ));

            _context.Usuarios.Add(
                new Gerente(new VoNombre("Martín"),
                new VoApellido("Pérez"),
                new VoContrasenia("pass3"),
                new VoEmail("marper@empresa.com"),
                2
                ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Sofía"),
                    new VoApellido("Rodríguez"),
                    new VoContrasenia("pass4"),
                    new VoEmail("sofro@empresa.com"),
                    1
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Javier"),
                    new VoApellido("Gómez"),
                    new VoContrasenia("pass5"),
                    new VoEmail("javgom@empresa.com"),
                    4));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Carla"),
                    new VoApellido("López"),
                    new VoContrasenia("pass6"),
                    new VoEmail("carlop@empresa.com"),
                    3
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Andrés"),
                    new VoApellido("Martínez"),
                    new VoContrasenia("pass7"),
                    new VoEmail("andmar@empresa.com"),
                    1
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Valentina"),
                    new VoApellido("Silva"),
                    new VoContrasenia("pass8"),
                    new VoEmail("valsil@empresa.com"),
                    3
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Federico"),
                    new VoApellido("Torres"),
                    new VoContrasenia("pass9"),
                    new VoEmail("feditor@empresa.com"),
                    4
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Lucía"),
                    new VoApellido("Ramos"),
                    new VoContrasenia("pass10"),
                    new VoEmail("lucram@empresa.com"),
                    2
                    ));

            _context.Usuarios.Add(
                new Gerente(new VoNombre("Sebastián"),
                new VoApellido("Cabrera"),
                new VoContrasenia("pass11"),
                new VoEmail("sebcab@empresa.com"),
                1
                ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Camila"),
                    new VoApellido("Vega"),
                    new VoContrasenia("pass12"),
                    new VoEmail("camveg@empresa.com"),
                    3
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Diego"),
                    new VoApellido("Méndez"),
                    new VoContrasenia("pass13"),
                    new VoEmail("diemen@empresa.com"),
                    1
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Agustina"),
                    new VoApellido("Reyes"),
                    new VoContrasenia("pass14"),
                    new VoEmail("agurey@empresa.com"),
                    4
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Tomás"),
                    new VoApellido("Ruiz"),
                    new VoContrasenia("pass15"),
                    new VoEmail("tomrui@empresa.com"),
                    4
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("María"),
                    new VoApellido("Benítez"),
                    new VoContrasenia("pass16"),
                    new VoEmail("marben@empresa.com"),
                    2
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Lucas"),
                    new VoApellido("Sánchez"),
                    new VoContrasenia("pass17"),
                    new VoEmail("lucsan@empresa.com"),
                    1
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Julieta"),
                    new VoApellido("Morales"),
                    new VoContrasenia("pass18"),
                    new VoEmail("julmor@empresa.com"),
                    1
                    ));

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Nicolás"),
                    new VoApellido("Castro"),
                    new VoContrasenia("pass19"),
                    new VoEmail("niccas@empresa.com"),
                    2
                    ));

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Florencia"),
                    new VoApellido("Navarro"),
                    new VoContrasenia("pass20"),
                    new VoEmail("flonav@empresa.com"),
                    4
                    ));

            _context.SaveChanges();
        }


        private void CreatePagos()
        {
            var random = new Random();

            for (int i = 1; i <= 200; i++)
            {
                string descripcion = $"Pago generado #{i}";
                double monto = Math.Round(random.NextDouble() * 10000 + 100, 2);
                int tipoGastoId = random.Next(1, 19); // 1 a 18
                int metodoPagoId = random.Next(1, 3); // 1 o 2
                int usuarioId = random.Next(1, 25); // 1 a 24

                int anio = random.Next(2021, 2026);
                int mes = random.Next(1, 13);
                int dia = random.Next(1, DateTime.DaysInMonth(anio, mes) + 1);
                DateTime fechaBase = new DateTime(anio, mes, dia);

                if (i % 2 == 0)
                {
                    DateTime fechaDesde = fechaBase;
                    DateTime fechaHasta = fechaDesde.AddMonths(random.Next(1, 12));

                    _context.Add(new Recurrente(
                        new VoDescripcion(descripcion),
                        monto,
                        tipoGastoId,
                        metodoPagoId,
                        usuarioId,
                        fechaDesde,
                        fechaHasta
                    ));
                }
                else
                {
                    int numeroRecibo = 1000 + i;

                    _context.Add(new Unico(
                        new VoDescripcion(descripcion),
                        monto,
                        tipoGastoId,
                        metodoPagoId,
                        usuarioId,
                        fechaBase,
                        numeroRecibo
                    ));
                }
            }

            _context.SaveChanges();
        }






    }
}
