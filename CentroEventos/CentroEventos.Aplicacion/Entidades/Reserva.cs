namespace Aplicacion;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public EstadoAsistencia EstadoAsistencia { get; set; }
    
    public Reserva(){}
    public Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estadoAsistencia)
    {
        Id = id;
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }
    public override string ToString()
    {
        return $"Reserva: {Id}, PersonaId: {PersonaId}, EventoDeportivoId: {EventoDeportivoId}, FechaAltaReserva: {FechaAltaReserva}, EstadoAsistencia: {EstadoAsistencia}";
    }
}