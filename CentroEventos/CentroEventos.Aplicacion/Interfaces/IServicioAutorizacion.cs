namespace Aplicacion;
public interface IServicioAutorizacion{
    public bool EstaAutorizado(int id, Permiso permiso, out string message);
}