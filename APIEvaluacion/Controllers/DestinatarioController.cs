using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APIEvaluacion.Context;
using APIEvaluacion.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace APIEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinatarioController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public DestinatarioController (ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Destinatario>> Get()
        {
            return context.Destinatario.Include(x => x.Paquetes).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerDestinatario")]
        public ActionResult<Destinatario> Get(int id)
        {
            var destinatario = context.Destinatario.Include(x => x.Paquetes).FirstOrDefault(x => x.Id == id);
            if (destinatario == null)
            {
                return NotFound();
            }
            return destinatario;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Destinatario destinatario)
        {
            context.Destinatario.Add(destinatario);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerDestinatario", new { id = destinatario.Id }, destinatario);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Destinatario destinatario, int id)
        {
            if (id != destinatario.Id) 
            { 
                return BadRequest();
            }
            context.Entry(destinatario).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Destinatario> Delete(int id)
        {
            var destinatario = context.Destinatario.FirstOrDefault(x => x.Id == id);
            if (destinatario == null)
            {
                return NotFound();
            }
            context.Entry(destinatario).State = EntityState.Deleted;
            context.SaveChanges();
            return destinatario;
        }
    }
}
