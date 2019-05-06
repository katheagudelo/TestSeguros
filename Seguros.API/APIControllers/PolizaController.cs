using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatos.Dtos;
using AccesoDatos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Negocio.Interfaces;

namespace Seguros.APIControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IDominioPoliza _dominioPoliza;
        private readonly IConfiguration _configuracion;

        public PolizaController(IDominioPoliza dominioPoliza, IConfiguration configuracion)
        {
            this._dominioPoliza = dominioPoliza;
            this._configuracion = configuracion;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Crear(PolizaCrear poliza)
        {
            var polizaCrear = new Poliza
            {
                Nombre = poliza.Nombre,
                Descripcion = poliza.Descripcion,
                TipoCubrimiento = poliza.TipoCubrimiento,
                InicioVigencia = poliza.InicioVigencia,
                Periodo = poliza.Periodo,
                PrecioPoliza = poliza.PrecioPoliza,
                Cobertura = poliza.Cobertura,
                TipoRiesgo = poliza.TipoRiesgo
            };

            if (this._dominioPoliza.ValidarRiesgoAlto(polizaCrear))
            {
                await _dominioPoliza.Crear(polizaCrear);

                return StatusCode(201);
            }
            else
            {
                return BadRequest("La cobertura no debe ser superior al 50 %");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtenerpoliza(int id)
        {
            var poliza = await this._dominioPoliza.ObeterPoliza(id);
            return Ok(poliza);
        }


        [HttpGet("obtenerPolizas")]
        public async Task<IActionResult> ObtenerPolizas()
        {
            var polizas = await this._dominioPoliza.ObetnerPolizas();
            return Ok(polizas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> editar(int id, PolizaCrear poliza)
        {
            var polizaEdit = new Poliza
            {
                Nombre = poliza.Nombre,
                Descripcion = poliza.Descripcion,
                TipoCubrimiento = poliza.TipoCubrimiento,
                InicioVigencia = poliza.InicioVigencia,
                Periodo = poliza.Periodo,
                PrecioPoliza = poliza.PrecioPoliza,
                Cobertura = poliza.Cobertura,
                TipoRiesgo = poliza.TipoRiesgo
            };
            var polizaEditada = await this._dominioPoliza.Editar(id, polizaEdit);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminar(int id)
        {
            return Ok(await this._dominioPoliza.Eliminar(id));
        }

    }
}