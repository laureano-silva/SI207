using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

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