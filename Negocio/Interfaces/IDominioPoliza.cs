using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IDominioPoliza
    {
        Task<Poliza> Crear(Poliza poliza);

        Task<Poliza> Editar(int id, Poliza poliza);

        Task<bool> Eliminar(int id);

        Task<Poliza> ObeterPoliza(int id);

        Task<List<Poliza>> ObetnerPolizas();

        bool ValidarRiesgoAlto(Poliza poliza);
    }
}
