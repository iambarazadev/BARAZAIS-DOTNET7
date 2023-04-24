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

public class BarcodeRepo : BaseRepo<BarcodeModel> , IBarcodeService
{
    public BarcodeRepo(BarazaContext ctx) : base(ctx) { }
}
