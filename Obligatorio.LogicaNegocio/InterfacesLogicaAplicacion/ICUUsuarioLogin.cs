namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUUsuarioLogin<TIn, TOut>
    {
        TOut Execute(TIn dto);
    }


}
