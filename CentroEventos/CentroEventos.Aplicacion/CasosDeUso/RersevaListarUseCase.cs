namespace Aplicacion;

public class ReservaListarUseCase(IRepositorioReserva repositorioReserva)
{

    public List<Reserva> Ejecutar()
    {
        List<Reserva> reserva = repositorioReserva.ListarReserva();
        if (reserva.Count == 0)
        {
            throw new EntidadNotFoundException("No hay reserva registradoss.");
        }
        return reserva;
    }

}