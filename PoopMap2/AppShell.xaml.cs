using PoopMap2.Views;
using PoopMap2.Views.Login;

namespace PoopMap2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

       // Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
		Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
		//Routing.RegisterRoute(nameof(PoopMapView), typeof(PoopMapView));
    }
}

