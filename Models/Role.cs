using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_zaj10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int RoleId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string RoleName { get; set; }
    
    public ICollection<Account> Accounts { get; set; }
}