namespace Aplicacion;

public class ReservaModificacionUseCase(IRepositorioReserva repo, ReservaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        if (!repo.ExisteReserva(reserva.Id))
        {
            throw new Exception("La reserva no se encuentra en el repositorio.");
        }
        try
        {
            validador.Validar(reserva);
            repo.ModificarReserva(reserva);
        }
        catch (EntidadNotFoundException e)
        {
            throw new EntidadNotFoundException(e.Message);
        }
        catch (FalloAutorizacionException e)
        {
            throw new FalloAutorizacionException(e.Message);
        }
        catch (ValidacionException e)
        {
            throw new ValidacionException(e.Message);
        }
    }
}