using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IProductService : IBaseService<ProductModel>
{
    Task<ProductModel> FirstProduct();
    Task<ProductModel> GetDetailedProductAsync(int sn);
    Task<ProductModel> GetDetailedProductAsync(int sn, DateOnly FromDate, DateOnly ToDate);
    Task<List<ProductModel>> GetAllProductsDetailedAsync( DateOnly FromDate, DateOnly ToDate, int Cid, int Bid, int Uid);
    Task<List<ProductModel>> GetAllProductsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<ProductModel>> GetAllProductsDetailedAsync(int CurrentPage, int PageSize,DateOnly FromDate, DateOnly ToDate);
    
}
