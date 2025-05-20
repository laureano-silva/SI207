using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Aplicacion;
using Microsoft.Win32.SafeHandles;
namespace Repositorios;
public class RepositorioReserva(string filename) : IRepositorioReserva
{
    private readonly string _fileName = filename;
    private int ultId = 1;
    private int GenerarId() => ultId++;
    public void AgregarReserva(Reserva p)
    {
        p.Id = GenerarId();

        using (var sw = new StreamWriter(_fileName, true))
        {
            sw.WriteLine(p.Id);
            sw.WriteLine(p.PersonaId);
            sw.WriteLine(p.EventoDeportivoId);
            sw.WriteLine(p.FechaAltaReserva);
            sw.WriteLine(p.EstadoAsistencia);
        }
    }
  
    public void EliminarReserva(int id)
    {
        List<Reserva> reservas = ListarReserva();
        if (reservas is null)
        {
            throw new EntidadNotFoundException("El repositorio esta vacio.");
        }
        List<Reserva> aux = new List<Reserva>();
        foreach (Reserva r in reservas)
        {
            if (r.Id != id) aux.Add(r);
        }
        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (Reserva r in aux)
            {
            sw.WriteLine(r.Id);
            sw.WriteLine(r.PersonaId);
            sw.WriteLine(r.EventoDeportivoId);
            sw.WriteLine(r.FechaAltaReserva);
            sw.WriteLine(r.EstadoAsistencia);
            }
        }
    }

    public bool ExisteReserva(int id)
    {
        List<Reserva> reserva = ListarReserva();
        foreach (Reserva r in reserva)
        {
            if (r.Id == id) return true;
        }
        return false;
    }

/// Listar todas las reservas
    public List<Reserva> ListarReserva()
    {
        var lista = new List<Reserva>();

        using var sr = new StreamReader(_fileName);
        while (!sr.EndOfStream)
        {
            var r = new Reserva();
                        
            r.Id = int.Parse(sr.ReadLine() ?? "0");
            r.PersonaId = int.Parse(sr.ReadLine() ?? "0");
            r.EventoDeportivoId = int.Parse(sr.ReadLine() ?? "0");
            r.FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? "");
            r.EstadoAsistencia = Enum.Parse<EstadoAsistencia>(sr.ReadLine() ?? "");
            lista.Add(r);
        }
        return lista;
    }

    /// Listar reservas por persona
        public List<Reserva> ListarReserva(int idPersona)
    {
        List<Reserva> reservas = ListarReserva();
        List<Reserva> reservasPersona = new List<Reserva>();
        foreach (Reserva r in reservas)
        {
            if (r.PersonaId == idPersona)
            {
                reservasPersona.Add(r);
            }
        }
        return reservasPersona;
    }

    public void ModificarReserva(Reserva reserva)
    {
        if (!ExisteReserva(reserva.Id))
        {
            throw new EntidadNotFoundException("La reserva no se encuentra en el repositorio.");
        }
        List<Reserva> reservas = ListarReserva();
        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (Reserva r in reservas)
            {
                if (r.Id == reserva.Id)
                {
                    r.EstadoAsistencia = reserva.EstadoAsistencia;
                }
                sw.WriteLine(r.Id);
                sw.WriteLine(r.PersonaId);
                sw.WriteLine(r.EventoDeportivoId);
                sw.WriteLine(r.FechaAltaReserva);
                sw.WriteLine(r.EstadoAsistencia);
            }
        }
    }

    public Reserva? ReservaPorId(int id)
    {
        List<Reserva> reservas = ListarReserva();
        foreach (Reserva r in reservas)
        {
            if (r.Id == id)
            {
                return r;
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
