using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductOpen
{
    public decimal Cost { get; set; }
    public int Qty { get; set; }

#nullable enable
    // FOREIGN KEYS
    [ForeignKey("OpenModel")]
    public int? OpenId { get; set; }
    public virtual OpenModel? Open { get; set; }

    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public virtual ProductModel? Product { get; set; }

    //CTOR
    public ProductOpen()
    {
        this.Cost = 0;
        this.Qty = 0;
    }
}
