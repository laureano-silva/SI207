namespace Aplicacion;
public class AutorizacionException : Exception
{
    public AutorizacionException() : base("Error de autorizacion.") {}
    public AutorizacionException(string message) : base(message) {}

}