using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Services;
using PoopMap2.Views;

namespace PoopMap2.ViewModels.Home
{
	public partial class MainPageViewModel : BaseViewModel
	{
        string full = "poop_full.png";
        string empty = "poop_empty.png";

        [ObservableProperty]
		public string img1 = "poop_full.png";
        [ObservableProperty]
        public string img2 = "poop_full.png";
        [ObservableProperty]
        public string img3 = "poop_empty.png";
        [ObservableProperty]
        public string img4 = "poop_empty.png";
        [ObservableProperty]
        public string img5 = "poop_empty.png";

        [RelayCommand]
		public async Task Logout()
		{
            IsBusy = true;
            await RealmService.LogoutAsync();
            IsBusy = false;

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }

		[RelayCommand]
		public void img1_Clicked()
		{
            Img1 = full;
            Img2 = empty;
            Img3 = empty;
            Img4 = empty;
            Img5 = empty;
            OnPropertyChanged();
		}
        [RelayCommand]
        public void img2_Clicked()
        {
            Img1 = full;
            Img2 = full;
            Img3 = empty;
            Img4 = empty;
            Img5 = empty;
            OnPropertyChanged();
        }
        [RelayCommand]
        public void img3_Clicked()
        {
            Img1 = full;
            Img2 = full;
            Img3 = full;
            Img4 = empty;
            Img5 = empty;
            OnPropertyChanged();
        }
        [RelayCommand]
        public void img4_Clicked()
        {
            Img1 = full;
            Img2 = full;
            Img3 = full;
            Img4 = full;
            Img5 = empty;
            OnPropertyChanged();
        }
        [RelayCommand]
        public void img5_Clicked()
        {
            Img1 = full;
            Img2 = full;
            Img3 = full;
            Img4 = full;
            Img5 = full;
            OnPropertyChanged();
        }
    }
}

