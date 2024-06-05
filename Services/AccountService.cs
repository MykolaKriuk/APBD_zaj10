using APBD_zaj10.Contexts;
using APBD_zaj10.DTOs;
using APBD_zaj10.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_zaj10.Services;

public interface IAccountService
{
    public Task<AccountWithShoppingCartDTO?> GetAccountShoppingCartDetailsByIdAsync(int id,
        CancellationToken cancellationToken);
}

public class AccountService (DatabaseContext databaseContext) : IAccountService
{
    public async Task<AccountWithShoppingCartDTO?> GetAccountShoppingCartDetailsByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await databaseContext.Accounts.Where(a => a.AccountId == id)
            .Select(a => new AccountWithShoppingCartDTO()
            {
                FirstName = a.AccountFirstName,
                LastName = a.AccountLastName,
                Email = a.AccountEmail,
                PhoneNum = a.AccountPhoneNumber,
                Role = a.Role.RoleName,
                Products = a.ShoppingCarts
                    .Select(sc => new ProductToAccountDTO()
                    {
                        ProductId = sc.Product.ProductId,
                        ProductName = sc.Product.ProductName,
                        Amount = sc.Amount
                    }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);
    }
}