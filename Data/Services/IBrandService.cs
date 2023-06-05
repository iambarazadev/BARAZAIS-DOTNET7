using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IBrandService : IBaseService<BrandModel> 
{ 
    Task<BrandModel> GetDetailedBrandAsync(int sn);
    Task<List<BrandModel>> GetAllBrandsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<BrandModel>> GetBrandsOfThisCategory(CategoryModel ThisCategory,int CurrentPage, int PageSize);
 }
