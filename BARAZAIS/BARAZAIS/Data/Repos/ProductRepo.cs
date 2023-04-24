using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class ProductRepo : BaseRepo<ProductModel> , IProductService
{
    public ProductRepo(BarazaContext ctx) : base(ctx) { }

    // STARTING PRIVATE FUNCTIONS
    
    private async Task<List<ProductModel>> Records(){
        List<ProductModel> Nothing = new();
        if(MyDbSet.Any()){
            Nothing = await MyDbSet
            .OrderBy(x => x.Id)
            .Include(y => y.Barcode)
            .Include(a => a.Brand)
            .Include(b => b.Category)
            .Include(c => c.User)
            .Include(k => k.Tax)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(j => j.Supplier)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(k => k.User)
            .Include(e => e.ProductAdjustment)
                .ThenInclude(n => n.Adjustment)
                    .ThenInclude(o => o.User)
            .Include(f => f.ProductPrice)
                .ThenInclude(l => l.Price)
                    .ThenInclude(m => m.User)
            .Include(d => d.ProductOpen)
                .ThenInclude(dd => dd.Open)
                    .ThenInclude(cc => cc.User)
            .Include(h => h.ProductBill)
                .ThenInclude(i => i.Bill)
                    .ThenInclude(j => j.User)
            .ToListAsync();
        }
        else{
            Nothing = new();
        }
        
        return Nothing;
    }

    // ENDING PRIVATE FUNCTIONS

    // *********************** NEW ZONE ****************************** \\

    //STARTING INTERFACE FUNCTIONS
    public async Task<ProductModel> FirstProduct()
    {
        ProductModel Nothing = new();

        if (MyDbSet.Any())
        {
            Nothing = await MyDbSet
                .FirstOrDefaultAsync();
        }

        return Nothing;
    }


        // ENDING INTERFACE FUNCTIONS

        public async Task<ProductModel> GetDetailedProductAsync(int sn)
    {
        ProductModel Nothing = new();

        if (sn > 0 )
        {
            var CheckedRecords = await Records();
            
            if(CheckedRecords.Count > 0){
                Nothing = CheckedRecords
                .Where(x => x.Id == sn)
                .SingleOrDefault();
            }
            else{
                Nothing = new();
            }
        }
        else
            {
                Nothing = new();
            }
        
        return Nothing;
    }
    
    public async Task<ProductModel> GetDetailedProductAsync(int sn, DateOnly FromDate, DateOnly ToDate)
    {
        ProductModel Nothing = new();

        if (sn > 0 && MyDbSet.Any())
        {
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(y => y.Barcode)
            .Include(a => a.Brand)
            .Include(b => b.Category)
            .Include(c => c.User)
            .Include(k => k.Tax)
            .Include(d => d.ProductGrn.Where(x => (((DateOnly.FromDateTime(x.Grn.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(x.Grn.DateCreated)) <= ToDate))))
                .ThenInclude(i => i.Grn)
                    .ThenInclude(j => j.Supplier)
            .Include(d => d.ProductGrn.Where(x => (((DateOnly.FromDateTime(x.Grn.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(x.Grn.DateCreated)) <= ToDate))))
                .ThenInclude(i => i.Grn)
                    .ThenInclude(k => k.User)
            .Include(e => e.ProductAdjustment.Where(ee => (((DateOnly.FromDateTime(ee.Adjustment.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(ee.Adjustment.DateCreated)) <= ToDate))))
                .ThenInclude(n => n.Adjustment)
                    .ThenInclude(o => o.User)
            .Include(f => f.ProductPrice.Where(ff => (((DateOnly.FromDateTime(ff.Price.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(ff.Price.DateCreated)) <= ToDate))))
                .ThenInclude(l => l.Price)
                    .ThenInclude(m => m.User)
            .Include(d => d.ProductOpen.Where(dd => (((DateOnly.FromDateTime(dd.Open.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(dd.Open.DateCreated)) <= ToDate))))
                .ThenInclude(dd => dd.Open)
                    .ThenInclude(cc => cc.User)
            .Include(h => h.ProductBill.Where(hh => (((DateOnly.FromDateTime(hh.Bill.DateCreated)) >= FromDate) && ((DateOnly.FromDateTime(hh.Bill.DateCreated)) <= ToDate))))
                .ThenInclude(i => i.Bill)
                    .ThenInclude(j => j.User)
            .SingleOrDefaultAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<List<ProductModel>> GetAllProductsDetailedAsync(int CurrentPage, int PageSize)
    {
        List<ProductModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(y => y.Barcode)
            .Include(a => a.Brand)
            .Include(b => b.Category)
            .Include(c => c.User)
            .Include(k => k.Tax)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(j => j.Supplier)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(k => k.User)
            .Include(e => e.ProductAdjustment)
                .ThenInclude(n => n.Adjustment)
                    .ThenInclude(o => o.User)
            .Include(f => f.ProductPrice)
                .ThenInclude(l => l.Price)
                    .ThenInclude(m => m.User)
            .Include(d => d.ProductOpen)
                .ThenInclude(dd => dd.Open)
                    .ThenInclude(cc => cc.User)
            .Include(h => h.ProductBill)
                .ThenInclude(i => i.Bill)
                    .ThenInclude(j => j.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<ProductModel>> GetAllProductsDetailedAsync(int CurrentPage, int PageSize, DateOnly FromDate,DateOnly ToDate)
    {
        List<ProductModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(y => y.Barcode)
            .Include(a => a.Brand)
            .Include(b => b.Category)
            .Include(c => c.User)
            .Include(k => k.Tax)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(j => j.Supplier)
            .Include(d => d.ProductGrn)
                .ThenInclude(i => i.Grn)
                    .ThenInclude(k => k.User)
            .Include(e => e.ProductAdjustment)
                .ThenInclude(n => n.Adjustment)
                    .ThenInclude(o => o.User)
            .Include(f => f.ProductPrice)
                .ThenInclude(l => l.Price)
                    .ThenInclude(m => m.User)
            .Include(d => d.ProductOpen)
                .ThenInclude(dd => dd.Open)
                    .ThenInclude(cc => cc.User)
            .Include(h => h.ProductBill)
                .ThenInclude(i => i.Bill)
                    .ThenInclude(j => j.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<ProductModel>> GetAllProductsDetailedAsync( DateOnly FromDate, DateOnly ToDate, int Cid, int Bid, int Uid)
    {
        List<ProductModel> Nothing = new();

        if (MyDbSet.Any())
        {
            if(Cid > 0 && Bid > 0 && Uid > 0){
                return await MyDbSet
                .Where(cc => cc.CategoryId == Cid)
                .Where(bb => bb.BrandId == Bid)
                .Where (uu => uu.UserId == Uid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }
            else if(Cid > 0 && Uid > 0 && Bid < 1){
                return await MyDbSet
                .Where(cc => cc.CategoryId == Cid)
                .Where(uu => uu.UserId == Uid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }
            else if(Cid > 0 && Uid < 1 && Bid < 1){
                return await MyDbSet
                .Where(cc => cc.CategoryId == Cid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }
            else if(Cid < 1 && Uid < 1 && Bid < 1){
                return await MyDbSet
                    .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                    .OrderBy(x => x.Id)
                    .Include(y => y.Barcode)
                    .Include(a => a.Brand)
                    .Include(b => b.Category)
                    .Include(c => c.User)
                    .Include(k => k.Tax)
                    .Include(d => d.ProductGrn)
                        .ThenInclude(i => i.Grn)
                            .ThenInclude(j => j.Supplier)
                    .Include(d => d.ProductGrn)
                        .ThenInclude(i => i.Grn)
                            .ThenInclude(k => k.User)
                    .Include(e => e.ProductAdjustment)
                        .ThenInclude(n => n.Adjustment)
                            .ThenInclude(o => o.User)
                    .Include(f => f.ProductPrice)
                        .ThenInclude(l => l.Price)
                            .ThenInclude(m => m.User)
                    .Include(d => d.ProductOpen)
                        .ThenInclude(dd => dd.Open)
                            .ThenInclude(cc => cc.User)
                    .Include(h => h.ProductBill)
                        .ThenInclude(i => i.Bill)
                            .ThenInclude(j => j.User)
                    .ToListAsync();
            }else if(Cid < 1 && Uid > 0 && Bid > 0){
                return await MyDbSet
                    .Where(uu => uu.UserId == Uid)
                    .Where(bb => bb.BrandId == Bid)
                    .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                    .OrderBy(x => x.Id)
                    .Include(y => y.Barcode)
                    .Include(a => a.Brand)
                    .Include(b => b.Category)
                    .Include(c => c.User)
                    .Include(k => k.Tax)
                    .Include(d => d.ProductGrn)
                        .ThenInclude(i => i.Grn)
                            .ThenInclude(j => j.Supplier)
                    .Include(d => d.ProductGrn)
                        .ThenInclude(i => i.Grn)
                            .ThenInclude(k => k.User)
                    .Include(e => e.ProductAdjustment)
                        .ThenInclude(n => n.Adjustment)
                            .ThenInclude(o => o.User)
                    .Include(f => f.ProductPrice)
                        .ThenInclude(l => l.Price)
                            .ThenInclude(m => m.User)
                    .Include(d => d.ProductOpen)
                        .ThenInclude(dd => dd.Open)
                            .ThenInclude(cc => cc.User)
                    .Include(h => h.ProductBill)
                        .ThenInclude(i => i.Bill)
                            .ThenInclude(j => j.User)
                    .ToListAsync();
            }else if(Cid < 1 && Uid > 0 && Bid < 1){
                return await MyDbSet
                .Where(uu => uu.UserId == Uid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }else if(Cid > 0 && Uid < 1 && Bid > 0) {
                return await MyDbSet
                .Where(bb => bb.BrandId == Bid)
                .Where(cc => cc.CategoryId == Cid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }
            
            else {
                return await MyDbSet
                .Where(bb => bb.BrandId == Bid)
                .Where(dt => ((DateOnly.FromDateTime(dt.DateCreated) >= FromDate) && (DateOnly.FromDateTime(dt.DateCreated) <= ToDate)))
                .OrderBy(x => x.Id)
                .Include(y => y.Barcode)
                .Include(a => a.Brand)
                .Include(b => b.Category)
                .Include(c => c.User)
                .Include(k => k.Tax)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(j => j.Supplier)
                .Include(d => d.ProductGrn)
                    .ThenInclude(i => i.Grn)
                        .ThenInclude(k => k.User)
                .Include(e => e.ProductAdjustment)
                    .ThenInclude(n => n.Adjustment)
                        .ThenInclude(o => o.User)
                .Include(f => f.ProductPrice)
                    .ThenInclude(l => l.Price)
                        .ThenInclude(m => m.User)
                .Include(d => d.ProductOpen)
                    .ThenInclude(dd => dd.Open)
                        .ThenInclude(cc => cc.User)
                .Include(h => h.ProductBill)
                    .ThenInclude(i => i.Bill)
                        .ThenInclude(j => j.User)
                .ToListAsync();
            }
        }
        else
        {
            return Nothing;
        }
    }
}
