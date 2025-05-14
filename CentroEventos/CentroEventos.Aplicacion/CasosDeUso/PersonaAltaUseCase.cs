namespace Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Persona persona, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioAlta, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }
        
        if (!validador.Validar(persona, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }

        repo.AgregarPersona(persona);
    }
}
