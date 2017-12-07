using FreshMvvm;
using Nearest_Pharmacy.PageModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nearest_Pharmacy
{
    [ImplementPropertyChanged]
    public class CustomNavigation : Xamarin.Forms.MasterDetailPage
    {

        public bool IsAuth;
        public CustomNavigation()
        {
           
            var masterDetailNav = new FreshMasterDetailNavigationContainer();
            masterDetailNav.Init("Меню");
            masterDetailNav.AddPage<ProductListPageModel>("Главная страница", null);
            masterDetailNav.SwitchSelectedRootPageModel<ProductListPageModel>();
            if (!IsAuth)
            {
               masterDetailNav.AddPage<LoginPageModel>("Войти", null);
               masterDetailNav.AddPage<RegisterPageModel>("Регистрация", null);
            }
            else
            {
                masterDetailNav.AddPage<LoginPageModel>("Профиль", null);
                masterDetailNav.AddPage<RegisterPageModel>("Корзина", null);
                masterDetailNav.AddPage<RegisterPageModel>("Заказы", null);
            }
            
        }

       
    }
}
