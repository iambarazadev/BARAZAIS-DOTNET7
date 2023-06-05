using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class HoldModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    [Required]
    public string Code { get; set; }

#nullable enable
    public string? Status {get;set;}
    // FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public virtual CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<ProductHold>? ProductHold { get; set; }

    // CTOR
    public HoldModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.Code = "HID";
        this.Status = null;
    }
}

