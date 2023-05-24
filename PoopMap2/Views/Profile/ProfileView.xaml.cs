using PoopMap2.ViewModels.Profile;

namespace PoopMap2.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
