﻿using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioObtenerPorIdUseCase(IRepositorioUsuario repo)
{
    public Usuario Ejecutar(int usuarioId)
    {
        var usuarioActual = repo.ObtenerUsuario(usuarioId);
        if (usuarioActual is null)
        {
            throw new EntidadNotFoundException("Usuario no encontrado.");           
        }

        return repo.ObtenerPorId(usuarioId)!;
    }
}
