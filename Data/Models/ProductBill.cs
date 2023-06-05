using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductBill
{
    public int OldStock { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }

#nullable enable

    // FOREIGN KEYS
    [ForeignKey("ProductModel")]
    public int? ProductId { get; set; }
    public virtual ProductModel? Product { get; set; }

    [ForeignKey("BillModel")]
    public int? BillId { get; set; }
    public virtual BillModel? Bill { get; set; }

    //CTOR
    public ProductBill()
    {
        this.Price = 0;
        this.Qty = 0;
        this.OldStock = 0;
    }
}
