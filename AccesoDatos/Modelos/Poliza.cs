using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Modelos
{
    public class Poliza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string TipoCubrimiento { get; set; }

        public DateTime InicioVigencia { get; set; }

        public int Periodo { get; set; }

        public double PrecioPoliza { get; set; }

        public double Cobertura { get; set; }

        public  int TipoRiesgo { get; set; }


    }

}
