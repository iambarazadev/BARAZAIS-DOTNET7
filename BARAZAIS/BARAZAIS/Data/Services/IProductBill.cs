using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;
public interface IProductBill : IBaseService<ProductBill>
{
   // Task<List<ProductBill>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate);
   // Task<List<ProductBill>> GetAllBillsDetailedAsync(DateOnly FromDate, DateOnly ToDate, int Bid);
}
