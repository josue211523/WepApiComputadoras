using Microsoft.AspNetCore.Mvc;
using WepApiComputadoras.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WepApiComputadoras.Controllers
{
    [ApiController]
    [Route("api/computadoras")]
    public class ComputadorasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ComputadorasController(ApplicationDbContext Context)
        {
            this.dbContext = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Computadora>>> Get()
        {
            return await dbContext.Computadoras.Include(x=> x.Caracteristicas).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Computadora computadora)
        {
            dbContext.Add(computadora);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Computadora computadora, int id)
        {
            if (computadora.Id != id)
            {
                return BadRequest("El id de la computadora no coincide con el establecido");
            }
            dbContext.Update(computadora);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id;int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Computadoras.AnyAsync(x =>x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Computadora { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
