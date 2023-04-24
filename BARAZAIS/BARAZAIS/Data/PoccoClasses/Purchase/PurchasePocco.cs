using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.PoccoClasses.Purchase;

public class PurchasePoccoModel{
    [Required(ErrorMessage = "Required")]
    [DataType(DataType.Currency)]
    public decimal ReceiptAmount { get; set; }
    public DateTime ReceiptDate { get; set; }

#nullable enable
    [Required(ErrorMessage = "Required")]
    public string? ReceiptCode { get; set; }
    public int? SupplierId { get; set; }
    [Required(ErrorMessage = "Required")]
    public int? QtyPurchased { get; set; }
    public int? OldStock { get; set; }
    [Required(ErrorMessage = "Required")]
    public decimal? Cost { get; set; }
    public decimal? OldPrice { get; set; }
    [Required(ErrorMessage = "Required")]
    public decimal? LatestPrice { get; set; }
    public int? ProductId { get; set; }
    public string? ProductCode { get; set; }
    public string? ProductCaption { get; set; }
    [DataType(DataType.Text)]
    public string? Description { get; set; }

    // ctor
    public PurchasePoccoModel()
    {
        this.ReceiptAmount = 0;
        this.ReceiptDate = DateTime.Now;
        this.ReceiptCode = null;
        this.SupplierId = null;
        this.QtyPurchased = null;
        this.OldStock = null;
        this.Cost = null;
        this.OldPrice = null;
        this.LatestPrice = null;
        this.ProductId = null;
        this.ProductCaption = null;
        this.Description = null;
        this.ProductCode = null;
    }
}