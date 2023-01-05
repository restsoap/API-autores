using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    //decorador para validaciones
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        //llamamos el servicio de la base de datos 
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        //cuando hacemos peticiones a la Db debemos usar async
        //nombre del metodo va luego del ActionResult

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //con el include agregamos los registros de otra tabla
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        //usamos los context para llamar la instalcia de la Db
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();   
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/algo
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //vamos a la tabla autores y verificamos si existe el id
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            //instanciamos un objeto de tipo autor  new Autor()
            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
