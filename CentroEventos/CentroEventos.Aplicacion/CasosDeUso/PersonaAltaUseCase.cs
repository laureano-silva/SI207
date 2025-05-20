namespace Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Persona persona, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }
        try
        {
            validador.Validar(persona);
            repo.AgregarPersona(persona);
        }
        catch (DuplicadoException e)
        {
            throw new DuplicadoException(e.Message);
        }
        catch (ValidacionException e)
        {
            throw new ValidacionException(e.Message);
        }
    }
}
