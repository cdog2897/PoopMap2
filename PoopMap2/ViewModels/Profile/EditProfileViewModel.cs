using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Platform;
using PoopMap2.Services;
using PoopMap2.Views.Profile;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace PoopMap2.ViewModels.Profile
{
	public partial class EditProfileViewModel : BaseViewModel
	{

		[ObservableProperty]
		public ImageSource profilePic;

		[ObservableProperty]
		public string username;

		[RelayCommand]
		public void OnAppearing()
		{
			var thisUser = DAO.GetUserById(RealmService.CurrentUser.Id);
			ProfilePic = PhotoService.ConvertBase64ToImageSource(thisUser.ProfilePic);
			Username = thisUser.Username;
		}

        [RelayCommand]
		public async Task Profile_Clicked()
		{
			await Shell.Current.GoToAsync($"{nameof(EditProfilePictureView)}");
		}

    }
}

