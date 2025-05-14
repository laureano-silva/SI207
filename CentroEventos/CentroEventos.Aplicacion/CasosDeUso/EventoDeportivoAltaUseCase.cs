using System.Data.Common;

namespace Aplicacion;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoAlta, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        if (!validador.Validar(evento, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }
        repo.AgregarEventoDeportivo(evento);
    }
}