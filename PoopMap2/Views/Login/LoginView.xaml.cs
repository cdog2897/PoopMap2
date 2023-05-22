using CommunityToolkit.Maui.Views;
using PoopMap2.Services;
using PoopMap2.ViewModels.Login;

namespace PoopMap2.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;

        
    }


}
