
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class ProductModel
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
    [Required(ErrorMessage = "Product Caption, Range Characters(2 - 50) characters"), MaxLength(50), MinLength(2), DataType(DataType.Text)]
    public string? Caption { get; set; }

    [Required(ErrorMessage = "Describe Item, At least by two words."), MaxLength(50), MinLength(2), DataType(DataType.Text)]
    public string? Description { get; set; }

    // FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("CategoryModel")]
    public int? CategoryId { get; set; }
    public virtual CategoryModel? Category { get; set; }

    [ForeignKey("BrandModel")]
    public int? BrandId { get; set; }
    public virtual BrandModel? Brand { get; set; }

    [ForeignKey("TaxModel")]
    public int? TaxId { get; set; }
    public virtual TaxModel? Tax { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public virtual CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<ProductGrn>? ProductGrn { get; set; }
    public virtual List<ProductOpen>? ProductOpen { get; set; }
    public virtual List<ProductAdjustment>? ProductAdjustment { get; set; }
    public virtual List<ProductPrice>? ProductPrice { get; set; }
    public virtual List<ProductBill>? ProductBill { get; set; }
    public virtual List<ProductHold>? ProductHold { get; set; }
    public virtual List<BarcodeModel>? Barcode { get; set; }

    //CTOR
    public ProductModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.DateUpdated = DateTime.Now;
        this.Caption = null;
        this.Description = null;
        this.Code = "PID" ;

    }
}