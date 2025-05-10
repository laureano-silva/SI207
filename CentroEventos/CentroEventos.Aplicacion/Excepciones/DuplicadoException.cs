namespace Aplicacion;
public class DuplicadoException : Exception
{
    public DuplicadoException() : base("placeholder") {}
    public DuplicadoException(string message) : base(message) {}

}