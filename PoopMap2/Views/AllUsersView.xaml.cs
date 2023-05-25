using PoopMap2.ViewModels;

namespace PoopMap2.Views;

public partial class AllUsersView : ContentPage
{
	public AllUsersView()
	{
		InitializeComponent();
		BindingContext = new AllUsersViewModel();

    }

	
}
