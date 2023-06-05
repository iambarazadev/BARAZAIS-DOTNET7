using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class CategoryModel
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

    [Required(ErrorMessage = "Brand Caption, Range Characters(2 - 50) characters"), MaxLength(50), MinLength(2), DataType(DataType.Text)]
    public string? Caption { set; get; }

    [Required(ErrorMessage = "Describe Brand by at least two words)"), MaxLength(600), MinLength(3), DataType(DataType.Text)]
    public string? Description { set; get; }

    //FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }

    // COLLECTIONS
    public virtual List<ProductModel>? Product { get; set; }

    //CTOR
    public CategoryModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.DateUpdated = DateTime.Now;
        this.Caption = null;
        this.Description = null;
        this.Code = "CAT";
    }
}
