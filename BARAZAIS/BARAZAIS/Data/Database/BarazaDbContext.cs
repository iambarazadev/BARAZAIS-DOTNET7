using BARAZAIS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Database;

public class BarazaDbContext : IdentityDbContext<UserModel>
{
    public BarazaDbContext(DbContextOptions<BarazaDbContext> options)
        : base(options)
    {}

    public override DbSet<UserModel> Users { get; set; }
}