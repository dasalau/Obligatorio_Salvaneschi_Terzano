namespace Obligatorio.LogicaAplicacion.Dtos.Usuarios
{
    public record UsuarioDtoAlta(string Nombre,
                                 string Apellido,
                                 string Contrasenia,
                                 string Email,
                                 int EquipoTrabajoId
                                )
    {
    }
}
