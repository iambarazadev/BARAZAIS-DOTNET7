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

public class GrnRepo : BaseRepo<GrnModel> , IGrnService
{
    public GrnRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<GrnModel> GetDetailedGrnAsync(int sn)
    {
        GrnModel Nothing = new();

        if (sn > 0 && MyDbSet.Any())
        {
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
           
            .SingleOrDefaultAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(int CurrentPage, int PageSize)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    
    
    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(int ProductId, int CurrentPage, int PageSize)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Where(yy => yy.ProductGrn.All(xx => xx.ProductId == ProductId))
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate, bool Ok, int Uid , int Sid)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            if((Uid > 0) && (Sid > 0)){
                return await MyDbSet
                .Where(ge => ge.UserId == Uid)
                .Where(ss => ss.SupplierId == Sid)
                .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
                .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
                .OrderBy(x => x.Id)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(e => e.ProductAdjustment)
                            .ThenInclude(f => f.Adjustment)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(g => g.ProductPrice)
                            .ThenInclude(h => h.Price)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(y => y.Barcode)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(z => z.ProductOpen)
                .Include(c => c.Supplier)
                .Include(d => d.User)
                .ToListAsync();
            }
            else if((Uid > 0) && (Sid < 1)){
                return await MyDbSet
                .Where(ge => ge.UserId == Uid)
                .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
                .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
                .OrderBy(x => x.Id)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(e => e.ProductAdjustment)
                            .ThenInclude(f => f.Adjustment)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(g => g.ProductPrice)
                            .ThenInclude(h => h.Price)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(y => y.Barcode)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(z => z.ProductOpen)
                .Include(c => c.Supplier)
                .Include(d => d.User)
                .ToListAsync();
            }
            else if(Uid < 1 && Sid > 0){
                return await MyDbSet
                .Where(ss => ss.SupplierId == Sid)
                .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
                .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
                .OrderBy(x => x.Id)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(e => e.ProductAdjustment)
                            .ThenInclude(f => f.Adjustment)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(g => g.ProductPrice)
                            .ThenInclude(h => h.Price)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(y => y.Barcode)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(z => z.ProductOpen)
                .Include(c => c.Supplier)
                .Include(d => d.User)
                .ToListAsync();
            }else{
                return await MyDbSet
                .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
                .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
                .OrderBy(x => x.Id)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(e => e.ProductAdjustment)
                            .ThenInclude(f => f.Adjustment)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(g => g.ProductPrice)
                            .ThenInclude(h => h.Price)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(y => y.Barcode)
                .Include(a => a.ProductGrn)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(z => z.ProductOpen)
                .Include(c => c.Supplier)
                .Include(d => d.User)
                .ToListAsync();
            }
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize)
    {
        List<GrnModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Where(ge => ge.UserId == Uid)
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductGrn)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductOpen)
            .Include(c => c.Supplier)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }
}
