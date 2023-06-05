using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BARAZAIS.Data.Models;

public class SupplierModel
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

    [Required(ErrorMessage = "Supplier Name is required"), MaxLength(100), MinLength(2), DataType(DataType.Text)]
    public string? Caption { get; set; }

    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Supplier Phone Number is Required :")]
    public string? Phone { get; set; }

    public string? TIN { get; set; }
    public string? VRN { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [DataType(DataType.Text)]
    [MaxLength(100), MinLength(3)]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Describe with atleast 3 - 10 characters")]
    [DataType(DataType.Text)]
    [MaxLength(100), MinLength(3)]
    public string? Description { get; set; }

    //FOREIGN KEYS
    [ForeignKey("UserModel")]
    public int? UserId { get; set; }
    public virtual UserModel? User { get; set; }

    [ForeignKey("CompanyModel")]
    public int? CompanyId { get; set; }
    public virtual CompanyModel? Company { get; set; }

    //COLLECTIONS
    public virtual List<GrnModel>? Grn { get; set; }

    //CTOR
    public SupplierModel()
    {
        this.Id = default;
        this.DateCreated = DateTime.Now;
        this.DateUpdated = DateTime.Now;
        this.Caption = null;
        this.Email = null;
        this.Phone = null;
        this.TIN = null;
        this.VRN = null;
        this.Address = null;
        this.Description = null;
        this.Code = "SUP";
    }
}
