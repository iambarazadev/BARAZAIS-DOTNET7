using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;

public interface IUnitOfWorkService : IDisposable
{
	ICompanyService Companies { get; }
    ICategoryService Categories { get; }
    IBrandService Brands { get; }
    IBarcodeService Barcodes { get; }
    ISupplierService Suppliers { get; }
    IGrnService Grns { get; }
    IOpenService Opens { get; }
    IBillService Bills { get; }
    ITaxService Taxes { get; }
    IHoldService Holds { get; }
    IProductService Products { get; }
    IUserService Users { get; }
    IAdjustmentService Adjustments { get; }
    IPriceService Prices { get; }
    IProductPrice ProductPrices { get; }
    IProductGrn ProductGrns { get; }
    IProductOpen ProductOpens { get; }
    IProductAdjustment ProductAdjustments { get; }
    IProductBill ProductBills { get; }
    IProductHold ProductHolds { get; }
    Task CompleteAsync();
    void Complete();
    void Dispose();
}
