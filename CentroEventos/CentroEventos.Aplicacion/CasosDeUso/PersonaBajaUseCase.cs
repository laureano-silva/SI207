using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!auth.EstaAutorizado(idUsuario, Permiso.UsuarioBaja, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        var eventos = repoEvento.ListarEventoDeportivo();
        foreach (var evento in eventos)
        {
            if (evento.PersonaId == id)
            {
                throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene eventos deportivos asociados.");
            }
        }
        var reservas = repoReserva.ListarReserva();
        foreach (var reserva in reservas)
        {
            if (reserva.PersonaId == id)
            {
                throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene reservas asociadas.");
            }
        }
        repoPersona.EliminarPersona(id);
    }
}
