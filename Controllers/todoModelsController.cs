using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class todoModelsController : ControllerBase
    {
        private readonly todocontext _context;

        public todoModelsController(todocontext context)
        {
            _context = context;
        }

        // GET: api/todoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<todoModels>>> Getitems()
        {
            return await _context.items.ToListAsync();
        }

        // GET: api/todoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<todoModels>> GettodoModels(long id)
        {
            var todoModels = await _context.items.FindAsync(id);

            if (todoModels == null)
            {
                return NotFound();
            }

            return todoModels;
        }

        // PUT: api/todoModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttodoModels(long id, todoModels todoModels)
        {
            if (id != todoModels.id)
            {
                return BadRequest();
            }

            _context.Entry(todoModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!todoModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/todoModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<todoModels>> PosttodoModels(todoModels todoModels)
        {
            _context.items.Add(todoModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettodoModels", new { id = todoModels.id }, todoModels);
        }

        // DELETE: api/todoModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<todoModels>> DeletetodoModels(long id)
        {
            var todoModels = await _context.items.FindAsync(id);
            if (todoModels == null)
            {
                return NotFound();
            }

            _context.items.Remove(todoModels);
            await _context.SaveChangesAsync();

            return todoModels;
        }

        private bool todoModelsExists(long id)
        {
            return _context.items.Any(e => e.id == id);
        }
    }
}
