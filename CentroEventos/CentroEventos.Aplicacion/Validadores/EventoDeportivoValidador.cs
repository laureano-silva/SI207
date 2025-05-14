using Aplicacion;


public class EventoDeportivoValidador
{
    private readonly IRepositorioPersona _repositorio;

    public EventoDeportivoValidador(IRepositorioPersona repositorio)
    {
        _repositorio = repositorio;
    }
    public bool Validar(EventoDeportivo evento, out string message)
    {
        message = "";
        if (string.IsNullOrEmpty(evento.Nombre))
{
            message += "Nombre no puede estar vacio.\n";
        }
        if (string.IsNullOrEmpty(evento.Descripcion))
        {
            message += "Debe completar la descripcion.\n";
        }
        if (evento.FechaHoraInicio < DateTime.Now)
        {
            message += "La fecha no puede ser menor a la fecha actual.\n";
        }
        if (evento.CupoMaximo < 1)
        {
            message += "El cupo máximo no puede ser menor a uno.\n";
        }
        if (evento.DuracionHoras <= 0)
        {
            message += "La duracion debe ser mayor a cero.\n";
        }
        if (_repositorio.ExistePersona(evento.ResponsableId) == false)
        {
            message += "El responsable no existe.\n";
        }
        return message == "";
    }
}