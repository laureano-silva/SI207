using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;
public class ReservaBajaUseCase(IRepositorioReserva repo, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int IdUsuario)
    {
        if (!auth.EstaAutorizado(IdUsuario, Permiso.ReservaBaja))
            {
                throw new FalloAutorizacionException("error Autorizacion");
            }

        repo.EliminarReserva(id);
    }
}