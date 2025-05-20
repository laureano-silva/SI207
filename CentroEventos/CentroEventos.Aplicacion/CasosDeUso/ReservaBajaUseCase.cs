namespace Aplicacion;

public class ReservaBajaUseCase(IRepositorioReserva repo, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
    if (!auth.EstaAutorizado(IdUsuario, Permiso.ReservaBaja, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        repo.EliminarReserva(reserva.Id);
    }
}