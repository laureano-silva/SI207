namespace Aplicacion;
public class ValidacionException : Exception
{
    public ValidacionException() : base("Error de validacion, revise los datos ingresados.") {}
    public ValidacionException(string message) : base(message) {}

}