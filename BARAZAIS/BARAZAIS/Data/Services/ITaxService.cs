using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface ITaxService : IBaseService<TaxModel> 
{ 
    Task<TaxModel> GetDetailedTaxAsync(int sn);
    Task<List<TaxModel>> GetAllTaxesDetailedAsync(int CurrentPage, int PageSize);
    Task<List<TaxModel>> GetTaxesOfThisCategory(CategoryModel ThisCategory,int CurrentPage, int PageSize);
 }
