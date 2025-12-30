namespace Obligatorio.LogicaAplicacion.Dtos.Usuarios
{
    public record UsuarioDtoListado(int Id,
                                    string Nombre,
                                    string Apellido,
                                    string Contrasenia,   //Va? 
                                    string Email,
                                    string Rol,
                                    int EquipoTrabajoId,
                                    string EquipoTrabajo)
    {
    }
}
