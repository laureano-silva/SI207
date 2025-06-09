namespace Aplicacion;

public class UsuarioListarUseCase(IRepositorioUsuario repositorioUsuario)
{

    public List<Usuario>? Ejecutar()
    {
        List<Usuario> usuarios = repositorioUsuario.ListarUsuario();
        return usuarios;
    }
}