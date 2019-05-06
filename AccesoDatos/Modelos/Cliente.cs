using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Modelos
{
    public class Cliente
    {
        public int Id  { get; set; }

        public string NombresCliente { get; set; }

        public string Apellidoscliente { get; set; }

        public string Identificacion { get; set; }

        public virtual Poliza  PolizaAdquirida { get; set; }

    }
}
