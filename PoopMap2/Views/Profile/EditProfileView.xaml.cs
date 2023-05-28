using Camera.MAUI;
using PoopMap2.ViewModels.Profile;

namespace PoopMap2.Views.Profile;

public partial class EditProfileView : ContentPage
{
	public EditProfileView(EditProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}

    void cameraView_CamerasLoaded(System.Object sender, System.EventArgs e)
    {
        //cameraView.Camera = cameraView.Cameras.First();
        //MainThread.BeginInvokeOnMainThread(async () =>
        //{
        //    await cameraView.StartCameraAsync();
        //});


    }
}
