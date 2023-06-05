using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface ISupplierService : IBaseService<SupplierModel>
{ 
     Task<SupplierModel> GetDetailedSupplierAsync(int sn);
    Task<List<SupplierModel>> GetAllSuppliersDetailedAsync(int CurrentPage, int PageSize);
 }
