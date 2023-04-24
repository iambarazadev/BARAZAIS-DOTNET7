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

public class BrandRepo : BaseRepo<BrandModel> , IBrandService
{
    public BrandRepo(BarazaContext ctx) : base(ctx) { }
    
    public async Task<BrandModel> GetDetailedBrandAsync(int sn){
        BrandModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return await MyDbSet
            .Where(x => x.Id == sn)
            .Include(g => g.User)
            .Include(a => a.Product)
                .ThenInclude(b => b.Category)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .SingleOrDefaultAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<BrandModel>> GetAllBrandsDetailedAsync(int CurrentPage, int PageSize){
        List<BrandModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(g => g.User)
            .Include(a => a.Product)
                .ThenInclude(b => b.Category)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .ToListAsync();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<BrandModel>> GetBrandsOfThisCategory(CategoryModel ThisCategory, int CurrentPage, int PageSize){
        List<BrandModel> Nothing = new();
        
        if(MyDbSet.Any()){
            return await MyDbSet
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .Include(g => g.User)
            .ToListAsync();
        }else{
            return Nothing;
        }
    }
}
