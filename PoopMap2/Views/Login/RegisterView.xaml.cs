using PoopMap2.ViewModels.Login;

namespace PoopMap2.Views.Login;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;

		
	}
}
