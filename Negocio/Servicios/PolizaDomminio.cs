using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class PolizaDomminio : IDominioPoliza
    {
        private readonly Ipoliza _poliza;       

        public PolizaDomminio(Ipoliza poliza)
        {
            this._poliza = poliza;          
        }

        public async Task<Poliza> Crear(Poliza poliza)
        {

            return await this._poliza.Crear(poliza);
        }

        public async Task<Poliza> Editar(int id, Poliza poliza)
        {
            return await this._poliza.Editar(id, poliza);
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await this._poliza.Eliminar(id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Poliza> ObeterPoliza(int id)
        {
            return await this._poliza.ObtenerPoliza(id);
        }

        public async Task<List<Poliza>> ObetnerPolizas()
        {
            return await this._poliza.ObtenerPolizas();
        }

        public bool ValidarRiesgoAlto(Poliza poliza)
        {
            if (poliza.TipoRiesgo == 1 && poliza.Cobertura > 50)
            {
                return false;
            }

            return true;
        }
    }
}
