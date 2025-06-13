using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

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