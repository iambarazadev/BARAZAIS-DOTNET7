using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IOpenService : IBaseService<OpenModel>
{
    Task<OpenModel> GetDetailedOpenAsync(int sn);
    Task<List<OpenModel>> GetAllOpensDetailedAsync(int CurrentPage, int PageSize);
    Task<List<OpenModel>> GetAllOpensDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize);
    Task<List<OpenModel>> GetAllOpensDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize);
}
