namespace Aplicacion;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public EstadoAsistencia EstadoAsistencia { get; set; }
    
    public Reserva(){}
    public Reserva(int personaId, int eventoDeportivoId, EstadoAsistencia estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = DateTime.Now;
        EstadoAsistencia = estadoAsistencia;
    }
    public override string ToString()
    {
        return $"PersonaId: {PersonaId}, EventoDeportivoId: {EventoDeportivoId}, FechaAltaReserva: {FechaAltaReserva}, EstadoAsistencia: {EstadoAsistencia}";
    }
}