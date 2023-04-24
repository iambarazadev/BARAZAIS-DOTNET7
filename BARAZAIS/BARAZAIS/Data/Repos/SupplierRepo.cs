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
    
    public async Task<SupplierModel> GetDetailedSupplierAsync(int sn)
    {
        SupplierModel Nothing = new();

        if (sn > 0 && MyDbSet.Any())
        {
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.Grn)
                .ThenInclude(c => c.User)
            .Include(a => a.Grn)
                .ThenInclude(d => d.ProductGrn)
            .Include(b => b.User)
            .SingleOrDefaultAsync();
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
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
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
}
