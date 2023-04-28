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

public class CategoryRepo : BaseRepo<CategoryModel> , ICategoryService
{
    public CategoryRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<CategoryModel>> GetAllCategoriesDetailedAsync()
    {
        List<CategoryModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(x => x.Id)
            .Include(g => g.User)
            .Include(a => a.Product)
                .ThenInclude(c => c.Brand)
            .Include(a => a.Product)
                .ThenInclude(c => c.Barcode)
            .Include(a => a.Product)
                .ThenInclude(d => d.ProductPrice)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<CategoryModel> GetDetailedCategoryAsync(int sn){
        CategoryModel Nothing = new();
        
        if(sn > 0 && (await GetAllCategoriesDetailedAsync()).Any()){
            return (await GetAllCategoriesDetailedAsync())
            .Where(x => x.Id == sn) 
            .SingleOrDefault();
        }
        else{
            return Nothing;
        }
    }
      
    public async Task<List<CategoryModel>> GetAllCategoriesDetailedAsync(int CurrentPage, int PageSize){
        List<CategoryModel> Nothing = new();
        
        if((await GetAllCategoriesDetailedAsync()).Any()){
            return (await GetAllCategoriesDetailedAsync())
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
}
