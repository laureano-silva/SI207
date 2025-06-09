using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion;
public interface IRepositorioUsuario
{
    public void AgregarUsuario(Usuario usuario);

    public void EliminarUsuario(int id);

    public void ModificarUsuario(Usuario usuario);
    
    public bool ExisteUsuario(int id);
    public Usuario? ObtenerUsuario(int id);
    List<Usuario> ListarUsuario();
}
