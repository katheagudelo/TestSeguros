using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IDominioAutenticacion 
    {
        Task<Usuario> Registrar(Usuario usuario, String password);

        Task<Usuario> Login(String nombreUsuario, String password);

        Task<bool> UsuarioExiste(String username);
    }
}
