namespace Aplicacion;

public class PersonaModificacionUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Persona persona, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioModificacion, out string errorAutorizacion))
        {
            throw new AutorizacionException(errorAutorizacion);
        }

        if (!validador.Validar(persona, out string errorValidacion))
        {
            throw new ValidacionException(errorValidacion);
        }
        if (!repo.ExistePersona(persona.Id))
        {
            throw new RepositorioException("La persona no se encuentra en el repositorio.");
        }
        repo.ModificarPersona(persona);
    }
}