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

public class GlobalCost{
    public decimal GetCostOfThis(ProductModel ThisProduct){
        decimal ItemCost = 0;
       
        if(ThisProduct != null){
            if(ThisProduct.ProductGrn.Any()){
                ItemCost = ThisProduct.ProductGrn.LastOrDefault().Cost;
            }
            else if(ThisProduct.ProductOpen.Any()){
                ItemCost = ThisProduct.ProductOpen.LastOrDefault().Cost;
            }
            else{
                ItemCost = 0;
            }
        }
        else{
            ItemCost = 0;
        }
        
        return ItemCost;
    }

    public decimal GetCostOfThis(ProductModel ThisProduct, DateOnly AtDate)
    {
        decimal ItemCost = 0;

        if (ThisProduct != null)
        {
            if (ThisProduct.ProductGrn.Any() && (ThisProduct.ProductGrn.Where(x => (DateOnly.FromDateTime(x.Grn.DateCreated)) <= AtDate).Any()))
            {
                ItemCost = ThisProduct.ProductGrn.Where(x => (DateOnly.FromDateTime(x.Grn.DateCreated)) <= AtDate).LastOrDefault().Cost;
            }
            else if (ThisProduct.ProductOpen.Any() && (ThisProduct.ProductOpen.Where(x => (DateOnly.FromDateTime(x.Open.DateCreated)) <= AtDate).Any()))
            {
                ItemCost = ThisProduct.ProductOpen.Where(x => (DateOnly.FromDateTime(x.Open.DateCreated)) <= AtDate).LastOrDefault().Cost;
            }
            else
            {
                ItemCost = 0;
            }
        }
        else
        {
            ItemCost = 0;
        }

        return ItemCost;
    }

    public double GetStockCostOfThis(ProductModel ThisProduct){
        double StockCost = 0;
        GlobalStock GS = new();
        
        if(ThisProduct != null){
            StockCost = (double)(GetCostOfThis(ThisProduct) * GS.GetStockOfThis(ThisProduct));
        }else{
            StockCost = 0.0;
        }
        
        return StockCost;
    }

    public decimal GetFullStockCost(){
        
        return 5;
    }
}