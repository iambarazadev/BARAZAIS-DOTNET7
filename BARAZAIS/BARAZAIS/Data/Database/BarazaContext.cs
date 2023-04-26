using BARAZAIS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;

namespace BARAZAIS.Data.Database;

public class BarazaContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public BarazaContext(DbContextOptions<BarazaContext> options)
        : base(options)
    {}
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring UserModel to override auto key increment as primary key
        modelBuilder.Entity<UserModel>()
        .Property(u => u.Id)
        .ValueGeneratedOnAdd()
        .UseMySqlIdentityColumn();
        //.UseIdentityColumn();
        
        //Many To Many Product To Grn Via ProductGrns  
        modelBuilder.Entity<ProductGrn>()
        .HasKey(sc => new { sc.ProductId, sc.GrnId });

        modelBuilder.Entity<ProductGrn>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductGrn)
        .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductGrn>()
        .HasOne<GrnModel>(sc => sc.Grn)
        .WithMany(s => s.ProductGrn)
        .HasForeignKey(sc => sc.GrnId);

        // Many To Many Retail Adjustments, Price via ProductsPrice
        modelBuilder.Entity<ProductPrice>()
        .HasKey(sc => new { sc.ProductId, sc.PriceId });

        modelBuilder.Entity<ProductPrice>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductPrice)
        .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductPrice>()
        .HasOne<PriceModel>(sc => sc.Price)
        .WithMany(s => s.ProductPrice)
        .HasForeignKey(sc => sc.PriceId);

        // Many To Many Stock Adjustments, Product via StockAdjustmentsProduct
        modelBuilder.Entity<ProductAdjustment>()
        .HasKey(sc => new { sc.AdjustmentId, sc.ProductId });

        modelBuilder.Entity<ProductAdjustment>()
        .HasOne<AdjustmentModel>(sc => sc.Adjustment)
        .WithMany(s => s.ProductAdjustment)
        .HasForeignKey(sc => sc.AdjustmentId);

        modelBuilder.Entity<ProductAdjustment>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductAdjustment)
        .HasForeignKey(sc => sc.ProductId);

        // Many To Many Retail Adjustments, Price via ProductsPrice
        modelBuilder.Entity<ProductBill>()
        .HasKey(sc => new { sc.ProductId, sc.BillId });

        modelBuilder.Entity<ProductBill>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductBill)
        .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductBill>()
        .HasOne<BillModel>(sc => sc.Bill)
        .WithMany(s => s.ProductBill)
        .HasForeignKey(sc => sc.BillId);

        // Many To Many open product
        modelBuilder.Entity<ProductOpen>()
        .HasKey(sc => new { sc.ProductId, sc.OpenId });

        modelBuilder.Entity<ProductOpen>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductOpen)
        .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductOpen>()
        .HasOne<OpenModel>(sc => sc.Open)
        .WithMany(s => s.ProductOpen)
        .HasForeignKey(sc => sc.OpenId);

        // Many To Many Hold product
        modelBuilder.Entity<ProductHold>()
        .HasKey(sc => new { sc.ProductId, sc.HoldId });

        modelBuilder.Entity<ProductHold>()
        .HasOne<ProductModel>(sc => sc.Product)
        .WithMany(s => s.ProductHold)
        .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<ProductHold>()
        .HasOne<HoldModel>(sc => sc.Hold)
        .WithMany(s => s.ProductHold)
        .HasForeignKey(sc => sc.HoldId);

        // One Product must have one category, while one category can have more than one product to Many
        modelBuilder.Entity<ProductModel>()
        .HasOne(c => c.Category)
        .WithMany(p => p.Product);

        // One Product must have one Brand, while one Brand can have more than one product to Many
        modelBuilder.Entity<ProductModel>()
        .HasOne(c => c.Brand)
        .WithMany(p => p.Product);

        // One Product must have one Tax, while one Tax can have more than one product to Many
        modelBuilder.Entity<ProductModel>()
        .HasOne(c => c.Tax)
        .WithMany(p => p.Product);

        // One Product must have one Tax, while one Tax can have more than one product to Many
        modelBuilder.Entity<BarcodeModel>()
        .HasOne(c => c.Product)
        .WithMany(p => p.Barcode);

        // One Adjustment must have oneUser, while oneUser can have more than one Adjustment to Many
        modelBuilder.Entity<AdjustmentModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Adjustment);

        // One Adjustment must have oneCompany, while oneCompany can have more than one Adjustment to Many
        modelBuilder.Entity<AdjustmentModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Adjustment);

        // One Barcode must have oneUser, while oneUser can have more than one Barcode to Many
        modelBuilder.Entity<BarcodeModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Barcode);

        // One Barcode must have oneCompany, while oneCompany can have more than one Barcode to Many
        modelBuilder.Entity<BarcodeModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Barcode);

        // One Bill must have oneUser, while oneUser can have more than one Bill to Many
        modelBuilder.Entity<BillModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Bill);

        // One Bill must have oneCompany, while oneCompany can have more than one Bill to Many
        modelBuilder.Entity<BillModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Bill);

        // One Brand must have oneUser, while oneUser can have more than one Brand to Many
        modelBuilder.Entity<BrandModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Brand);

        // One Brand must have oneCompany, while oneCompany can have more than one Brand to Many
        modelBuilder.Entity<BrandModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Brand);

        // One Category must have oneUser, while oneUser can have more than one Category to Many
        modelBuilder.Entity<CategoryModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Category);

        // One Category must have oneCompany, while oneCompany can have more than one Category to Many
        modelBuilder.Entity<CategoryModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Category);

        // One Grn must have oneUser, while oneUser can have more than one Grn to Many
        modelBuilder.Entity<GrnModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Grn);

        // One Grn must have oneCompany, while oneCompany can have more than one Grn to Many
        modelBuilder.Entity<GrnModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Grn);

        // One Supplier must have oneUser, while oneUser can have more than one Supplier to Many
        modelBuilder.Entity<SupplierModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Supplier);

        // One Supplier must have oneCompany, while oneCompany can have more than one Supplier to Many
        modelBuilder.Entity<SupplierModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Supplier);

        // One Grn must have oneUser, while oneUser can have more than one Grn to Many
        modelBuilder.Entity<GrnModel>()
        .HasOne(c => c.Supplier)
        .WithMany(p => p.Grn);

        // One Hold must have oneUser, while oneUser can have more than one Hold to Many
        modelBuilder.Entity<HoldModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Hold);

        // One Hold must have oneCompany, while oneCompany can have more than one Hold to Many
        modelBuilder.Entity<HoldModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Hold);

        // One Open must have oneUser, while oneUser can have more than one Open to Many
        modelBuilder.Entity<OpenModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Open);

        // One Open must have oneCompany, while oneCompany can have more than one Open to Many
        modelBuilder.Entity<OpenModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Open);

        // One Price must have oneUser, while oneUser can have more than one Price to Many
        modelBuilder.Entity<PriceModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Price);

        // One Price must have oneCompany, while oneCompany can have more than one Price to Many
        modelBuilder.Entity<PriceModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Price);

        // One Tax must have oneUser, while oneUser can have more than one Tax to Many
        modelBuilder.Entity<TaxModel>()
        .HasOne(c => c.User)
        .WithMany(p => p.Tax);

        // One Tax must have oneCompany, while oneCompany can have more than one Tax to Many
        modelBuilder.Entity<TaxModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.Tax);

        // One User must have oneCompany, while oneCompany can have more than one User to Many
        modelBuilder.Entity<UserModel>()
        .HasOne(c => c.Company)
        .WithMany(p => p.User);

    }

    public DbSet<UserModel> AppUsers { get; set; }
    public virtual DbSet<CompanyModel> Companies { get; set; }
    public virtual DbSet<ProductModel> Products { get; set; }
    public virtual DbSet<CategoryModel> Categories { get; set; }
    public virtual DbSet<GrnModel> Grns { get; set; }
    public virtual DbSet<BarcodeModel> Barcodes { get; set; }
    public virtual DbSet<BillModel> Bills { get; set; }
    public virtual DbSet<TaxModel> Taxes { get; set; }
    public virtual DbSet<OpenModel> Opens { get; set; }
    public virtual DbSet<SupplierModel> Suppliers { get; set; }
    public virtual DbSet<BrandModel> Brands { get; set; }
    public virtual DbSet<AdjustmentModel> Adjustments { get; set; }
    public virtual DbSet<PriceModel> Prices { get; set; }
    public virtual DbSet<ProductGrn> ProductGrns { get; set; }
    public virtual DbSet<ProductOpen> ProductOpens { get; set; }
    public virtual DbSet<ProductAdjustment> ProductAdjustments { get; set; }
    public virtual DbSet<ProductPrice> ProductPrices { get; set; }
    public virtual DbSet<ProductBill> ProductBills { get; set; }
    public virtual DbSet<HoldModel> Holds { get; set; }
    public virtual DbSet<ProductHold> ProductHolds { get; set; }
}