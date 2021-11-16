using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vk.Context;
using vk.Mod;

namespace vk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRtoesController : ControllerBase
    {
        private readonly UserRtoContext _context;

        public UserRtoesController(UserRtoContext context)
        {
            _context = context;
        }

        // GET: api/UserRtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRto>>> GetUserRtos()
        {
            return await _context.UserRtos.ToListAsync();
        }

        // GET: api/UserRtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRto>> GetUserRto(int id)
        {
            var userRto = await _context.UserRtos.FindAsync(id);

            if (userRto == null)
            {
                return NotFound();
            }

            return userRto;
        }

        // PUT: api/UserRtoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRto(int id, UserRto userRto)
        {
            if (id != userRto.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRtoExists(id))
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

        // POST: api/UserRtoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRto>> PostUserRto(UserRto userRto)
        {
            _context.UserRtos.Add(userRto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRto", new { id = userRto.Id }, userRto);
        }

        // DELETE: api/UserRtoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRto>> DeleteUserRto(int id)
        {
            var userRto = await _context.UserRtos.FindAsync(id);
            if (userRto == null)
            {
                return NotFound();
            }

            _context.UserRtos.Remove(userRto);
            await _context.SaveChangesAsync();

            return userRto;
        }

        private bool UserRtoExists(int id)
        {
            return _context.UserRtos.Any(e => e.Id == id);
        }
    }
}
