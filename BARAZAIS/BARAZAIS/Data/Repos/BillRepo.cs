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

public class BillRepo : BaseRepo<BillModel> , IBillService
{
    public BillRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<BillModel> GetDetailedBillAsync(int sn){
        BillModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(c => c.ProductGrn)
            .Include(d => d.User)
        
            .SingleOrDefaultAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<BillModel>> GetAllBillsDetailedAsync(int CurrentPage, int PageSize){
        List<BillModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductBill)
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
    
    public async Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate){
        List<BillModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductBill)
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
    
    public async Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int CurrentPage, int PageSize){
        List<BillModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductBill)
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
    
    public async Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid){
        List<BillModel> Nothing = new();
        
        if(MyDbSet.Any()){
            
            if(Uid > 0){
                return await MyDbSet
                .Where(g => g.UserId == Uid)
                .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
                .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
                .Include(a => a.ProductBill)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(b => b.ProductPrice)
                .Include(a => a.ProductBill)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(c => c.ProductGrn)
                .Include(d => d.User)
                .OrderBy(x => x.Id)
                .ToListAsync();
            }else{
                return await MyDbSet
                .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
                .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
                .Include(a => a.ProductBill)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(b => b.ProductPrice)
                .Include(a => a.ProductBill)
                    .ThenInclude(b => b.Product)
                        .ThenInclude(c => c.ProductGrn)
                .Include(d => d.User)
                .OrderBy(x => x.Id)
                .ToListAsync();
            }
            
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage, int PageSize){
        List<BillModel> Nothing = new();
        
        if(MyDbSet.Any() && Uid > 0){
            return await MyDbSet
            .Where(g => g.UserId == Uid)
            .Where(e => (DateOnly.FromDateTime(e.DateCreated)) >= FromDate)
            .Where(f => (DateOnly.FromDateTime(f.DateCreated)) <= ToDate)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(a => a.ProductBill)
                .ThenInclude(b => b.Product)
                    .ThenInclude(b => b.ProductPrice)
            .Include(a => a.ProductBill)
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
