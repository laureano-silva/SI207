using Aplicacion;
using Repositorios;

// repositorios
var repoEvento = new RepositorioEventoDeportivo();
var repoPersona = new RepositorioPersona();
var repoReserva = new RepositorioReserva();
var context = new CentroEventosContext();
// inicializar base de datos
CentroEventosContext.Inicializar();

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
var modificarReserva = new ReservaModificacionUseCase(repoReserva, auth);
var bajaReserva = new ReservaBajaUseCase(repoReserva, auth);

var listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repoReserva, repoEvento, repoPersona);
var listarEventosConCupoDisponibleUseCase = new ListarEventosConCupoDisponibleUseCase(repoReserva, repoEvento);

// metodos
void EjecutarAlta<T>(Action<T, int> ejecutar, T objeto, int IdUsuario)
{
    try
    {
        ejecutar(objeto, IdUsuario);
        Console.WriteLine($"Alta de {typeof(T).Name} exitosa");
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
        Console.WriteLine($"Modificación de {typeof(T).Name} exitosa");
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
        Console.WriteLine($"Baja de {typeof(T).Name} exitosa");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

List<Persona> ListarAsistenciaAEvento(int idEvento)
{
    var lista = new List<Persona>();
    try
    {
        lista = listarAsistenciaAEvento.Ejecutar(idEvento);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    return lista;
}

List<EventoDeportivo> ListarEventosConCupo()
{
    var lista = new List<EventoDeportivo>();
    try
    {
        lista = listarEventosConCupoDisponibleUseCase.Ejecutar();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    return lista;
}

void ImprimirPersonas()
{   
    var listaPersonas = repoPersona.ListarPersona();
    if (!listaPersonas.Any())
    {
        Console.WriteLine("El repositorio está vacío");
    }
    else
    {
        Console.WriteLine("\n---------------------------------------\nContenido del repositorio de personas:");
        foreach (Persona p in listaPersonas)
        {
            Console.WriteLine(p.ToString() + "\n");
        }
        Console.WriteLine("---------------------------------------\n");
    }
}

void ImprimirEventos()
{
    var listaEventos = repoEvento.ListarEventoDeportivo();
    if (!listaEventos.Any())
    {
        Console.WriteLine("El repositorio está vacío");
    }
    else
    {
        Console.WriteLine("\n---------------------------------------\nContenido del repositorio de eventos:");
        foreach (EventoDeportivo e in listaEventos)
        {
            Console.WriteLine(e.ToString() + "\n");
        }
        Console.WriteLine("---------------------------------------\n");
    }
}

void ImprimirReservas()
{
    var listaReservas = repoReserva.ListarReserva();
    if (!listaReservas.Any())
    {
        Console.WriteLine("El repositorio está vacío");
    }
    else
    {
        Console.WriteLine("\n---------------------------------------\nContenido del repositorio de reservas:");
        foreach (Reserva r in listaReservas)
        {
            Console.WriteLine(r.ToString() + "\n");
        }
        Console.WriteLine("---------------------------------------\n");
    }
}

var evento1 = new EventoDeportivo{Nombre = "Futbol", Descripcion = "prueba evento 1",PersonaId = 1, FechaHoraInicio = new DateTime(2025, 10, 15, 10, 0, 0), CupoMaximo = 3, DuracionHoras = 2};
var evento2 = new EventoDeportivo{Nombre = "Basquet", Descripcion = "prueba evento 2", PersonaId = 2, FechaHoraInicio = new DateTime(2025, 10, 16, 10, 0, 0), CupoMaximo = 5, DuracionHoras = 1.5};

var reserva1 = new Reserva{PersonaId = 1, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva2 = new Reserva{PersonaId = 2, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva3 = new Reserva{PersonaId = 3, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva4 = new Reserva{PersonaId = 1, EventoDeportivoId = 2, EstadoAsistencia = EstadoAsistencia.Pendiente };
var reserva5 = new Reserva{PersonaId = 2, EventoDeportivoId = 2, EstadoAsistencia = EstadoAsistencia.Pendiente };

/////////////// PRUEBAS ///////////////

// alta de personas
var persona1 = new Persona{Nombre = "Juan", Apellido = "Perez", Dni = "12345678", Telefono = "123456789", Email = "juanperez@gmail.com"};
var persona2 = new Persona{Nombre = "Maria", Apellido = "Gomez", Dni = "42359604", Telefono = "987654321", Email = "mariagomez@yahoo.com.ar"};
var persona3 = new Persona{Nombre = "Pedro", Apellido = "Lopez", Dni = "35854806", Telefono = "123123123", Email = "pedrolopez@outlook.com"};

EjecutarAlta(altaPersona.Ejecutar, persona1, 1);
EjecutarAlta(altaPersona.Ejecutar, persona2, 1);
EjecutarAlta(altaPersona.Ejecutar, persona3, 1);
ImprimirPersonas();

// alta de eventos
EjecutarAlta(altaEventoDeportivo.Ejecutar, evento1, 1);
EjecutarAlta(altaEventoDeportivo.Ejecutar, evento2, 1);
ImprimirEventos();

// alta de reservas
EjecutarAlta(altaReserva.Ejecutar, reserva1, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva2, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva3, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva4, 1);
EjecutarAlta(altaReserva.Ejecutar, reserva5, 1);
ImprimirReservas();

//modificacion de persona
Console.WriteLine(repoPersona.ObtenerPersona(persona2.Id)?.ToString());
persona2.Email = "mariagomez@hotmail.com";
Console.WriteLine("\nPrueba modificando el email de la persona 2:");
EjecutarModificacion(modificarPersona.Ejecutar, persona2, 1);
Console.WriteLine(repoPersona.ObtenerPersona(persona2.Id)?.ToString());

//baja de reserva
Console.WriteLine("---------------------------------------\nPrueba eliminando la reserva5:");
EjecutarBaja<Reserva>(bajaReserva.Ejecutar, reserva5.Id, 1);
ImprimirReservas();

// imprimo eventos con cupo
var eventosConCupo = ListarEventosConCupo();
Console.WriteLine("---------------------------------------\nEventos con cupo disponible:");
foreach (EventoDeportivo evento in eventosConCupo)
{
    Console.WriteLine(evento.ToString());
}

// modifico EstadoAsistencia a Presente para 2 de las 3 reservas del evento1
reserva1.EstadoAsistencia = EstadoAsistencia.Presente;
reserva2.EstadoAsistencia = EstadoAsistencia.Presente;
EjecutarModificacion(modificarReserva.Ejecutar, reserva1, 1);
EjecutarModificacion(modificarReserva.Ejecutar, reserva2, 1);

// listo los asistentes al evento1
var asistentesAEvento = ListarAsistenciaAEvento(1);
Console.WriteLine("---------------------------------------\nAsistentes al evento 1:");
foreach (var persona in asistentesAEvento)
{
    Console.WriteLine(persona.ToString()+"\n-----------------------------");
}

// pruebas de validacion

// ResponsableId debe corresponder a una Persona existente. (Requiere consulta a
// IRepositorioPersona)

Console.WriteLine("Intentando guardar un evento con ResponsableId inexistente:");
evento1.PersonaId = 4; // no existe
EjecutarModificacion(modificarEventoDeportivo.Ejecutar, evento1, 1);

// DNI no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
var persona4 = new Persona { Nombre = "Juan", Apellido = "Gomez", Dni = "35854806", Telefono = "123456789", Email = "juangomez@aprobameprofe.com"};
Console.WriteLine("Intentando guardar una persona con DNI repetido:");
EjecutarAlta(altaPersona.Ejecutar, persona4, 1);

// No permitir que la misma Persona reserve dos veces el mismo EventoDeportivo (Requiere
// consulta a IRepositorioReserva)

Console.WriteLine("Intentando que una persona reserve el mismo evento dos veces:");
var reserva6 = new Reserva { PersonaId = 1, EventoDeportivoId = 1, EstadoAsistencia = EstadoAsistencia.Pendiente };
EjecutarAlta(altaReserva.Ejecutar, reserva6, 1);