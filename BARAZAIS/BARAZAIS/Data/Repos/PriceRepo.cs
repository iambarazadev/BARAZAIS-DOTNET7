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

public class PriceRepo : BaseRepo<PriceModel> , IPriceService
{
    public PriceRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<PriceModel> GetDetailedPriceAsync(int sn){
        PriceModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductGrn)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(d => d.ProductOpen)
            .Include(n => n.User)
            .SingleOrDefaultAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<PriceModel>> GetAllPricesDetailedAsync(int CurrentPage, int PageSize){
        List<PriceModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductGrn)
            .Include(n => n.User)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<PriceModel>> GetAllPricesDetailedAsync(int CurrentPage, int PageSize, bool Filtered = true){
        List<PriceModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Reverse()
            .Where(f => (f.Code == "PAD"))
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductGrn)
            .Include(n => n.User)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<PriceModel>> GetAllPricesDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize)
    {
        List<PriceModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductGrn)
            .Include(n => n.User)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<PriceModel>> GetAllPricesDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize)
    {
        List<PriceModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(ge => ge.UserId == Uid)
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(a => a.ProductPrice)
                .ThenInclude(b => b.Product)
                    .ThenInclude(z => z.ProductGrn)
            .Include(n => n.User)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
}
