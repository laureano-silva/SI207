namespace Aplicacion;
public class ValidacionException : Exception
{
    public ValidacionException() : base("") {}
    public ValidacionException(string message) : base(message) {}

}