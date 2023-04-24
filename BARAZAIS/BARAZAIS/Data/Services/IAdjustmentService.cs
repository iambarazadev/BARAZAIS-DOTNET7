using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;

public interface IAdjustmentService : IBaseService<AdjustmentModel>
{
    Task<AdjustmentModel> GetDetailedStockAdjustmentAsync(int sn);
    Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize);
    Task<List<AdjustmentModel>> GetAllStockAdjustmentsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize);
}
