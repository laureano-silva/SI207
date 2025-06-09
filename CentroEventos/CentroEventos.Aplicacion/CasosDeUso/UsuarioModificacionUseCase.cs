namespace Aplicacion;

public class UsuarioModificacionUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Usuario usuario, int userId)
    {
        // si el usuario se modifica a si mismo, ignorar permisos
        var usuarioActual = repo.ObtenerUsuario(usuario.Id);
        if (usuarioActual is null)
        {
            throw new EntidadNotFoundException("Usuario no encontrado.");
        }

        // si el usuario se quiere modificar a si mismo no se requieren permisos
        if (usuarioActual.Id != usuario.Id &&
            !auth.EstaAutorizado(userId, Permiso.UsuarioModificacion, out string errorAutorizacion))
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
        repo.ModificarUsuario(usuario);
    }
}