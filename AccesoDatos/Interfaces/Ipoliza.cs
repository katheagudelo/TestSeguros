using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface Ipoliza
    {
        Task<Poliza> Crear(Poliza poliza);

        Task<Poliza> Editar(int id, Poliza poliza);

        Task<bool> Eliminar(int id);

        Task<Poliza> ObtenerPoliza(int id);

        Task<List<Poliza>> ObtenerPolizas();
    }
}
