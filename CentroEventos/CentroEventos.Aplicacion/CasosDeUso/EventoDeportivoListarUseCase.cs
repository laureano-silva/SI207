using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;
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