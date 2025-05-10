namespace Aplicacion;
public class ValidacionException : Exception
{
    public ValidacionException() : base("placeholder") {}
    public ValidacionException(string message) : base(message) {}

}