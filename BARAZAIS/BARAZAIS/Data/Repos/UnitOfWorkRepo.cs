using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class UnitOfWorkRepo : IUnitOfWorkService
{
    private readonly BarazaContext _Context;

    public UnitOfWorkRepo(BarazaContext ctx)
    {
        this._Context = ctx;
		this.Companies = new CompanyRepo(_Context);
        this.Categories = new CategoryRepo(_Context);
        this.Brands = new BrandRepo(_Context);
        this.Barcodes = new BarcodeRepo(_Context);
        this.Products = new ProductRepo(_Context);
        this.Suppliers = new SupplierRepo(_Context);
        this.Grns = new GrnRepo(_Context);
        this.Bills = new BillRepo(_Context);
        this.Taxes = new TaxRepo(_Context);
        this.Holds = new HoldRepo(_Context);
        this.Users = new UserRepo(_Context);
        this.Adjustments = new AdjustmentRepo(_Context);
        this.Prices = new PriceRepo(_Context);
        this.Opens = new OpenRepo(_Context);
        this.ProductPrices = new ProductPriceRepo(_Context);
        this.ProductGrns = new ProductGrnRepo(_Context);
        this.ProductOpens = new ProductOpenRepo(_Context);
        this.ProductAdjustments = new ProductAdjustmentRepo(_Context);
        this.ProductBills = new ProductBillRepo(_Context);
        this.ProductHolds = new ProductHoldRepo(_Context);
    }

	public ICompanyService Companies { get; private set; }
    public ICategoryService Categories { get; private set; }
    public IBrandService Brands { get; private set; }
    public IBarcodeService Barcodes { get; private set; }
    public IBillService Bills { get; private set; }
    public ITaxService Taxes { get; private set; }
    public IHoldService Holds { get; private set; }
    public IProductService Products { get; private set; }
    public ISupplierService Suppliers { get; private set; }
    public IGrnService Grns { get; private set; }
    public IOpenService Opens { get; private set; }
    public IUserService Users { get; private set; }
    public IAdjustmentService Adjustments { get; private set; }
    public IPriceService Prices { get; private set; }
    public IProductPrice ProductPrices { get; private set; }
    public IProductGrn ProductGrns { get; private set; }
    public IProductOpen ProductOpens { get; private set; }
    public IProductAdjustment ProductAdjustments { get; private set; }
    public IProductBill ProductBills { get; private set; }
    public IProductHold ProductHolds { get; private set; }

    public async Task CompleteAsync()
    {
        await _Context.SaveChangesAsync();
    }

    public void Complete()
    {
        _Context.SaveChanges();
    }

    public void Dispose()
    {
        _Context.Dispose();
    }
}