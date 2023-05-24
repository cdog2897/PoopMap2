using PoopMap2.ViewModels.Profile;

namespace PoopMap2.Views;

public partial class FollowingView : ContentPage
{
	public FollowingView(FollowingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
