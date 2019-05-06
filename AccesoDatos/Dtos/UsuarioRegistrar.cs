using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccesoDatos.Dtos
{
    public class UsuarioRegistrar
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Debe especificar una contraseña entre 4 y 8 caracteres")]
        public string Password { get; set; }
    }
}
