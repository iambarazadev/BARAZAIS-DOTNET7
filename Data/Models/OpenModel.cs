using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class OpenModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    [Required]
    public string Code { get; set; }

#nullable enable
    public string? Description { get; set; }

    // FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<ProductOpen>? ProductOpen { get; set; }

    // CTOR
    public OpenModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.Code = "OSID";
        this.Description = null;
    }
}
