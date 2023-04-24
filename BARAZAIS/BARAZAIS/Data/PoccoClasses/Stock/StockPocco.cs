using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.PoccoClasses.Stock;

public class StockPoccoModel{
#nullable enable
    public int StockAdjustmentId {get;set;}
    public string? StockAdjustmentCode{get;set;}
    
    [Required(ErrorMessage = "Required"), MaxLength(50), MinLength(2), DataType(DataType.Text)]
    public string? StockAdjumentsReasons{get;set;}
    
    public int? ProductId {get;set;}
    public string ProductCode {get;set;}
    public string ProductCaption {get;set;}
    public int QtyAdjusted{get;set;}
    public int? NewStock{get;set;}
    public int? OldStock{get;set;}
    public decimal Cost{get;set;}
    public decimal Retail{get;set;}

    //ctor

    public StockPoccoModel()
    {
        this.StockAdjustmentId = default;
        this.Cost = 0;
        this.Retail = 0;
        this.NewStock = null;
        this.OldStock = null;
        this.QtyAdjusted = 0;
        this.ProductCaption = "";
        this.StockAdjumentsReasons = null;
        this.StockAdjustmentCode = null;
        this.ProductCode = "";

    }
    
}