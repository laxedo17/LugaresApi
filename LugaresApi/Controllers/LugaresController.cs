using LugaresApi.Db;
using LugaresApi.Db.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LugaresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugaresController : ControllerBase
    {
        private readonly LugarDbContext _dbContext;
        private readonly IHubContext<LugarApiHub> _hubContext;

        public LugaresController(LugarDbContext dbContext, IHubContext<LugarApiHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult GetLugaresFavoritos()
        {
            var lugares = _dbContext.Lugares.OrderByDescending(o => o.Valoracions).Take(10);
            return Ok(lugares);
        }

        [HttpPost]
        public IActionResult CrearNovoLugar([FromBody] Lugar lugar)
        {
            var novoId = _dbContext.Lugares.Select(o => o.Id).Max() + 1;
            lugar.Id = novoId;
            lugar.UltimaActualizacion = DateTime.Now;

            _dbContext.Lugares.Add(lugar);
            int filasAfectadas = _dbContext.SaveChanges();

            if (filasAfectadas > 0)
            {
                _hubContext.Clients.All.SendAsync("NotifyNewLugarAdded", lugar.Id, lugar.Nome);
            }

            return Ok("Novo lugar engadido con exito");
        }

        [HttpPut]
        public IActionResult ActualizarLugar([FromBody] Lugar lugar)
        {
            var actualizacionLugar = _dbContext.Lugares.Find(lugar.Id);
            if (actualizacionLugar == null)
            {
                return NotFound();
            }

            actualizacionLugar.Nome = lugar.Nome;
            actualizacionLugar.Localizacion = lugar.Localizacion;
            actualizacionLugar.Acerca = lugar.Acerca;
            actualizacionLugar.Valoracions = lugar.Valoracions;
            actualizacionLugar.ImaxeDatos = lugar.ImaxeDatos;
            actualizacionLugar.UltimaActualizacion = DateTime.Now;

            _dbContext.Update(actualizacionLugar);
            _dbContext.SaveChanges();

            return Ok("Actualizaronse os datos do lugar correctamente");
        }
    }
}
