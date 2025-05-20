using Aplicacion;


public class EventoDeportivoValidador
{
    private readonly IRepositorioPersona _repositorio;

    public EventoDeportivoValidador(IRepositorioPersona repositorio)
    {
        _repositorio = repositorio;
    }
    public void Validar(EventoDeportivo evento)
    {
        if (string.IsNullOrEmpty(evento.Nombre))
        {
            throw new ValidacionException("El nombre no puede estar vacio");
        }
        if (string.IsNullOrEmpty(evento.Descripcion))
        {
            throw new ValidacionException("La descripcion no puede estar vacia");
        }
        if (evento.FechaHoraInicio < DateTime.Now)
        {
            throw new ValidacionException("La fecha y hora de inicio no puede ser menor a la fecha y hora actual");
        }
        if (evento.CupoMaximo < 1)
        {
            throw new ValidacionException("El cupo maximo no puede ser menor a 1");
        }
        if (evento.DuracionHoras <= 0)
        {
            throw new ValidacionException("La duracion debe ser mayor a 0");
        }
        if (_repositorio.ExistePersona(evento.ResponsableId) == false)
        {   
            throw new ValidacionException("El responsable no existe");
        }
    }
}