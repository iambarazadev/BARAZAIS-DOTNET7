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

public class HoldRepo : BaseRepo<HoldModel>, IHoldService
{
    public HoldRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<HoldModel> GetDetailedHoldAsync(int sn){
        HoldModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.ProductHold)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductHold)
                .ThenInclude(b => b.Product)
                    .ThenInclude(c => c.ProductGrn)
            .Include(d => d.User)
            .SingleOrDefaultAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(int CurrentPage, int PageSize){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
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
        else{
            return Nothing;
        }
    }
    
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int CurrentPage, int PageSize, string? Status = null){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(ss => ss.Status == Status)
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
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
        else{
            return Nothing;
        }
    }
    
    public async Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage, int PageSize, string? Status = null){
        List<HoldModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(g => g.UserId == Uid)
            .Where(ss => ss.Status == Status)
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
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
        else{
            return Nothing;
        }
    }
}
