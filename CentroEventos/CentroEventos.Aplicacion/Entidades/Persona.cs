using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion;

public class Persona
{
    public int Id { get; set; }
    public  string Nombre { get; set; } = "";
    public  string Apellido { get; set; } = "";
    public string Dni { get; set; } = "";
    public int Telefono { get; set; }
    public string Email { get; set; } = "";


    public Persona()
    {
    }

    public Persona ( string nombre, string apellido, string dni, int telefono, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Telefono = telefono;
        Email = email;
    }

    public override string ToString()
    {
        return $" Nombre: {Nombre}\n Apellido: {Apellido}\n DNI: {Dni}\n Telefono:{Telefono}\n Email: {Email}";
    }

}
