using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class AdjustmentModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }

    [Required]
    public string Code { get; set; }

#nullable enable
    [Required(ErrorMessage = "Required"), MaxLength(50), MinLength(2), DataType(DataType.Text)]
    public string? Description { get; set; }

    //FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public UserModel? User { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public virtual CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<ProductAdjustment>? ProductAdjustment { get; set; }

    //CTOR
    public AdjustmentModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.Description = null;
        this.Code = "SAD";
    }
}

