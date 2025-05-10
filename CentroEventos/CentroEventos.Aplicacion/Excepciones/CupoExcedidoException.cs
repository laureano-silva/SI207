namespace Aplicacion;
public class CupoExcedidoException : Exception
{
    public CupoExcedidoException() : base("placeholder") {}
    public CupoExcedidoException(string message) : base(message) {}

}