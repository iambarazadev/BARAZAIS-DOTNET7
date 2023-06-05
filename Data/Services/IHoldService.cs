using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IHoldService : IBaseService<HoldModel>
{
    Task<HoldModel> GetDetailedHoldAsync(int sn);
    Task<List<HoldModel>> GetAllHoldsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int CurrentPage,int PageSize, string? Status);
    Task<List<HoldModel>> GetAllHoldsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize, string? Status);
}
