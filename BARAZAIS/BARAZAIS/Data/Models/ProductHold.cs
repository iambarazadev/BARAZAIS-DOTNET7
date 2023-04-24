using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductHold
{
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }

#nullable enable

    // FOREIGN KEYS
    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public virtual ProductModel? Product { get; set; }

    [ForeignKey("HoldModel")]
    public int? HoldId { get; set; }
    public virtual HoldModel? Hold { get; set; }

    //CTOR
    public ProductHold()
    {
        this.Qty = 0;
        this.Price = 0;
    }
}
