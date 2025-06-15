using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioAltaUseCase(IRepositorioUsuario repo, UsuarioValidador validador, IServicioAutorizacion auth)
{
    public void Ejecutar(Usuario usuario)
    {
        var resultado = validador.Validar(usuario);

        switch (resultado.Codigo)
        {
            case CodigoValidacion.SinErrores:
                break;

            case CodigoValidacion.DuplicadoError:
               throw new DuplicadoException(resultado.Mensaje);

            case CodigoValidacion.ValidacionError:
                throw new ValidacionException(resultado.Mensaje);

            default:
                throw new Exception("Codigo de validacion no reconocido.");
        }
      repo.AgregarUsuario(usuario);
    }
}