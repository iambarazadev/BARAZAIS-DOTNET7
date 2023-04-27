using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BARAZAIS.Data.Models;

public class AccessLevelModel : IdentityRole<int>
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public override int Id { get; set; }

	public DateTime DateCreated { get; set; }
	public DateTime DateUpdated { get; private set; }

	[DataType(DataType.Text)]
	public string? Description { get; set; }

	//collections
	public virtual List<UserModel>? Users { get; set; }

	//ctor
	public AccessLevelModel()
	{
		this.Id = default;
		this.DateUpdated = DateTime.Now;
		this.Description = null;
	}
}
