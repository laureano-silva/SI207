namespace Aplicacion;
public interface IRepositorioEventoDeportivo{
    void AgregarEventoDeportivo(EventoDeportivo e);
    EventoDeportivo? ObtenerEventoDeportivo(int id);
    void ModificarEventoDeportivo(EventoDeportivo e);
    void EliminarEventoDeportivo(int id);
    bool ExisteEventoDeportivo(int id);
    List<EventoDeportivo> ListarEventoDeportivo();
}