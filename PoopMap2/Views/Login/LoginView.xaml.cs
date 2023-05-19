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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        RealmService.Init();
        if (RealmService.CurrentUser != null)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPageView)}");
        }
    }

    public async void LoginBtn_Clicked(System.Object sender, System.EventArgs e)
	{
        await RealmService.LoginAsync(Username.Text, Password.Text);

        if (RealmService.CurrentUser != null)
        {
            // create usermodel for user
            await DAO.CreateUser(RealmService.CurrentUser.Id, Username.Text);
            await Shell.Current.GoToAsync($"//{nameof(MainPageView)}");
        }
        else
        {
            await DisplayAlert("Error logging in", "An error occured", "OK");
        }
    }
}
