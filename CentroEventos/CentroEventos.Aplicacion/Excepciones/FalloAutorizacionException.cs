namespace Aplicacion;
public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException() : base("") {}
    public FalloAutorizacionException(string message) : base(message) {}

}