using AccesoDatos.Dtos;
using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using Microsoft.Extensions.Configuration;
using Negocio.Interfaces;
using Negocio.Servicios;
using NUnit.Framework;
using Seguros.APIControllers;
using System;

namespace Tests
{
    public class Tests
    {
        public Ipoliza poliza { get; set; }

        public IDominioPoliza dominio { get; set; }

        public IConfiguration confi { get; set; }
        public Poliza NewPoliza { get; set; }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ValidarCreacionPolzaRiesgoAlto()
        {
            this.NewPoliza = new Poliza
            {
                Nombre = "prueba",
                Descripcion = "poliza de vida",
                Cobertura = 60,
                TipoCubrimiento = "Muerte",
                InicioVigencia = DateTime.Now,
                Periodo = 12,
                PrecioPoliza = 100000,
                TipoRiesgo = 1
            };

            PolizaDomminio polizaDominio = new PolizaDomminio(this.poliza);
            Assert.False( polizaDominio.ValidarRiesgoAlto(this.NewPoliza));

        }

        
}
}