using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Aplicacion;
using Microsoft.Win32.SafeHandles;
namespace Repositorios;
public class RepositorioPersona(string filename) : IRepositorioPersona
{
    private readonly string _fileName = filename;
    private int ultID = 1;
    private int GenerarID() => ultID++;

      
    public void AgregarPersona(Persona p)
    {
        p.Id = GenerarID();

        using (var sw = new StreamWriter(_fileName, true))
        {
            sw.WriteLine(p.Id);
            sw.WriteLine(p.Nombre);
            sw.WriteLine(p.Apellido);
            sw.WriteLine(p.Email);
            sw.WriteLine(p.Dni);
            sw.WriteLine(p.Telefono);
            
        }
    }
    public void EliminarPersona(int id)
    {
        List<Persona> personas = ListarPersona();
        if (personas is null)
        {
            throw new EntidadNotFoundException("El repositorio esta vacio.");
        }
        List<Persona> aux = new List<Persona>();
        foreach (Persona p in personas)
        {
            if (p.Id != id) aux.Add(p);
        }
        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (Persona p in aux)
            {
                sw.WriteLine(p.Id);
                sw.WriteLine(p.Nombre);
                sw.WriteLine(p.Apellido);
                sw.WriteLine(p.Email);
                sw.WriteLine(p.Dni);
                sw.WriteLine(p.Telefono);
            }
        }
    }

    public bool ExistePersona(int id)
    {
        List<Persona> persona = ListarPersona();
        foreach (Persona p in persona)
        {
            if (p.Id == id) return true;
        }
        return false;
    }

    public List<Persona> ListarPersona()
    {
        var lista = new List<Persona>();

        using var sr = new StreamReader(_fileName);
        while (!sr.EndOfStream)
        {
            var p = new Persona();
                        
            p.Id = int.Parse(sr.ReadLine() ?? "0");
            p.Nombre = sr.ReadLine() ?? "";
            p.Apellido = sr.ReadLine() ?? "0";
            p.Email = sr.ReadLine() ?? "";
            p.Dni = sr.ReadLine() ?? "0";
            p.Telefono = int.Parse(sr.ReadLine() ?? "0");

            lista.Add(p);
        }
        sr.Close();
        return lista;
    }   

    public void ModificarPersona(Persona persona)
    {
        if (!ExistePersona(persona.Id))
        {
            throw new EntidadNotFoundException("La Persona no se encuentra en el repositorio.");
        }
        List<Persona> personas = ListarPersona();

        using (var sw = new StreamWriter(_fileName, false))
        {
            foreach (Persona p in personas)
            {
                if (p.Id == persona.Id)
                {
                    p.Nombre = persona.Nombre;
                    p.Apellido = persona.Apellido;
                    p.Email = persona.Email;
                    p.Dni = persona.Dni;
                    p.Telefono = persona.Telefono;
                }
                sw.WriteLine(p.Id);
                sw.WriteLine(p.Nombre);
                sw.WriteLine(p.Apellido);
                sw.WriteLine(p.Email);
                sw.WriteLine(p.Dni);
                sw.WriteLine(p.Telefono);
            }
        }
    }

    public Persona? ObtenerPersona(int id)
    {
        List<Persona> personas = ListarPersona();
        foreach (Persona p in personas)
        {
            if (p.Id == id)
            {
                return p;
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
