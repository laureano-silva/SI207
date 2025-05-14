using Aplicacion;
public class ReservaValidador
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;

    public ReservaValidador(IRepositorioReserva repoReserva, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
    }
    private bool YaReservoEvento(Reserva reserva)
    {
        List<Reserva> reservas = _repoReserva.ListarReserva(reserva.PersonaId);
        foreach (Reserva r in reservas)
        {
            if (r.Id != reserva.Id && r.EventoDeportivoId == reserva.EventoDeportivoId) //verifico que el ID sea diferente para permitir que ReservaModificacionUseCase use el mismo método de validación
            {
                return true;
            }
        }
        return false;
    }
    private bool HayCupoDisponible(int idEvento)
    {
        EventoDeportivo? evento = _repoEventoDeportivo.ObtenerEventoDeportivo(idEvento);
        return evento != null && evento.CupoDisponible > 0;
    }
    public bool Validar(Reserva reserva, out string message)
    {
        message = "";
        if (_repoPersona.ExistePersona(reserva.PersonaId) == false)
        {
            message += "La persona no existe.\n";
        }
        if (_repoEventoDeportivo.ExisteEventoDeportivo(reserva.EventoDeportivoId) == false)
        {
            message += "El reserva no existe.\n";
        }
        if (YaReservoEvento(reserva))
        {
            message += "La persona ya tiene una reserva para el evento seleccionado.\n";
        }
        if (!HayCupoDisponible(reserva.EventoDeportivoId))
        {
            message += "Las reservas para el evento se encuentran agotadas.\n";
        }
        return message == "";
    }
}