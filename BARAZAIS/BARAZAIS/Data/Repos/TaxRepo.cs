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

    public async Task<List<TaxModel>> GetAllTaxesDetailedAsync()
    {
        List<TaxModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Include(k => k.User)
            .Include(a => a.Product)
                .ThenInclude(b => b.Category)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .Include(a => a.Product)
                .ThenInclude(d => d.Brand)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<TaxModel> GetDetailedTaxAsync(int sn){
        TaxModel Nothing = new();
        
        if(sn > 0 && (await GetAllTaxesDetailedAsync()).Any()){
            return (await GetAllTaxesDetailedAsync())
            .Where(x => x.Id == sn)
            .SingleOrDefault();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<TaxModel>> GetAllTaxesDetailedAsync(int CurrentPage, int PageSize){
        List<TaxModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllTaxesDetailedAsync())
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<TaxModel>> GetTaxesOfThisCategory(CategoryModel ThisCategory, int CurrentPage, int PageSize){
        List<TaxModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return (await GetAllTaxesDetailedAsync())
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }else{
            return Nothing;
        }
    }
}