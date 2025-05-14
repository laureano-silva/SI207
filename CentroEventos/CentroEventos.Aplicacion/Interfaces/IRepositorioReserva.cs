namespace Aplicacion;
public interface IRepositorioReserva
{
    public void AgregarReserva(Reserva reserva);

    public void EliminarReserva(int id);

    public void ModificarReserva(Reserva reserva);
    
    public bool ExisteReserva(int id);
    List<Reserva> ListarReserva();
    List<Reserva> ListarReserva(int idPersona);
}