using System;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Services;
using PoopMap2.Views;

namespace PoopMap2.ViewModels.Login
{
	public partial class RegisterViewModel : BaseViewModel
	{


        public string Username { get; set; }

        public string Password { get; set; }


        [RelayCommand]
        public async Task SignUp()
        {
            if (!await VeryifyEmailAndPassword())
            {
                return;
            }

            await DoSignup();
        }

        private async Task DoSignup()
        {
            try
            {
                IsBusy = true;
                await RealmService.RegisterAsync(Username, Password);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await DialogService.ShowAlertAsync("Sign up failed", ex.Message, "Ok");
                return;
            }

            await DialogService.ShowAlertAsync("Success!", "Please Login", "Ok");
            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
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

