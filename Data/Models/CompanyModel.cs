using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace BARAZAIS.Data.Models;

public class CompanyModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    public DateTime DateUpdated { get; set; }
    [Required]
    public string Code { get; set; }

#nullable enable

    [Required(ErrorMessage = "Company Name is required"), MaxLength(100), MinLength(2)]
    public string? CompanyName { get; set; }
    public string? LogoUrl { get; set; }

    [Required(ErrorMessage = "Tax identification Number is required"), MaxLength(100), MinLength(2)]
    public string? TIN { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please enter your Address, Range Characters(3 - 300)"), MaxLength(600), MinLength(3), DataType(DataType.Text)]
    public string? Address { get; set; }

    // COLLECTIONS
    public virtual List<UserModel>? User { get; set; }
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

    // CTOR
    public CompanyModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.DateUpdated= DateTime.Now;
        this.CompanyName = null;
        this.Email = null;
        this.Phone = null;
        this.Address = null;
        this.LogoUrl = null;
        this.Code = "CMP";
        this.TIN = null;
    }
}
