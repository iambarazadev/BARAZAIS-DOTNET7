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

public class SupplierRepo : BaseRepo<SupplierModel> , ISupplierService
{
    public SupplierRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<SupplierModel>> GetAllSuppliersDetailedAsync()
    {
        List<SupplierModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Include(a => a.Grn)
                .ThenInclude(c => c.User)
            .Include(a => a.Grn)
                .ThenInclude(d => d.ProductGrn)
            .Include(b => b.User)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<SupplierModel> GetDetailedSupplierAsync(int sn)
    {
        SupplierModel Nothing = new();

        if (sn > 0 && (await GetAllSuppliersDetailedAsync()).Any())
        {
            return (await GetAllSuppliersDetailedAsync())
            .Where(x => x.Id == sn)
            .SingleOrDefault();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<List<SupplierModel>> GetAllSuppliersDetailedAsync(int CurrentPage, int PageSize)
    {
        List<SupplierModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return (await GetAllSuppliersDetailedAsync())
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
