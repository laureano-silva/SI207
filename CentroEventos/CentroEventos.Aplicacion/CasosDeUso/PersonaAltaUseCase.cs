namespace Aplicacion;

public class PersonaAltaUseCase(IRepositorioPersona repo, PersonaValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Persona persona, int userID)
    {
        if (!auth.EstaAutorizado(userID, Permiso.UsuarioAlta, out string errorAutorizacion))
        {
            throw new FalloAutorizacionException(errorAutorizacion);
        }

        var resultado = validador.Validar(persona);

        switch (resultado.Codigo)
        {
            case CodigoValidacion.SinErrores:
                break;

            case CodigoValidacion.DuplicadoError:
               throw new DuplicadoException(resultado.Mensaje);

            case CodigoValidacion.ValidacionError:
                throw new ValidacionException(resultado.Mensaje);

            default:
                throw new Exception("Código de validación no reconocido.");
        }

        repo.AgregarPersona(persona);
    }
}
