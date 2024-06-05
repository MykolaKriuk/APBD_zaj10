using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_zaj10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string ProductName { get; set; }
    
    [Column("weight", TypeName = "decimal(5, 2)")]
    public decimal ProductWeight { get; set; }
    
    [Column("width", TypeName = "decimal(5, 2)")]
    public decimal ProductWidth { get; set; }
    
    [Column("height", TypeName = "decimal(5, 2)")]
    public decimal ProductHeight { get; set; }
    
    [Column("depth", TypeName = "decimal(5, 2)")]
    public decimal ProductDepth { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    
    public ICollection<ProductCategory> ProductCategories { get; set; }
}