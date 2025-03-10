using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nature_Hub_Server.Models;
using Nature_Hub_Server.Repo;

namespace Nature_Hub_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepo _context;
        public ProductController(IProductRepo context)
        {

            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.GetAllProducts();
            if(products != null)
            {
                return Ok(products);
            }
            return NotFound();

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var product = await _context.GetProductById(id);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();

        }

        [HttpGet("/category/{category}")]
        public async Task<IActionResult> GetProductByCategory([FromRoute]string category)
        {
            var product = await _context.GetProductsByCategory(category);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] NatureProduct product)
        {
            var pro = await _context.AddProduct(product);
            return Created();

        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] NatureProduct product,[FromRoute]int id)
        {
            var pro = await _context.UpdateProduct(product,id);
            if(pro != null)
            return Ok(pro);
            else 
                return NotFound();

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            var pro = await _context.DeleteProduct(id);
            if (pro == true) return Ok();
            else return BadRequest();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductBySearch([FromRoute] string name)
        {
            var pro = await _context.GetProductsBySearch(name);

            if (pro != null) return Ok(pro);
            else return NotFound();
        }

        [HttpGet("/category/all")]
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
