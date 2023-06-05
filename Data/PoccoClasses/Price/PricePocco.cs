using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.PoccoClasses.Price;

public class PricePoccoModel{

    public int PriceId { get; set; }
    public string ProductCaption {get;set;}
    public int OldStock{get;set;}
#nullable enable
    public string? PriceCode{get;set;}
    public string? Description{get;set;}
    public int? ProductId {get;set;}
    public string? ProductCode {get;set;}
    public decimal? OldPrice{get;set;}
    public decimal? LatestPrice{get;set;}
    public decimal? Cost{get;set;}
    
    //ctor
    public PricePoccoModel(){
        
        this.PriceCode = null;
        this.Description = null;
        this.ProductId = null;
        this.ProductCode = null;
        this.ProductCaption = "";
        this.OldPrice = null;
        this.LatestPrice = null;
        this.Cost = null;
        this.OldStock = 0;
        
    }
    
}