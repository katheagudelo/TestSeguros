using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Dtos
{
    public class PolizaCrear
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string TipoCubrimiento { get; set; }

        public DateTime InicioVigencia { get; set; }

        public int Periodo { get; set; }

        public double PrecioPoliza { get; set; }

        public  int TipoRiesgo { get; set; }

        public double Cobertura { get; set; }
    }
}
