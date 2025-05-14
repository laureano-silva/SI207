namespace Aplicacion;

public class ReservaModificacionUseCase(IRepositorioReserva repo, ReservaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        if (!repo.ExisteReserva(reserva.Id))
        {
            throw new Exception("La reserva no se encuentra en el repositorio.");
        }
        if (!validador.Validar(reserva, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }
    repo.ModificarReserva(reserva);
    }
}