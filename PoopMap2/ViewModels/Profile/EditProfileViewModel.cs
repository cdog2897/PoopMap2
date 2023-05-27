using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Platform;
using PoopMap2.Services;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace PoopMap2.ViewModels.Profile
{
	public partial class EditProfileViewModel : BaseViewModel
	{


		[ObservableProperty]
		public string text = "Welcome!";


        [RelayCommand]
		public async Task ChangeImage_Clicked()
		{

		}


		//[RelayCommand]
		//public async Task ChangeImage_Clicked()
		//{
  //          byte[] bytes = null;
  //          if (MediaPicker.Default.IsCaptureSupported)
  //          {
  //              FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

  //              if (photo != null)
  //              {
  //                  IImage image;
  //                  using(Stream stream = await photo.OpenReadAsync())
  //                  {
  //                      image = PlatformImage.FromStream(stream);
  //                  }


  //                  //convert image to bytes
  //                  bytes = await PhotoService.ConvertImageToBytes(photo);
  //              }
  //          }

  //          if (bytes != null)
  //          {
  //              // convert bytes to imagesource
  //              ImageSource imgSource = PhotoService.ConvertBytesToImage(bytes);


  //          }
  //      }


    }
}

