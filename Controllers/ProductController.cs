using APBD_zaj10.DTOs;
using APBD_zaj10.Exceptions;
using APBD_zaj10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zaj10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProductWithCategories(ProductWithCategoriesDTO product,
        CancellationToken cancellationToken)
    {
        try
        {
            await productService.AddProductWithCategoriesAsync(product, cancellationToken);
        }
        catch (CategoryNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return Created();
    }
}