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

public class GlobalStock{
    public int GetStockOfThis(ProductModel ThisProduct){
        int TotalItemStock = 0;
        
        if(ThisProduct != null){
            ThisProduct = ThisProduct;
            TotalItemStock = (int)((ThisProduct.ProductGrn.Any() ? ThisProduct.ProductGrn.Sum(a => a.QtyPurchased) : 0) + (int)(ThisProduct.ProductAdjustment.Any() ? ThisProduct.ProductAdjustment.Sum(b => b.QtyAdjusted) : 0) + (int)(ThisProduct.ProductOpen.Any() ? ThisProduct.ProductOpen.Sum(x => x.Qty) : 0)) - (((ThisProduct.ProductBill.Any() ? ThisProduct.ProductBill.Sum(a => a.Qty) : 0)));
        }
        else{
            ThisProduct = new();
            TotalItemStock = 0;
        }
        
        return TotalItemStock;
    }

    public int GetStockOfThis(ProductModel ThisProduct, DateOnly AtDate)
    {
        int TotalItemStock = 0;

        if (ThisProduct != null)
        {
            ThisProduct = ThisProduct;
            TotalItemStock = (int)((ThisProduct.ProductGrn.Any() ? ThisProduct.ProductGrn.Where(x => (DateOnly.FromDateTime(x.Grn.DateCreated)) <= AtDate).Sum(a => a.QtyPurchased) : 0) + (int)(ThisProduct.ProductAdjustment.Any() ? ThisProduct.ProductAdjustment.Where(x => (DateOnly.FromDateTime(x.Adjustment.DateCreated)) <= AtDate).Sum(b => b.QtyAdjusted) : 0) + (int)(ThisProduct.ProductOpen.Any() ? ThisProduct.ProductOpen.Where(x => (DateOnly.FromDateTime(x.Open.DateCreated)) <= AtDate).Sum(x => x.Qty) : 0)) - (((ThisProduct.ProductBill.Any() ? ThisProduct.ProductBill.Where(x => (DateOnly.FromDateTime(x.Bill.DateCreated)) <= AtDate).Sum(a => a.Qty) : 0)));
        }
        else
        {
            ThisProduct = new();
            TotalItemStock = 0;
        }

        return TotalItemStock;
    }

    public int GetFullStock(){
        
        return 5;
    }
}