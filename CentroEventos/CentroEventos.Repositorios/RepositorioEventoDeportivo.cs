using Aplicacion;
namespace Repositorios;
public class RepositorioEventoDeportivo(string filename) : IRepositorioEventoDeportivo
{
    private readonly string _fileName = filename;
    private int ultId = 0;
    private int GenerarID() => ultId++;
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        e.Id = GenerarID();
        using (var sw = new StreamWriter(_fileName, true))
        {
            sw.WriteLine(e.Id);
            sw.WriteLine(e.Nombre);
            sw.WriteLine(e.Descripcion);
            sw.WriteLine(e.FechaHoraInicio);
            sw.WriteLine(e.DuracionHoras);
            sw.WriteLine(e.CupoMaximo);
            sw.WriteLine(e.ResponsableId);
        }
    }

    public void EliminarEventoDeportivo(int id)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        if (eventos is null)
        {
            throw new RepositorioException("El repositorio esta vacio.");
        }
        List<EventoDeportivo> aux = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in eventos)
        {
            if (e.Id != id) aux.Add(e);
        }
        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (EventoDeportivo e in eventos)
            {
                sw.WriteLine(e.Id);
                sw.WriteLine(e.Nombre);
                sw.WriteLine(e.Descripcion);
                sw.WriteLine(e.FechaHoraInicio);
                sw.WriteLine(e.DuracionHoras);
                sw.WriteLine(e.CupoMaximo);
                sw.WriteLine(e.ResponsableId);
            }
        }
    }
     
    public bool ExisteEventoDeportivo(int id)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        foreach (EventoDeportivo p in eventos)
        {
            if (p.Id == id) return true;
        }
        return false;
    }

    public List<EventoDeportivo> ListarEventoDeportivo()
    {
        var eventos = new List<EventoDeportivo>();

        using var sr = new StreamReader(_fileName);
        while (!sr.EndOfStream)
        {
            var e = new EventoDeportivo();
                        
            e.Id = int.Parse(sr.ReadLine() ?? "0");
            e.Nombre = sr.ReadLine() ?? "";
            e.Descripcion = sr.ReadLine() ?? "";
            e.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            e.DuracionHoras = double.Parse(sr.ReadLine() ?? "0");
            e.CupoMaximo = int.Parse(sr.ReadLine() ?? "0");
            e.ResponsableId = int.Parse(sr.ReadLine() ?? "0");
            eventos.Add(e);
        }
        return eventos;
    }   

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        if (!ExisteEventoDeportivo(evento.Id))
        {
            throw new RepositorioException("La Persona no se encuentra en el repositorio.");
        }
        List<EventoDeportivo> eventos = ListarEventoDeportivo();

        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (EventoDeportivo e in eventos)
            {
                if (e.Id == evento.Id)
                {
                    e.Nombre = evento.Nombre;
                    e.Descripcion = evento.Descripcion;
                    e.FechaHoraInicio = evento.FechaHoraInicio;
                    e.DuracionHoras = evento.DuracionHoras;
                    e.CupoMaximo = evento.CupoMaximo;
                    e.ResponsableId = evento.ResponsableId;
                }
                sw.WriteLine(e.Id);
                sw.WriteLine(e.Nombre);
                sw.WriteLine(e.Descripcion);
                sw.WriteLine(e.FechaHoraInicio);
                sw.WriteLine(e.DuracionHoras);
                sw.WriteLine(e.CupoMaximo);
                sw.WriteLine(e.ResponsableId);
            }
        }
    }

    public EventoDeportivo? ObtenerEventoDeportivo(int id)
    {
        List<EventoDeportivo> eventos = ListarEventoDeportivo();
        foreach (EventoDeportivo e in eventos)
        {
            if (e.Id == id) 
            {
                return e;
            }
        }
        return null;
    }

    public void Inicializar()
    {
        if (File.Exists(_fileName))
        {
            File.WriteAllText(_fileName, String.Empty);
        }
        else
        {
            File.Create(_fileName).Dispose();
        }
    }
}