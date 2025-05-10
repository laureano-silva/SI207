namespace Aplicacion;
public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException() : base("placeholder") {}
    public FalloAutorizacionException(string message) : base(message) {}

}