namespace APBD_zaj10.DTOs;

public class ProductWithCategoriesDTO
{
    public string ProductName { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public decimal ProductDepth { get; set; }
    public List<int> ProductCategories { get; set; }
}