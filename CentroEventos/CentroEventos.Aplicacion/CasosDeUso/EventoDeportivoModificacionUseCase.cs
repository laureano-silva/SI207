namespace Aplicacion;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoModificacion, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        if (evento.FechaHoraInicio < DateTime.Now)
        {
            throw new OperacionInvalidaException("No se pueden modificar eventos pasados");
        }   
       
           var resultado = validador.Validar(evento);
        if (resultado.Codigo == CodigoValidacion.ValidacionError)
        {
            throw new ValidacionException(resultado.Mensaje);
        }
        repo.ModificarEventoDeportivo(evento);
        
      
    }
}