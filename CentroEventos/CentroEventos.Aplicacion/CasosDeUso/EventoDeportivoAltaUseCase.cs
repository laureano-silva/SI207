using System.Data.Common;

namespace Aplicacion;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(EventoDeportivo evento, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.EventoAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }

        var resultado = validador.Validar(evento);

        if (resultado.Codigo == CodigoValidacion.ValidacionError)
        {
            throw new ValidacionException(resultado.Mensaje);
        }

        repo.AgregarEventoDeportivo(evento);
    }
}