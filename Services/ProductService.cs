using APBD_zaj10.Contexts;
using APBD_zaj10.DTOs;
using APBD_zaj10.Exceptions;
using APBD_zaj10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_zaj10.Services;

public interface IProductService
{
    public Task AddProductWithCategoriesAsync(ProductWithCategoriesDTO product, CancellationToken cancellationToken);
}

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task AddProductWithCategoriesAsync(ProductWithCategoriesDTO product, CancellationToken cancellationToken)
    {
        var productToAdd = new Product()
        {
            ProductName = product.ProductName,
            ProductWeight = product.ProductWeight,
            ProductWidth = product.ProductWidth,
            ProductHeight = product.ProductHeight,
            ProductDepth = product.ProductDepth
        };
        await context.AddAsync(productToAdd, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        var productId = productToAdd.ProductId;
        foreach (var categoryId in product.ProductCategories)
        {
            var category = await context.Categories.SingleOrDefaultAsync(c => 
                c.CategoryId == categoryId, cancellationToken);
            if (category is null)
            {
                throw new CategoryNotFoundException($"Category with id {categoryId} does not exist");
            }

            await context.ProductCategories.AddAsync(new ProductCategory()
            {
                ProductId = productId,
                CategoryId = category.CategoryId
            }, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}