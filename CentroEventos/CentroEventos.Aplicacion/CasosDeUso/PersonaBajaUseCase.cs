namespace Aplicacion;

public class PersonaBajaUseCase(IRepositorioPersona repo, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioBaja, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
              
       repo.EliminarPersona(id);
    }
}
