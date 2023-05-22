using System;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Services;
using PoopMap2.Views;

namespace PoopMap2.ViewModels.Home
{
	public partial class MainPageViewModel : BaseViewModel
	{


		[RelayCommand]
		public async Task Logout()
		{
            IsBusy = true;
            await RealmService.LogoutAsync();
            IsBusy = false;

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }



	}
}

