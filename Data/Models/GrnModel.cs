using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class GrnModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    [Required]
    public string Code { get; set; }
    public DateTime ReceiptDate { get; set; }

#nullable enable
    public string? ReceiptCode { get; set; }
    public string? Description { get; set; }

    //FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("SupplierModel")]
    public int? SupplierId { get; set; }
    public virtual SupplierModel? Supplier { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<ProductGrn>? ProductGrn { get; set; }

    //CTOR
    public GrnModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.ReceiptDate = DateTime.Now;
        this.ReceiptCode = null;
        this.Description = "Regular New Purchase";
        this.Code = "GRN";
    }
}
