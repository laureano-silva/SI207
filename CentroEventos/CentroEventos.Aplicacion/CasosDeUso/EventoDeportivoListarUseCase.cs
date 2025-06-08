namespace Aplicacion;

public class EventoDeportivoListarUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{

    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> eventos = repositorioEventoDeportivo.ListarEventoDeportivo();
        if (eventos.Count == 0)
        {
            throw new EntidadNotFoundException("No hay eventos registradoss.");
        }
        return eventos;
    }

}