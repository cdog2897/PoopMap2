using PoopMap2.ViewModels.Profile;
using PoopMap2.Views;
using PoopMap2.Views.Login;

namespace PoopMap2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
		Routing.RegisterRoute(nameof(FollowingView), typeof(FollowingView));
        Routing.RegisterRoute(nameof(AllUsersView), typeof(AllUsersView));
        Routing.RegisterRoute(nameof(FollowersView), typeof(FollowersView));
    }

}

