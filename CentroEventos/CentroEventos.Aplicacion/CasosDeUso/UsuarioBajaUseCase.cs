namespace Aplicacion;

public class UsuarioBajaUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!auth.EstaAutorizado(idUsuario, Permiso.UsuarioBaja, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        repoUsuario.EliminarUsuario(id);
    }
}