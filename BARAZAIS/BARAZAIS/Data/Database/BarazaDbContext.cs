using BARAZAIS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Database;

public class BarazaDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public BarazaDbContext(DbContextOptions<BarazaDbContext> options)
        : base(options)
    {}

    public DbSet<UserModel> AppUsers { get; set; }
}