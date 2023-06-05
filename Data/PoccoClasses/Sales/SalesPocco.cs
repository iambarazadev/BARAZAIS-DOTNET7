using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.PoccoClasses.Sales;

public class SalesPoccoModel{
    public int? UserId {get;set;}
    public DateOnly FromDate {get;set;}
    public DateOnly ToDate {get;set;}
    
    //ctor
    public SalesPoccoModel(){
        this.UserId = null;
        this.FromDate = DateOnly.FromDateTime(DateTime.Now);
        this.ToDate = DateOnly.FromDateTime(DateTime.Now);
    }
}