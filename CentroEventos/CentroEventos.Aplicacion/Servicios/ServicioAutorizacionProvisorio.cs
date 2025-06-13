namespace CentroEventos.Aplicacion.Servicios;

using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces;
public class ServicioAutorizacionProvisorio: IServicioAutorizacion
{
    public bool EstaAutorizado(int id, Permiso permiso, out string message)
    {
        message = "";
        if (id != 1)
        {
            message = "Error de autorizacion.\n";
        }
        return (message == "");
    }
}