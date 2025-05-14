using Aplicacion;
using Repositorios;

// repositorios
IRepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo("eventos.txt");
IRepositorioPersona repoPersona = new RepositorioPersona("personas.txt");
IRepositorioReserva repoReserva = new RepositorioReserva("reservas.txt");

// servicios
IServicioAutorizacion auth = new ServicioAutorizacionProvisorio();
EventoDeportivoValidador validadorEvento = new EventoDeportivoValidador(repoPersona);
PersonaValidador validadorPersona = new PersonaValidador(repoPersona);
ReservaValidador validadorReserva = new ReservaValidador(repoReserva, repoPersona, repoEvento);

// casos de uso
var altaPersona = new PersonaAltaUseCase(repoPersona, validadorPersona, auth);
var modificarPersona = new PersonaModificacionUseCase(repoPersona, validadorPersona, auth);
var bajaPersona = new PersonaBajaUseCase(repoPersona, auth);

var altaEventoDeportivo = new EventoDeportivoAltaUseCase(repoEvento, validadorEvento, auth);
var modificarEventoDeportivo = new EventoDeportivoModificacionUseCase(repoEvento, validadorEvento, auth);
var bajaEventoDeportivo = new EventoDeportivoBajaUseCase(repoEvento, auth);

var altaReserva = new ReservaAltaUseCase(repoReserva, validadorReserva, auth);
var modificarReserva = new ReservaModificacionUseCase(repoReserva, validadorReserva, auth);
var bajaReserva = new ReservaBajaUseCase(repoReserva, auth);

var listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repoReserva, repoEvento, repoPersona);

// metodos
void EjecutarAlta<T>(Action<T, int> ejecutar, T objeto, int IdUsuario)
{
    try
    {
        ejecutar(objeto, IdUsuario);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void EjecutarModificacion<T>(Action<T, int> ejecutar, T objeto, int idUsuario)
{
    try
    {
        ejecutar(objeto, idUsuario);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void EjecutarBaja<T>(Action<int, int> ejecutar, int id, int idUsuario)
{
    try
    {
        ejecutar(id, idUsuario);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// faltaria hacer que retorne el nombre de la persona?
void ListarAsistenciaAEvento(int idEvento)
{
    try
    {
        var lista = listarAsistenciaAEvento.Ejecutar(idEvento);
        foreach (var reserva in lista)
        {
            Console.WriteLine(reserva);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}