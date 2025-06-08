namespace Aplicacion;

public class ListarAsistenciaAEventoUseCase(IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona)
{
    public List<Persona> Ejecutar(int idEvento)
    {
        List<Persona> personas = new List<Persona>();
        List<Reserva> reservas = repositorioReserva.ListarReserva();
        EventoDeportivo? evento = repositorioEventoDeportivo.ObtenerEventoDeportivo(idEvento);
        if (evento is null)
        {
            throw new EntidadNotFoundException("El evento no existe.");
        }
        if (evento.FechaHoraInicio > DateTime.Now)
        {
            throw new EntidadNotFoundException("Solo puede consultar la asistencia de eventos pasados.");
        }
        foreach (Reserva r in reservas) //itero sobre las reservas recuperando las personas que asistieron al evento
        {
            if (r.EventoDeportivoId == idEvento)
            {
                Persona? persona = repositorioPersona.ObtenerPersona(r.PersonaId); // cambiar nombre del metodo a ObtenerPersona o algo asi
                if (persona is null)
                {
                    throw new EntidadNotFoundException("La persona no existe.");
                }
                if (r.EstadoAsistencia == EstadoAsistencia.Presente)
                {
                    personas.Add(persona);
                }
            }
        }
        return personas;
    }
}