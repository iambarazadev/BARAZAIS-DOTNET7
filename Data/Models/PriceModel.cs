using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;


public class PriceModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    [Required]
    public string Code { get; set; }

#nullable enable
    public string? Description { get; set; }

    //FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public UserModel? User { get; set; }


    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }

    //COLLECTIONS 
    public virtual List<ProductPrice>? ProductPrice { get; set; }

    //CTOR
    public PriceModel()
    {
        this.Id = default;
        this.Description = null;
        this.DateCreated = DateTime.Now;
        this.Code = "PRC";
    }
}

