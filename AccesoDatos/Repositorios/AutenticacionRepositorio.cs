using AccesoDatos.Modelos;
using CapaDatos.Data;
using CapaDatos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class AutenticacionRepositorio : IAutenticacion
    {
        private readonly DataContext _context;

        public AutenticacionRepositorio(DataContext context)
        {
            this._context = context;
        }

        public async Task<Usuario> Login(string username, string password)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.NombreUsuario == username);
            if (user == null)
            {
                return null;
            }

            if (!VericarPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<Usuario> Registrar(Usuario usuario, string password)
        {
            byte[] passwordhash, passwordSalt;
            CrearPasswordHash(password, out passwordhash, out passwordSalt);
            usuario.PasswordHash = passwordhash;
            usuario.PasswordSalt = passwordSalt;
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;

        }

        public async Task<bool> UsuarioExiste(string username)
        {
            if (await _context.Usuarios.AnyAsync(x => x.NombreUsuario == username))
            {
                return true;
            }

            return false;
        }

        private bool VericarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computerdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerdHash.Length; i++)
                {
                    if (computerdHash[i] != passwordHash[i])
                        return false;
                }

            }
            return true;


        }


        private void CrearPasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

    }

}
