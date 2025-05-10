namespace Aplicacion;
public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException() : base("placeholder") {}
    public EntidadNotFoundException(string message) : base(message) {}

}