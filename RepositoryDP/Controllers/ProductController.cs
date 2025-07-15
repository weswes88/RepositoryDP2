using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;
using RepositoryDP.Service.ProductService;

namespace RepositoryDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService ProductService;
        public ProductController(IProductService _ProductService)
        {
            ProductService = _ProductService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO DTO)
        {
            await ProductService.AddProduct(DTO);
            return Ok("OK");
        }
        [HttpPut("UpdateProduct{id}")]
        public void UpdateProduct([FromRoute] int id , [FromBody]UpdateProductDTO updateProductDTO)
        {
            ProductService.UpdateProduct(id, updateProductDTO);
        }
        [HttpDelete("DeleteProduct{id}")]
        public void DeleteProduct([FromRoute] int id)
        {
            ProductService.DeleteProduct(id);
        }
    }
}
