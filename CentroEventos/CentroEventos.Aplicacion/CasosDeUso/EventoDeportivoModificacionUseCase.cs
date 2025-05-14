namespace Aplicacion;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        if (!validador.Validar(evento, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }
    repo.ModificarEventoDeportivo(evento);
    }
}