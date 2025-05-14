using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion;


public class PersonaValidador
{
    private readonly IRepositorioPersona _repositorio;

    public PersonaValidador(IRepositorioPersona repositorio)
    {
        _repositorio = repositorio;
    }

    public bool EsEmailUnico(string email)
    {
        var listaPersona = _repositorio.ListarPersona();


        return !listaPersona.Any(p =>
            !string.IsNullOrEmpty(p.Email) &&
            p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public bool EsDNIUnico(int dni)
    {
        var listaPersona = _repositorio.ListarPersona();


        return !listaPersona.Any(p =>

            p.DNI.Equals(dni));
    }


    public bool Validar(Persona persona, out string message)
    {
        message = "";
        if (string.IsNullOrEmpty(persona.Nombre))
        {
            message = "El nombre no puede estar vacio.\n";
        }
        if (string.IsNullOrEmpty(persona.Apellido))
        {
            message = "El apellido no puede estar vacio.\n";
        }
        if (persona.DNI <= 0)
        {
            message = "El DNI no puede estar vacio.\n";
        }
        if (string.IsNullOrEmpty(persona.Email))
        {
            message = "El Email no puede estar vacio.\n";
        }

        
        if (!this.EsEmailUnico(persona.Email))
        {
            message = "El Email no puede estar repetido.\n";
        }

        if (!this.EsDNIUnico(persona.DNI))
        {
            message = "El DNI no puede estar repetido.\n";
        }


        
        return message == "";

    }

}