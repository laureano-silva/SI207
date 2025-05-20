namespace Aplicacion;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        if (evento.FechaHoraInicio < DateTime.Now)
        {
            throw new OperacionInvalidaException("No se pueden modificar eventos pasados");
        }   
        try
        {
            validador.Validar(evento);
            repo.ModificarEventoDeportivo(evento);
        }
        catch (ValidacionException e)
        {
            throw new ValidacionException(e.Message);
        }
        catch (EntidadNotFoundException e)
        {
            throw new EntidadNotFoundException(e.Message);
        }
    }
}