namespace Aplicacion;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
    if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoBaja, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        repo.EliminarEventoDeportivo(evento.Id);
    }
}