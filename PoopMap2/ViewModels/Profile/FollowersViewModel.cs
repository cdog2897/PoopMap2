using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using PoopMap2.Models;
using PoopMap2.Services;

namespace PoopMap2.ViewModels.Profile
{
	public partial class FollowersViewModel : BaseViewModel
	{
        [ObservableProperty]
        ObservableCollection<string> followers;

        [RelayCommand]
        public void OnAppearing()
        {
            Followers = new();
            var listUsers = DAO.GetFollowers(RealmService.CurrentUser.Id);
            foreach(UserModel user in listUsers)
            {
                Followers.Add(user.Username);
            }
        }
    }
}

