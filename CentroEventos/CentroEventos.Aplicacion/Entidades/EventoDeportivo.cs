using System.Security.Principal;

namespace Aplicacion;
public class EventoDeportivo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    public int CupoDisponible => CupoMaximo - Reservas.Count;
    public int ResponsableId { get; set; }
    public EventoDeportivo(){}
    public EventoDeportivo(int id, string nombre, string descripcion, DateTime fecha, int cupoMaximo, int ResponsableId)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fecha;
        CupoMaximo = cupoMaximo;
    }

    public override string ToString()
    {
        return $"Evento: {Nombre}, Fecha: {FechaHoraInicio}, Cupo: {CupoMaximo}, Descripcion: {Descripcion}";
    }
}