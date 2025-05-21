namespace Aplicacion;

public class ReservaBajaUseCase(IRepositorioReserva repo, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int IdUsuario)
    {
    if (!auth.EstaAutorizado(IdUsuario, Permiso.ReservaBaja, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        repo.EliminarReserva(id);
    }
}