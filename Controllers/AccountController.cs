using APBD_zaj10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zaj10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController (IAccountService accountService) : ControllerBase
{
    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetAccountShoppingCartById(int accountId, CancellationToken cancellationToken)
    {
        var result = await accountService.
            GetAccountShoppingCartDetailsByIdAsync(accountId, cancellationToken);

        if (result is null)
        {
            return NotFound($"The account of id {accountId} does not exist.");
        }

        return Ok(result);
    }
}