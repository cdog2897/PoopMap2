using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Services;

namespace PoopMap2.ViewModels.Profile
{
	public partial class EditProfilePictureViewModel : BaseViewModel
	{
		[ObservableProperty]
		public ImageSource profilePic;

		[ObservableProperty]
		public Camera.MAUI.CameraView cameraView;

		[RelayCommand]
		public async Task UpdateProfilePic(string imageStr)
		{
			IsBusy = true;
            await DAO.UpdateProfilePic(imageStr, RealmService.CurrentUser.Id);
			IsBusy = false;
        }

    }
}

