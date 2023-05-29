
using PoopMap2.Services;
using PoopMap2.ViewModels.Profile;

namespace PoopMap2.Views.Profile;

public partial class EditProfilePictureView : ContentPage
{
	public EditProfilePictureView(EditProfilePictureViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void cameraView_CamerasLoaded(System.Object sender, System.EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.ElementAt(cameraView.Cameras.Count() - 1);
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StartCameraAsync();
            cameraView.MirroredImage = true;
        });
    }

    public async void Button_Clicked(System.Object sender, System.EventArgs e)
    {

        string imageStr = await PhotoService.ConvertImageSourceToBase64(cameraView.GetSnapShot());
        var viewModel = (EditProfilePictureViewModel)BindingContext;
        if (viewModel.UpdateProfilePicCommand.CanExecute(imageStr))
            viewModel.UpdateProfilePicCommand.Execute(imageStr);

    }
}
