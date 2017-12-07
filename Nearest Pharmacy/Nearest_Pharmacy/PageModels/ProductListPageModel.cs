using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using Nearest_Pharmacy.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    class ProductListPageModel : FreshBasePageModel
    {

        public ObservableCollection<ProductPair> Products { get; set; }
        public IPharmacyService _pharmacyService;
        public bool IsBusy { get; set; }


        public ProductListPageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
            Products = new ObservableCollection<ProductPair>();
        }



        public override void Init(object initData)
        {
            base.Init(initData);
            LoadProducts();
        }


        public async void LoadProducts()
        {
            IsBusy = true;
            ObservableCollection<Product> product = new ObservableCollection<Product>();
            ProductPair productPair;
            Products.Clear();
            IEnumerable<Product> getProduct = await _pharmacyService.GetProduct();

            foreach (Product p in getProduct)
            {
                product.Add(p);
            }

            for (int j = 0; j < getProduct.Count(); j += 2)
            {             
                if (j + 1 <= product.Count)
                {
                    productPair = new ProductPair(product[j], product[j + 1]);       
                    Products.Add(productPair);
                }
            }
            IsBusy = false;
            product = null;
        }

        public ICommand SelectCommand => new Command(async (value) =>
        {
            await CoreMethods.PushPageModel<ProductPageModel>(value);
        });

    }
} 

