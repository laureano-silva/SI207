using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioListarUseCase(IRepositorioUsuario repositorioUsuario)
{

    public List<Usuario>? Ejecutar()
    {
        List<Usuario> usuarios = repositorioUsuario.ListarUsuario();
        return usuarios;
    }
}