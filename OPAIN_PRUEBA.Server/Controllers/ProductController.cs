using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPAIN_PRUEBA.Server.Models;
using OPAIN_PRUEBA.Server.Template;

namespace OPAIN_PRUEBA.Server.Controllers
{
    public class ProductController : ControllerBase
    {
        private OpainDbContext _context;

        //Diego: Inicializar el contexto
        public ProductController(OpainDbContext context)
        {
            _context = context;
        }

        [HttpPost(template: "AddProducto")]
        public async Task<IActionResult> Guardar([FromBody] ProductsRequest productsRequest)
        {
            try
            {
                var dataParam = new Products
                {
                    NAME = productsRequest.NAME,
                    DESCRIPTION = productsRequest.DESCRIPTION,
                    PRICE = productsRequest.PRICE,
                    CREATEDAT = DateTime.Now
                };

                _context.Products.Add(dataParam);
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Productos guardados" });
            }
            catch (Exception ex) { 
                return BadRequest(new { mensaje = $"Se presentó un error {ex.Message}"});
            }
        }

        [HttpGet(template: "GetProduct")]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                var findProducts = await _context.Products.ToListAsync();

                if (findProducts.Count == 0)
                {
                    return NotFound(new { mensaje = "Productos no encontrados" });
                }

                return Ok(findProducts);
            }
            //Diego: En caso de presentarse una excepción
            catch (Exception ex) { 
                return BadRequest(new { mensaje = $"Se presentó un error {ex.Message}" });
            }
        }

        [HttpGet(template: "GetProduct/{id}")]
        public async Task<IActionResult> ObtenerId(int id)
        {
            try
            {
                var findProduct = await _context.Products.FindAsync(id);

                if (findProduct == null)
                {
                    return NotFound(new { mensaje = "Producto no encontrado" });
                }

                return Ok(await _context.Products.FindAsync(id));
            }
            //Diego: En caso de presentarse una excepción
            catch (Exception ex) { 
                return BadRequest(new { mensaje = $"Se presentó un error {ex.Message}"});
            }
        }

        [HttpPut(template: "UpdateProduct/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] ProductsRequest productsRequest) {
            try
            {
                var findProduct = await _context.Products.FindAsync(id);

                if (findProduct==null)
                {
                    return NotFound(new { mensaje = $"Producto no encontrado" });
                }

                findProduct.NAME = productsRequest.NAME;
                findProduct.DESCRIPTION = productsRequest.DESCRIPTION;
                findProduct.PRICE = productsRequest.PRICE;
                findProduct.CREATEDAT = DateTime.Now;

                _context.Products.Update(findProduct);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = "Producto actualizado"});
            }
            catch (Exception ex) { 
                return BadRequest(new { mensaje = $"Se presentó un error {ex.Message}" });
            }
        }

        [HttpDelete(template: "Delete/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var findProduct = await _context.Products.FindAsync(id);
                if (findProduct == null)
                {
                    return NotFound(new { mensaje = "Producto no encontrado" });
                }

                _context.Remove(findProduct);
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Producto eliminado"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Se presentó un error" });
            }
        }
    }
}
