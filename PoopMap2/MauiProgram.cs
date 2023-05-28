using Camera.MAUI;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PoopMap2.ViewModels.Home;
using PoopMap2.ViewModels.Login;
using PoopMap2.ViewModels.PoopMap;
using PoopMap2.ViewModels.Profile;
using PoopMap2.Views;
using PoopMap2.Views.Login;
using PoopMap2.Views.Profile;

namespace PoopMap2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCameraView()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginView>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<RegisterView>();
		builder.Services.AddSingleton<RegisterViewModel>();
		builder.Services.AddSingleton<MainPageView>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<ProfileViewModel>();
		builder.Services.AddSingleton<ProfileView>();
		builder.Services.AddSingleton<FollowingView>();
		builder.Services.AddSingleton<FollowingViewModel>();
        builder.Services.AddSingleton<FollowersView>();
        builder.Services.AddSingleton<FollowersViewModel>();
        builder.Services.AddSingleton<EditProfileViewModel>();
        builder.Services.AddSingleton<EditProfileView>();
		builder.Services.AddSingleton<EditProfilePictureView>();
		builder.Services.AddSingleton<EditProfilePictureViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

