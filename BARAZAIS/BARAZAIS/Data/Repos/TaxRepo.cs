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

public class TaxRepo : BaseRepo<TaxModel> , ITaxService
{
    public TaxRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<TaxModel> GetDetailedTaxAsync(int sn){
        TaxModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(a => a.Product)
                .ThenInclude(b => b.Category)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .Include(a => a.Product)
                .ThenInclude(d => d.Brand)
            .Include(g => g.User)
            .SingleOrDefaultAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<TaxModel>> GetAllTaxesDetailedAsync(int CurrentPage, int PageSize){
        List<TaxModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(k => k.User)
            .Include(a => a.Product)
                .ThenInclude(b => b.Category)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .Include(a => a.Product)
                .ThenInclude(d => d.Brand)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<TaxModel>> GetTaxesOfThisCategory(CategoryModel ThisCategory, int CurrentPage, int PageSize){
        List<TaxModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }else{
            return Nothing;
        }
    }
}