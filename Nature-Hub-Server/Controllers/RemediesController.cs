using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nature_Hub_Server.Models;
using Nature_Hub_Server.Repo;

namespace Nature_Hub_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemediesController : ControllerBase
    {
        IRemedyRepo _context;
        public RemediesController(IRemedyRepo context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRemedies()
        {
            var tips = await _context.GetAllRemedy();
            if (tips != null)
            {
                return Ok(tips);
            }
            return NotFound();

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRemedyById([FromRoute] int id)
        {
            var tip = await _context.GetRemedyById(id);
            if (tip != null)
            {
                return Ok(tip);
            }
            return NotFound();

        }

        [HttpGet("/category/remedy/{category}")]
        public async Task<IActionResult> GetRemediesByCategory([FromRoute] string category)
        {
            var tips = await _context.GetRemedyByCategory(category);
            if (tips != null)
            {
                return Ok(tips);
            }
            return NotFound();
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRemedy([FromBody] Remedy remedy)
        {
            var pro = await _context.AddRemedy(remedy);
            return Created();

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRemedy([FromBody] Remedy remedy, [FromRoute] int id)
        {
            var tip2 = await _context.UpdateRemedy(remedy, id);
            if (tip2 != null)
                return Ok(tip2);
            else
                return NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemedy([FromRoute] int id)
        {
            var tip = await _context.DeleteRemedy(id);
            if (tip == true) return Ok();
            else return BadRequest();
        }


        [HttpGet("/category/remedy/all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _context.GetAllCategories();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
    }
}
