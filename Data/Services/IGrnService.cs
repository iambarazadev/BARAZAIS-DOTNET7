using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IGrnService : IBaseService<GrnModel>
{ 
    Task<GrnModel> GetDetailedGrnAsync(int sn);
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(int CurrentPage, int PageSize);
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(int ProductId, int CurrentPage, int PageSize);
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate,int CurrentPage,int PageSize);
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Uid, int CurrentPage,int PageSize);
    
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate);
    Task<List<GrnModel>> GetAllGrnsDetailedAsync(DateOnly FromDate, DateOnly ToDate, bool Ok, int Uid, int Sid);
 }
