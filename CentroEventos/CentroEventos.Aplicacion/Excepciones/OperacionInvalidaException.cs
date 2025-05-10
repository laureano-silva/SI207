namespace Aplicacion;
public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException() : base("placeholder") {}
    public OperacionInvalidaException(string message) : base(message) {}

}