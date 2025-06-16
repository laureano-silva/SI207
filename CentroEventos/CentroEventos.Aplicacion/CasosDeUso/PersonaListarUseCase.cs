using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaListarUseCase(IRepositorioPersona repositorioPersona)
{

    public List<Persona> Ejecutar()
    {
        List<Persona> personas = repositorioPersona.ListarPersona();
      
        return personas;
    }

}
      
