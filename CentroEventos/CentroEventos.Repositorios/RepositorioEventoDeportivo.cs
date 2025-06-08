using Aplicacion;
namespace Repositorios;
public class RepositorioEventoDeportivo() : IRepositorioEventoDeportivo
{
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        if (e is null)
        {
            throw new ArgumentNullException("El evento deportivo no puede ser nulo.");
        }
        using var context = new CentroEventosContext();
        context.Eventos.Add(e);
        context.SaveChanges();
    }

    public void EliminarEventoDeportivo(int id)
    {
        using var context = new CentroEventosContext();
        var evento = context.Eventos.Find(id);
        if (evento is null)
        {
            throw new EntidadNotFoundException("El Evento Deportivo no se encuentra en el repositorio.");
        }
        context.Eventos.Remove(evento);
        context.SaveChanges();
    }
     
    public bool ExisteEventoDeportivo(int id)
    {
        using var context = new CentroEventosContext();
        return context.Eventos.Any(e => e.Id == id);
    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        using var context = new CentroEventosContext();
        return context.Eventos.ToList();
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        using var context = new CentroEventosContext();
        var eventoExistente = context.Eventos.Find(evento.Id);
        if (eventoExistente is null)
        {
            throw new EntidadNotFoundException("El Evento Deportivo no se encuentra en el repositorio.");
        }
        eventoExistente.Nombre = evento.Nombre;
        eventoExistente.Descripcion = evento.Descripcion;
        eventoExistente.FechaHoraInicio = evento.FechaHoraInicio;
        eventoExistente.DuracionHoras = evento.DuracionHoras;
        eventoExistente.CupoMaximo = evento.CupoMaximo;
        eventoExistente.PersonaId = evento.PersonaId;
    }

    public EventoDeportivo? ObtenerEventoDeportivo(int id)
    {
        using var context = new CentroEventosContext();
        return context.Eventos.Find(id);
    }
}