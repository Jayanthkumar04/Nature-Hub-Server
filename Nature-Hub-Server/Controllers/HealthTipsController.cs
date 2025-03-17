using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nature_Hub_Server.Models;
using Nature_Hub_Server.Repo;

namespace Nature_Hub_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthTipsController : ControllerBase
    {
          ITips _context;
        public HealthTipsController(ITips context)
        {

            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllTips()
        {
            var tips = await _context.GetAllTips();
            if (tips != null)
            {
                return Ok(tips);
            }
            return NotFound();

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTipById([FromRoute] int id)
        {
            var tip = await _context.GetTipById(id);
            if (tip != null)
            {
                return Ok(tip);
            }
            return NotFound();

        }

        [HttpGet("/category/tips/{category}")]
        public async Task<IActionResult> GetTipsByCategory([FromRoute] string category)
        {
            var tips = await _context.GetTipsByCategory(category);
            if (tips != null)
            {
                return Ok(tips);
            }
            return NotFound();
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTip([FromBody] HealthTip tip)
        {
            var pro = await _context.AddTip(tip);
            return Created();

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTip([FromBody] HealthTip tip, [FromRoute] int id)
        {
            var tip2 = await _context.UpdateTip(tip, id);
            if (tip2 != null)
                return Ok(tip2);
            else
                return NotFound();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTip([FromRoute] int id)
        {
            var tip = await _context.DeleteTip(id);
            if (tip == true) return Ok();
            else return BadRequest();
        }


        [HttpGet("/category/tips/all")]
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
