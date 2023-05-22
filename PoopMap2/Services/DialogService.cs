using System;
using CommunityToolkit.Maui.Views;
using PoopMap2.Views;

namespace PoopMap2.Services
{
	public class DialogService
	{
        public static Action ShowActivityIndicator()
        {
            var popup = new BusyPopup();
            Application.Current.MainPage.ShowPopup(popup);
            return () => popup.Close();
        }

        public static Task ShowAlertAsync(string title, string message, string accept)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, accept);
        }
    }
}

