using PoopMap2.ViewModels.Home;

namespace PoopMap2.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
