namespace Aplicacion;
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