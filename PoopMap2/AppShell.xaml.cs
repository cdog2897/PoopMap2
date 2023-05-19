using PoopMap2.Views;

namespace PoopMap2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
    }
}

