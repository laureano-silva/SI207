using System.Data.Common;

namespace Aplicacion;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        try
        {
            validador.Validar(evento);
            repo.AgregarEventoDeportivo(evento);
        }
        catch (ValidacionException e)
        {
            throw new ValidacionException(e.Message);
        }
    }
}