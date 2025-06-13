
using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Repositorios;
public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> Eventos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public CentroEventosContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.db");
    }
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }
}