public class RepositorioException : Exception
{
    public RepositorioException() : base("Error del repositorio.") { }
    public RepositorioException(string message) : base(message) { }
}
