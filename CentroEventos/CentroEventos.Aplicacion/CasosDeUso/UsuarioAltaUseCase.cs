namespace Aplicacion;

public class UsuarioAltaUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Usuario usuario, int userId)
    {
        if (!auth.EstaAutorizado(userId, Permiso.UsuarioAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }

        var resultado = validador.Validar(usuario);

        switch (resultado.Codigo)
        {
            case CodigoValidacion.SinErrores:
                break;

            case CodigoValidacion.DuplicadoError:
               throw new DuplicadoException(resultado.Mensaje);

            case CodigoValidacion.ValidacionError:
                throw new ValidacionException(resultado.Mensaje);

            default:
                throw new Exception("Codigo de validacion no reconocido.");
        }
        repo.AgregarUsuario(usuario);
    }
}