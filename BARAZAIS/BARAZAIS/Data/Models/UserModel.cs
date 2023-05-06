using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BARAZAIS.Data.Models;

public class UserModel : IdentityUser<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [Required]
    public string Code { get; set; }

    public DateTime DateUpdated { get; private set; }
    public DateTime DateCreated { get; set; }

#nullable enable

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    public string? Address { get; set; }

    public string? ImageUrl { get; set; }

    [Required]
    public string? NIDA { get; set; }

    //FOREIGN KEYS
    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }


	//COLLECTIONS
	public virtual List<PriceModel>? Price { get; set; }
    public virtual List<ProductModel>? Product { get; set; }
    public virtual List<BrandModel>? Brand { get; set; }
    public virtual List<BarcodeModel>? Barcode { get; set; }
    public virtual List<GrnModel>? Grn { get; set; }
    public virtual List<CategoryModel>? Category { get; set; }
    public virtual List<TaxModel>? Tax { get; set; }
    public virtual List<SupplierModel>? Supplier { get; set; }
    public virtual List<BillModel>? Bill { get; set; }
    public virtual List<AdjustmentModel>? Adjustment { get; set; }
    public virtual List<OpenModel>? Open { get; set; }
    public virtual List<HoldModel>? Hold { get; set; }

    //CTOR
    public UserModel() 
    {
        this.Id = default;
        this.DateUpdated = DateTime.Now;
        this.Address = null;
        this.Code = "EMP";
        this.ImageUrl = null;
        this.NIDA = null;
    }
}