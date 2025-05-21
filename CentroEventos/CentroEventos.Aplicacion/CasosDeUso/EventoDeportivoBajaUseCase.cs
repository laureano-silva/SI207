namespace Aplicacion;

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