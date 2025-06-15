using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class Sesion()
{
    public Usuario? UsuarioActual { get; private set; }
    public bool EstaLogueado => UsuarioActual is not null;
    public void Iniciar(Usuario usuario)
    {
        UsuarioActual = usuario;
    }
    public void Cerrar()
    {
        UsuarioActual = null;
    }
}