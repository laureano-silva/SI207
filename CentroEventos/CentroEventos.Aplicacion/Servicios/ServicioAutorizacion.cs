namespace CentroEventos.Aplicacion.Servicios;

using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces;
public class ServicioAutorizacion(IRepositorioUsuario repoUsuario) : IServicioAutorizacion
{
    private readonly IRepositorioUsuario _repoUsuario = repoUsuario;

    public bool EstaAutorizado(int id, Permiso permiso, out string message)
    {
        message = "";
        var usuario = _repoUsuario.ObtenerUsuario(id);

        if (usuario == null)
        {
            message = "El usuario no existe.";
            return false;
        }

        if (usuario.Permisos == null || !usuario.Permisos.Contains(permiso))
        {
            message = "El usuario no tiene el permiso requerido.";
            return false;
        }

        return true;
    }
}