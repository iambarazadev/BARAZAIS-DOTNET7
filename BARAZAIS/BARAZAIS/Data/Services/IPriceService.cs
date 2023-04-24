using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IPriceService : IBaseService<PriceModel>
{
    Task<PriceModel> GetDetailedPriceAsync(int sn);
    Task<List<PriceModel>> GetAllPricesDetailedAsync(int CurrentPage, int PageSize);
    Task<List<PriceModel>> GetAllPricesDetailedAsync(int CurrentPage, int PageSize, bool Filtered);
    Task<List<PriceModel>> GetAllPricesDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize);
    Task<List<PriceModel>> GetAllPricesDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize);
}
