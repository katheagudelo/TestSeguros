using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{
    public interface IAutenticacion
    {
        Task<Usuario> Registrar(Usuario usuario, String password);

        Task<Usuario> Login(String nombreUsuario, String password);

        Task<bool> UsuarioExiste(String username);
    }
}
