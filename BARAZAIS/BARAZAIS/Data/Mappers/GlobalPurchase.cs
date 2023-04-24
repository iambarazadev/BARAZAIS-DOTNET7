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

public class GlobalPurchase{
    public async Task<List<GrnModel>>Associatedurchases(){
        List<GrnModel> Grns = new();
        //Grns = await Grns.GetAllGrnsDetailedAsync(1,10);
        return Grns;
    }
}