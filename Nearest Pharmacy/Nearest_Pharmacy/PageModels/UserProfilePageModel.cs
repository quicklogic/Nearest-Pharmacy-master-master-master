using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Nearest_Pharmacy.Models;
using Xamarin.Forms;

namespace Nearest_Pharmacy.PageModels
{
    class UserProfilePageModel: FreshBasePageModel
    {
        IPharmacyService _pharmacyService;

        public UserProfilePageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
            isEdit = false;
            Mode = "Редактировать";
        }

        public bool isEdit { get; set; }
        public string Mode { get; set; }

        public UserInfo User;

        public async override void Init(object initData)
        {
            string login = Convert.ToString(Xamarin.Forms.Application.Current.Properties["UserLogin"]);
            await Initial(login);
        }

        public async Task Initial(string login)
        {
            User = await _pharmacyService.GetUserInfo(login);
        }
        public ICommand editBtn => new Command(async (value) =>
        {
            if(isEdit != true)
            {
                isEdit = true;
                Mode = "Сохранить";
            }
            else
            {
                isEdit = false;
                Mode = "Редактировать";
            }

        });
    }
}
