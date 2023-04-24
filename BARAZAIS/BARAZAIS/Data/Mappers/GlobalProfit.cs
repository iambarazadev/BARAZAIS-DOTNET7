using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
namespace BARAZAIS.Data.Mappers;

public class GlobalProfit{
    public async Task<decimal> GetSales(DateOnly FromDateA, DateOnly ToDateB){
        decimal Profit = 0;
        
        
        
        return Profit;
    }
}