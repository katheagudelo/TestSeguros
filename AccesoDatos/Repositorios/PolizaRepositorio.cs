using AccesoDatos.Interfaces;
using AccesoDatos.Modelos;
using CapaDatos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class PolizaRepositorio : Ipoliza
    {
        private readonly DataContext _context;

        public PolizaRepositorio(DataContext context)
        {
            this._context = context;
        }
        public async Task<Poliza> Crear(Poliza poliza)
        {
            this._context.Attach(poliza).State = EntityState.Added;
            await this._context.Polizas.AddAsync(poliza);
            await _context.SaveChangesAsync();

            return poliza;
        }

        public async Task<Poliza> Editar(int id, Poliza poliza)
        {
            var polizaEdidt = this._context.Polizas.Find(id);
            polizaEdidt.Nombre = poliza.Nombre;
            polizaEdidt.Descripcion = poliza.Descripcion;
            polizaEdidt.TipoCubrimiento = poliza.TipoCubrimiento;
            polizaEdidt.InicioVigencia = poliza.InicioVigencia;
            polizaEdidt.Periodo = poliza.Periodo;
            polizaEdidt.PrecioPoliza = poliza.PrecioPoliza;
            polizaEdidt.Cobertura = poliza.Cobertura;
            polizaEdidt.TipoRiesgo = poliza.TipoRiesgo;
            this._context.Attach(polizaEdidt).State = EntityState.Modified;
            this._context.Update(polizaEdidt);
            await this._context.SaveChangesAsync();

            return poliza;
        }

        public async Task<bool> Eliminar(int id)
        {
            var poliza = this._context.Polizas.Find(id);
            this._context.Attach(poliza).State = EntityState.Deleted;
            this._context.Polizas.Remove(poliza);
            await this._context.SaveChangesAsync();

            return true;
        }

        public async Task<Poliza> ObtenerPoliza(int id)
        {
            var poliza = await this._context.Polizas.FindAsync(id);
            if (poliza == null)
            {
                return null;
            }

            return poliza;
        }

        public async Task<List<Poliza>> ObtenerPolizas()
        {
            var polizas = await this._context.Polizas.ToListAsync();
            return polizas;
        }
    }
}
