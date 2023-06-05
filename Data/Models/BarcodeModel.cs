using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class BarcodeModel
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }

#nullable enable
    public string? Scan { get; set; }

    // FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public virtual ProductModel? Product { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public virtual CompanyModel? Company { get; set; }

    //CTOR
    public BarcodeModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.Scan = null;
    }
}
