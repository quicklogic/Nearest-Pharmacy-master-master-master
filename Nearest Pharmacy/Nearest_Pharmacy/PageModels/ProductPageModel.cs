using FreshMvvm;
using Nearest_Pharmacy.Models;
using PropertyChanged;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    class ProductPageModel: FreshBasePageModel
    {
        IPharmacyService _pharmacyService;

        public ProductPageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;         
        }

        public Product product { get; set; }
        public ProductPageModel() { }

        public override void Init(object initData)
        {

                if (initData != null)
                {
                    product = (Product)initData;
                }
                else
                {
                    product = new Product();
                }
            }
        }
}
