using AccesoDatos.Modelos;
using CapaDatos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class AutenticacionDominio : IDominioAutenticacion
    {
        private readonly IAutenticacion _autenticacion;

        public AutenticacionDominio(IAutenticacion autenticacion)
        {
            this._autenticacion = autenticacion;
        }

        public Task<Usuario> Login(string nombreUsuario, string password)
        {
           return this._autenticacion.Login(nombreUsuario, password);
        }

        public Task<Usuario> Registrar(Usuario usuario, string password)
        {
           return this._autenticacion.Registrar(usuario, password);
        }

        public Task<bool> UsuarioExiste(string username)
        {
            return this._autenticacion.UsuarioExiste(username);
        }
    }
}
