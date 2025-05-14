namespace Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repositorioReserva, ReservaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!auth.EstaAutorizado(idUsuario, Permiso.ReservaAlta, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        if (!validador.Validar(reserva, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }
        repositorioReserva.AgregarReserva(reserva);
    }
}