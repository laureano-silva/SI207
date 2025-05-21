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

    public bool EsEmailUnico(Persona persona)
    {
        var listaPersona = _repositorio.ListarPersona();
        return !listaPersona.Any(p =>
            !string.IsNullOrEmpty(p.Email) &&
            p.Email.Equals(persona.Email, StringComparison.OrdinalIgnoreCase) && p.Id != persona.Id);
    }

    public bool EsDNIUnico(Persona persona)
    {
        var listaPersona = _repositorio.ListarPersona();
        return !listaPersona.Any(p =>
            p.Dni.Equals(persona.Dni) && p.Id != persona.Id);
    }


    public void Validar(Persona persona)
    {
        if (string.IsNullOrEmpty(persona.Nombre))
        {
            throw new ValidacionException("El nombre no puede estar vacio");
        }
        if (string.IsNullOrEmpty(persona.Apellido))
        {
            throw new ValidacionException("El apellido no puede estar vacio");
        }
        if (string.IsNullOrEmpty(persona.Dni))
        {
            throw new ValidacionException("El DNI no puede estar vacío");
        }
        if (string.IsNullOrEmpty(persona.Email))
        {
            throw new ValidacionException("El email no puede estar vacío");
        }
        if (!this.EsEmailUnico(persona))
        {
            throw new DuplicadoException("El email no puede estar repetido");   
        }
        if (!this.EsDNIUnico(persona))
        {
            throw new DuplicadoException("El DNI no puede estar repetido");
        }
    }

}