using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class OpenRepo : BaseRepo<OpenModel> , IOpenService
{
    public OpenRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<OpenModel>> GetAllOpensDetailedAsync()
    {
        List<OpenModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Include(a => a.ProductOpen)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductAdjustment)
                        .ThenInclude(f => f.Adjustment)
            .Include(a => a.ProductOpen)
                .ThenInclude(b => b.Product)
                    .ThenInclude(g => g.ProductPrice)
                        .ThenInclude(h => h.Price)
            .Include(a => a.ProductOpen)
                .ThenInclude(b => b.Product)
                    .ThenInclude(y => y.Barcode)
            .Include(d => d.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<OpenModel> GetDetailedOpenAsync(int sn){
        OpenModel Nothing = new();
        
        if(sn > 0 && (await GetAllOpensDetailedAsync()).Any()){
            return (await GetAllOpensDetailedAsync())
            .Where(x => x.Id == sn)
            .SingleOrDefault();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<OpenModel>> GetAllOpensDetailedAsync(int CurrentPage, int PageSize){
        List<OpenModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllOpensDetailedAsync())
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    
    public async Task<List<OpenModel>> GetAllOpensDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize)
    {
        List<OpenModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllOpensDetailedAsync())
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<OpenModel>> GetAllOpensDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize)
    {
        List<OpenModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllOpensDetailedAsync())
            .Where(ge => ge.UserId == Uid)
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
}
