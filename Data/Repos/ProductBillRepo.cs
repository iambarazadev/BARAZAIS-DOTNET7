using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class ProductBillRepo : BaseRepo<ProductBill> , IProductBill
{
    public ProductBillRepo(BarazaContext ctx) : base(ctx) { }
}
