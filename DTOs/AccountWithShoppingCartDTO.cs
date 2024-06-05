namespace APBD_zaj10.DTOs;

public class AccountWithShoppingCartDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNum { get; set; }
    public string Role { get; set; }
    public List<ProductToAccountDTO> Products { get; set; }
}

public class ProductToAccountDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
}