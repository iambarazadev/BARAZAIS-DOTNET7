using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.PoccoClasses.Open;

public class OpenPoccoModel{

#nullable enable
    public decimal? Cost{get;set;}
    public decimal? Retail{get;set;}
    public int? Qty{get;set;}
    public decimal? LatestPrice{get;set;}
    public int? ProductId {get;set;}
    public string? ProductCode {get;set;}
    public string Caption {get;set;}
    public string? Description {get;set;}
    
    public OpenPoccoModel()
    {
        this.ProductCode = null;
        this.Caption = "";
        this.ProductId = null;
        this.LatestPrice = null;
        this.Qty = null;
        this.Cost= null;
        this.Description = null;
        this.Retail = null;
    }
}