using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services; 
public interface ICategoryService : IBaseService<CategoryModel> 
{ 
    Task<CategoryModel> GetDetailedCategoryAsync(int sn);
    Task<List<CategoryModel>> GetAllCategoriesDetailedAsync(int CurrentPage, int PageSize);
 }
