using PoopMap2.ViewModels.Profile;

namespace PoopMap2.Views;

public partial class FollowersView : ContentPage
{
	public FollowersView(FollowersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
