using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

    public class ProductGrn
    {
        public int OldStock { get; set; }
        public int QtyPurchased { get; set; }
        public int NewStock { get; set; }
        public decimal Cost { get; set; }

#nullable enable

        // FOREIGN KEYS
        [ForeignKey("GrnModel")]
        public int? GrnId { get; set; }
        public virtual GrnModel? Grn { get; set; }

        [ForeignKey("ProductModel")]
        public int? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        //CTOR
        public ProductGrn()
        {
            this.Cost = 0;
            this.QtyPurchased = 0;
            this.OldStock = 0;
            this.NewStock = 0;
        }
    }
