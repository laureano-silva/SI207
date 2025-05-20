namespace Aplicacion;

public class PersonaModificacionUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Persona persona, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioModificacion, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        try
        {
            validador.Validar(persona);
            repo.ModificarPersona(persona);
        }
        catch (ValidacionException e)
        {
            throw new ValidacionException(e.Message);
        }
        catch (DuplicadoException e)
        {
            throw new DuplicadoException(e.Message);
        }
        catch (EntidadNotFoundException e)
        {
            throw new EntidadNotFoundException(e.Message);
        }
    }
}