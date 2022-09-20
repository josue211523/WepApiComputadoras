using Microsoft.AspNetCore.Mvc;
using WepApiComputadoras.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WepApiComputadoras.Controllers
{
    [ApiController]
    [Route("api/caracteristicas")]
    public class CaracteristicasController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CaracteristicasController(ApplicationDbContext Context)
        {
            this.dbContext = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Caracteristicas>>> GetAll()
        {
            return await dbContext.Caracteristicas.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Caracteristicas caracteristicas)
        {
            var existeComputadora = await dbContext.Computadoras.AnyAsync(x => x.Id == caracteristicas.ComputadoraId);
            if (!existeComputadora)
            {
                return BadRequest($"No existe el alumno con el id: {caracteristicas.ComputadoraId}");
            }
            dbContext.Add(caracteristicas);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Caracteristicas caracteristicas, int id)
        {
            var exist = await dbContext.Caracteristicas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("La caracteristica no existe");
            }
            if (caracteristicas.Id != id)
            {
                return BadRequest("El id de la computadora no coincide con el establecido con la url");
            }
            dbContext.Update(caracteristicas);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id;int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Caracteristicas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
            }
            dbContext.Remove(new Caracteristicas { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }



    }
}
