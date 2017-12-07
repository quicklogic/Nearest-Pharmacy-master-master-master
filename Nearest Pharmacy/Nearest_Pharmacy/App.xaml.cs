using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;

using Xamarin.Forms;
using Nearest_Pharmacy.PageModels;
using Nearest_Pharmacy.Models;

namespace Nearest_Pharmacy
{
    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IPharmacyService, PharmacyService>();
            var masterDetailNav = new FreshMasterDetailNavigationContainer();

            var homePage = FreshPageModelResolver.ResolvePageModel<ProductListPageModel>();
            masterDetailNav.Detail = new FreshNavigationContainer(homePage);
            var homePageModel = homePage.GetModel();

            var menuPage = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(homePageModel);
            masterDetailNav.Master = menuPage;

            homePageModel.CoreMethods.PopToRoot(true);

            MainPage = masterDetailNav;

        }



        protected override void OnStart()
        {         
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
