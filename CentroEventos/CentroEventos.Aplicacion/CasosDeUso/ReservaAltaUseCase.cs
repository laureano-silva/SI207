namespace Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repo, ReservaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!auth.EstaAutorizado(idUsuario, Permiso.ReservaAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }

        var resultado = validador.Validar(reserva);

        switch (resultado.Codigo)
        {
            case CodigoValidacion.SinErrores:
                break;

            case CodigoValidacion.ValidacionError:
                throw new EntidadNotFoundException(resultado.Mensaje);

            case CodigoValidacion.DuplicadoError:
                throw new DuplicadoException(resultado.Mensaje);
            case CodigoValidacion.CupoExedido:
                throw new ValidacionException(resultado.Mensaje);

            default:
                throw new Exception("Código de validación no reconocido.");
        }

        repo.AgregarReserva(reserva);
    }
}