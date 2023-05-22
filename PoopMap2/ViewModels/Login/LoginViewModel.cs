using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Services;
using PoopMap2.Views;
using PoopMap2.Views.Login;

namespace PoopMap2.ViewModels.Login
{
	public partial class LoginViewModel : BaseViewModel
	{

        public string Username { get; set; }

        public string Password { get; set; }

        [RelayCommand]
        public async Task SignUpRedirect()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterView)}");
        }

        [RelayCommand]
        public async Task OnAppearing()
        {
            RealmService.Init();

            if (RealmService.CurrentUser != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPageView)}");
            }
        }

        [RelayCommand]
        public async Task Login()
        {
            if (!await VeryifyEmailAndPassword())
            {
                return;
            }

            await DoLogin();
        }

        private async Task DoLogin()
        {
            try
            {
                IsBusy = true;
                await RealmService.LoginAsync(Username, Password);
                // create a usermodel of the user if not already made:
                await DAO.CreateUser(RealmService.CurrentUser.Id, Username);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await DialogService.ShowAlertAsync("Login failed", ex.Message, "Ok");
                return;
            }

            await Shell.Current.GoToAsync($"//{nameof(MainPageView)}");
        }

        private async Task<bool> VeryifyEmailAndPassword()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await DialogService.ShowAlertAsync("Error", "Please specify both the email and the password", "Ok");
                return false;
            }

            return true;
        }

        
    }
}

