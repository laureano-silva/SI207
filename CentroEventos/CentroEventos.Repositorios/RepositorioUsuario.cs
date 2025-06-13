using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Repositorios;

public class RepositorioUsuario() : IRepositorioUsuario
{
    
    public void AgregarUsuario(Usuario p)
    {
        if (p is null)
        {
            throw new ArgumentNullException("El usuario no puede ser nulo.");
        }
        using var context = new CentroEventosContext();
        context.Usuarios.Add(p);
        context.SaveChanges();
    }
    public void EliminarUsuario(int id)
    {
        using var context = new CentroEventosContext();
        var usuario = context.Usuarios.Find(id);
        if (usuario is null)
        {
            throw new EntidadNotFoundException("El usuario no se encuentra en el repositorio.");
        }
        context.Usuarios.Remove(usuario);
        context.SaveChanges();
    }
    public bool ExisteUsuario(int id)
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.Any(p => p.Id == id);
    }

    public List<Usuario> ListarUsuario()
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.ToList();
    }

    public void ModificarUsuario(Usuario usuario)
    {
        using var context = new CentroEventosContext();
        var usuarioExistente = context.Usuarios.Find(usuario.Id);
        if (usuarioExistente is null)
        {
            throw new EntidadNotFoundException("El usuario no se encuentra en el repositorio.");
        }
        usuarioExistente.Nombre = usuario.Nombre;
        usuarioExistente.Apellido = usuario.Apellido;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.EstablecerContraseña(usuario.Password);
        usuarioExistente.Email = usuario.Email;
        context.SaveChanges();
    }
    public Usuario? ObtenerUsuario(int id)
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.Find(id);
    }
}
