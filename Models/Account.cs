using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_zaj10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    
    [ForeignKey("Role")]
    [Column("FK_role")]
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string AccountFirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string AccountLastName { get; set; }
    
    [Column("email")]
    [MaxLength(80)]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string AccountEmail { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    public string AccountPhoneNumber { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}