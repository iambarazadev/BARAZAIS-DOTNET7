using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
namespace BARAZAIS.Data.Mappers;

public class GlobalRetail{
    public decimal GetRetailOfThis(ProductModel ThisProduct){
        decimal ItemRetail = 0;
       
        if(ThisProduct != null){
            if(ThisProduct.ProductPrice.Any()){
                ItemRetail = ThisProduct.ProductPrice.LastOrDefault().LatestPrice;
            }
            else{
                ItemRetail = 0;
            }
        }
        else{
            ItemRetail = 0;
        }
        
        return ItemRetail;
    }

    public decimal GetRetailOfThis(ProductModel ThisProduct, DateOnly AtDate)
    {
        decimal ItemRetail = 0;

        if (ThisProduct != null)
        {
            if (ThisProduct.ProductPrice.Any() && ThisProduct.ProductPrice.Where(x => (DateOnly.FromDateTime(x.Price.DateCreated)) <= AtDate).Any())
            {
                ItemRetail = ThisProduct.ProductPrice.Where(x => (DateOnly.FromDateTime(x.Price.DateCreated)) <= AtDate).LastOrDefault().LatestPrice;
            }
            else
            {
                ItemRetail = 0;
            }
        }
        else
        {
            ItemRetail = 0;
        }

        return ItemRetail;
    }

    public double GetStockRetailOfThis(ProductModel ThisProduct){
        double StockRetail = 0;
        GlobalStock GS = new();
        
        if(ThisProduct != null){
            StockRetail = (double)(GetRetailOfThis(ThisProduct) * GS.GetStockOfThis(ThisProduct));
        }else{
            StockRetail = 0.0;
        }
        
        return StockRetail;
    }

    public decimal GetFullStockRetail(){
        
        return 5;
    }
}