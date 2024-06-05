using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_zaj10.Models;

[Table("Product_Categories")]
public class ProductCategory
{
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [ForeignKey("Category")]
    [Column("FK_category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
}