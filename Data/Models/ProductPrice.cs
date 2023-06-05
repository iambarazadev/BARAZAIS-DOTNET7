using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductPrice
{
    public decimal OldPrice { get; set; }
    public int OldStock { get; set; }
    public decimal LatestPrice { get; set; }
    public decimal Cost { get; set; }
    public int QtyClosed { get; set; }

#nullable enable

    //FOREIGN KEYS
    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public ProductModel? Product { get; set; }

    [ForeignKey("PriceModel")]
    public int? PriceId { get; set; }
    public PriceModel? Price { get; set; }

    //CTOR
    public ProductPrice()
    {
        this.OldPrice = 0;
        this.LatestPrice = 0;
        this.Cost = 0;
        this.QtyClosed = 0;
        this.OldStock = 0;
    }
}
