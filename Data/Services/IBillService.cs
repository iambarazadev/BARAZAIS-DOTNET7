using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IBillService : IBaseService<BillModel>
{
    Task<BillModel> GetDetailedBillAsync(int sn);
    Task<List<BillModel>> GetAllBillsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate);
    Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize);
    Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid);
    Task<List<BillModel>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize);
}
