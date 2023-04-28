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

public class AdjustmentRepo : BaseRepo<AdjustmentModel>, IAdjustmentService
{
    public AdjustmentRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync()
    {
        List<AdjustmentModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Include(a => a.ProductAdjustment)
                .ThenInclude(b => b.Product)
                    .ThenInclude(d => d.ProductGrn)
                        .ThenInclude(e => e.Grn)
            .Include(a => a.ProductAdjustment)
                .ThenInclude(b => b.Product)
                    .ThenInclude(d => d.Barcode)
            .Include(a => a.ProductAdjustment)
                .ThenInclude(b => b.Product)
                    .ThenInclude(e => e.ProductOpen)
            .Include(c => c.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<AdjustmentModel> GetDetailedStockAdjustmentAsync(int sn)
    {
        AdjustmentModel Nothing = new(); 

        if (sn > 0 && (await GetAllStockAdjustmentsDetailedAsync()).Any())
        {
            Nothing = (await GetAllStockAdjustmentsDetailedAsync())
            .Where(x => x.Id == sn).SingleOrDefault();
        }
        else
        {
            Nothing = new();
        }

        return Nothing;
    }

    public async Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(int CurrentPage, int PageSize)
    {
        List<AdjustmentModel> Nothing = new();

        if ((await GetAllStockAdjustmentsDetailedAsync()).Any())
        {
            return (await GetAllStockAdjustmentsDetailedAsync())
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else
        {
            return Nothing;
        }
    }
    
    
    public async Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize)
    {
        List<AdjustmentModel> Nothing = new();

        if ((await GetAllStockAdjustmentsDetailedAsync()).Any())
        {
            return (await GetAllStockAdjustmentsDetailedAsync())
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize)
    {
        List<AdjustmentModel> Nothing = new();

        if ((await GetAllStockAdjustmentsDetailedAsync()).Any())
        {
            return (await GetAllStockAdjustmentsDetailedAsync())
            .Where(ge => ge.UserId == Uid)
            .Where(ee => (DateOnly.FromDateTime(ee.DateCreated)) >= FromDate)
            .Where(fe => (DateOnly.FromDateTime(fe.DateCreated)) <= ToDate)
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else
        {
            return Nothing;
        }
    }
}