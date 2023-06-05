using System;
using System.ComponentModel.DataAnnotations;
namespace BARAZAIS.Data.PoccoClasses.Pos;

public class PosPoccoModel{
    public int Qty{get;set;}
    public decimal Price{get;set;}
    public decimal Cost {get;set;}
    public int ProductId {get;set;}
    public string Code {get;set;}
    public string Caption {get;set;}
    public int? HoldId {get;set;}
    
    public PosPoccoModel(){
        this.Qty = 0;
        this.Price = 0;
        this.Cost = 0;
        this.ProductId = 0;
        this.Code = "";
        this.Caption = "";
        this.HoldId = null;
    }
}