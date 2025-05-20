using Aplicacion;
using Repositorios;

// repositorios
var repoEvento = new RepositorioEventoDeportivo("eventos.txt");
var repoPersona = new RepositorioPersona("personas.txt");
var repoReserva = new RepositorioReserva("reservas.txt");
repoEvento.Inicializar();
repoPersona.Inicializar();
repoReserva.Inicializar();

// servicios
IServicioAutorizacion auth = new ServicioAutorizacionProvisorio();
EventoDeportivoValidador validadorEvento = new EventoDeportivoValidador(repoPersona);
PersonaValidador validadorPersona = new PersonaValidador(repoPersona);
ReservaValidador validadorReserva = new ReservaValidador(repoReserva, repoPersona, repoEvento);

// casos de uso
var altaPersona = new PersonaAltaUseCase(repoPersona, validadorPersona, auth);
var modificarPersona = new PersonaModificacionUseCase(repoPersona, validadorPersona, auth);
var bajaPersona = new PersonaBajaUseCase(repoPersona, repoEvento, repoReserva, auth);

var altaEventoDeportivo = new EventoDeportivoAltaUseCase(repoEvento, validadorEvento, auth);
var modificarEventoDeportivo = new EventoDeportivoModificacionUseCase(repoEvento, validadorEvento, auth);
var bajaEventoDeportivo = new EventoDeportivoBajaUseCase(repoEvento, repoReserva, auth);

var altaReserva = new ReservaAltaUseCase(repoReserva, validadorReserva, auth);
var modificarReserva = new ReservaModificacionUseCase(repoReserva, validadorReserva, auth);
var bajaReserva = new ReservaBajaUseCase(repoReserva, auth);

var listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repoReserva, repoEvento, repoPersona);
var listarEventosConCupoDisponibleUseCase = new ListarEventosConCupoDisponibleUseCase(repoReserva, repoEvento);

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
    Console.WriteLine($"Alta de {typeof(T).Name} exitosa");
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
    Console.WriteLine($"Modificación de {typeof(T).Name} exitosa");
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
    Console.WriteLine($"Baja de {typeof(T).Name} exitosa");}

void ListarAsistenciaAEvento(int idEvento)
{
    try
    {
        var lista = listarAsistenciaAEvento.Ejecutar(idEvento);
        Console.WriteLine($"Asistentes al evento {idEvento}:");
        foreach (Persona p in lista)
        {
            Console.WriteLine(p.ToString());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

List<EventoDeportivo> EventosConCupo()
{
    return listarEventosConCupoDisponibleUseCase.Ejecutar(); 
}



/*
 
Un EventoDeportivo no puede tener más Reservas que su CupoMaximo.
 
Una Persona no puede tener más de una Reserva para el mismo EventoDeportivo.
 
No puede modificarse un EventoDeportivo cuya FechaHoraInicio haya expirado (es decir, no puede
modificarse un evento pasado).
 
Al crear o modificar un EventoDeportivo, no puede establecerse la FechaHoraInicio con un valor
anterior al actual (es decir que sólo se permite si la fecha que va a registrarse es >= fecha actual).
 
No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
(independientemente del estado de las reservas).
 
No puede eliminarse una Persona si es responsable de algún EventoDeportivo o si existen reservas
asociadas a ella (independientemente del estado de las reservas).

*/


// instancio las diferentes clases


var evento1 = new EventoDeportivo{Nombre = "Futbol", FechaHoraInicio = new DateTime(2025, 10, 15, 10, 0, 0), CupoMaximo = 3, DuracionHoras = 2};
var evento2 = new EventoDeportivo{Nombre = "Basquet", FechaHoraInicio = new DateTime(2025, 10, 16, 10, 0, 0), CupoMaximo = 5, DuracionHoras = 1.5};

var persona1 = new Persona{Nombre = "Juan", Apellido = "Perez", DNI = 12345678, Telefono = 123456789, Email = "juanperez@gmail.com"};
var persona2 = new Persona{Nombre = "Maria", Apellido = "Gomez", DNI = 42359604, Telefono = 987654321, Email = "mariagomez@hotmail.com"};
var persona3 = new Persona{Nombre = "Pedro", Apellido = "Lopez", DNI = 35854806, Telefono = 123123123, Email = "pedrolopez@outlook.com"};


var reserva1 = new Reserva{PersonaId = 1, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente};
var reserva2 = new Reserva {PersonaId = 2, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva3 = new Reserva {PersonaId = 3, EventoDeportivoId = 2, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva4 = new Reserva {PersonaId = 1, EventoDeportivoId = 2, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva5 = new Reserva {PersonaId = 2, EventoDeportivoId = 2, EstadoAsistencia = EstadoAsistencia.Pendiente };

/////////////// PRUEBAS ///////////////

// alta de personas
EjecutarAlta(altaPersona.Ejecutar, persona1, 1);
EjecutarAlta(altaPersona.Ejecutar, persona2, 1);
EjecutarAlta(altaPersona.Ejecutar, persona3, 1);

// alta de eventos
EjecutarAlta(altaEventoDeportivo.Ejecutar, evento1, 1);
EjecutarAlta(altaEventoDeportivo.Ejecutar, evento2, 1);

// alta de reservas
EjecutarAlta(altaReserva.Ejecutar, reserva1, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva2, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva3, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva4, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva5, 1);

// eventos con cupo
