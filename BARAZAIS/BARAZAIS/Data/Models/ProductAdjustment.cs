using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductAdjustment
{
    public int OldStock { get; set; }
    public int QtyAdjusted { get; set; }
    public int NewStock { get; set; }
    public decimal Cost { get; set; }
    public decimal Retail { get; set; }

#nullable enable

    // FOREIGN KEYS
    [ForeignKey("AdjustmentModel")]
    public int? AdjustmentId { get; set; }
    public virtual AdjustmentModel? Adjustment { get; set; }

    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public virtual ProductModel? Product { get; set; }

    //CTOR
    public ProductAdjustment()
    {
        this.OldStock = 0;
        this.QtyAdjusted = 0;
        this.NewStock = 0;
        this.Cost = 0;
        this.Retail = 0;
    }
}

