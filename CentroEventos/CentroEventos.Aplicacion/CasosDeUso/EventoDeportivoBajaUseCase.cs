using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoBaja, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        var reservas = repoReserva.ListarReserva();
        foreach (var reserva in reservas)
        {
            if (reserva.EventoDeportivoId == id)
            {
                throw new OperacionInvalidaException("No se puede eliminar el evento deportivo porque tiene reservas asociadas.");
            }
        }
        repoEvento.EliminarEventoDeportivo(id);
    }
}