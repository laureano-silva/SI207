namespace Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repo, ReservaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!auth.EstaAutorizado(idUsuario, Permiso.ReservaAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        try
        {
            validador.Validar(reserva);
            repo.AgregarReserva(reserva);
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