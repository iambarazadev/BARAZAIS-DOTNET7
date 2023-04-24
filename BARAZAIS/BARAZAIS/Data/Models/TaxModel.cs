using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Models;

public class TaxModel
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    [Required]
    public DateTime DateCreated { set; get; }
    public DateTime DateUpdated { get; set; }
    [Required]
    public string Code { get; set; }
    public double Percentage { get; set; }

#nullable enable

        [Required(ErrorMessage = "Tax Caption, Range Characters(2 - 50) characters"), MaxLength(50), MinLength(2), DataType(DataType.Text)]
        public string? Caption { set; get; }

        [Required(ErrorMessage = "Please enter your Message, Range Characters(10 - 300)"), MaxLength(600), MinLength(3), DataType(DataType.Text)]
        public string? Description { set; get; }

#nullable enable

        // FOREIGN KEYS
        [ForeignKey("UserModel")]
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }

        [ForeignKey("CompanyModel")]
        public int? CompanyId { get; set; }
        public virtual CompanyModel? Company { get; set; }

        // COLLECTIONS
        public virtual List<ProductModel>? Product { get; set; }

        // CTOR
        public TaxModel()
        {
            this.Id = default;
            this.Percentage = 0.0;
            this.Caption = null;
            this.Description = null;
            this.DateCreated = DateTime.Now;
        this.DateUpdated= DateTime.Now;
        this.Code = "TX";
        }
}