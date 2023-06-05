using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class HoldRepo : BaseRepo<HoldModel>, IHoldService
{
    public HoldRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync()
    {
        List<HoldModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Include(a => a.ProductHold)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductHold)
                .ThenInclude(b => b.Product)
                    .ThenInclude(c => c.ProductGrn)
            .Include(d => d.User)
            .OrderBy(x => x.Id)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<HoldModel> GetDetailedHoldAsync(int sn){
        HoldModel Nothing = new();
        
        if(sn > 0 && (await GetAllHoldsDetailedAsync()).Any()){
            return (await GetAllHoldsDetailedAsync())
            .Where(x => x.Id == sn)
            .SingleOrDefault();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(int CurrentPage, int PageSize){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllHoldsDetailedAsync())
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int CurrentPage, int PageSize, string? Status = null){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllHoldsDetailedAsync())
            .Where(ss => ss.Status == Status)
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage, int PageSize, string? Status = null){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllHoldsDetailedAsync())
            .Where(g => g.UserId == Uid)
            .Where(ss => ss.Status == Status)
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
}
