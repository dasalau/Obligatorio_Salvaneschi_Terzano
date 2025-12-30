namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Log
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        public Log()
        {
        }
        public Log(string accion, DateTime fecha, int usuarioId)
        {
            Accion = accion;
            UsuarioId = usuarioId;
            Fecha = fecha;
        }
    }
}
