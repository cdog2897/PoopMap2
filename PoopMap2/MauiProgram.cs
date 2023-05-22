using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PoopMap2.ViewModels.Login;
using PoopMap2.Views;
using PoopMap2.Views.Login;

namespace PoopMap2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginView>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<RegisterView>();
		builder.Services.AddSingleton<RegisterViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

