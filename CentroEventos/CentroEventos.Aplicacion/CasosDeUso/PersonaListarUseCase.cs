namespace Aplicacion;

public class PersonaListarUseCase(IRepositorioPersona repositorioPersona)
{

    public List<Persona> Ejecutar()
    {
        List<Persona> personas = repositorioPersona.ListarPersona();
        if (personas.Count == 0)
        {
            throw new EntidadNotFoundException("No hay personas registradas.");
        }
        return personas;
    }

}
      
