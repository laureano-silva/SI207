using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

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