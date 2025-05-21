namespace Aplicacion;

public class ReservaModificacionUseCase(IRepositorioReserva repo, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        try
        {
            repo.ModificarReserva(reserva);
        }
        catch (EntidadNotFoundException e)
        {
            throw new EntidadNotFoundException(e.Message);
        }
    }
}