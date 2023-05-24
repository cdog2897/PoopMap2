using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PoopMap2.Models;
using PoopMap2.Services;

namespace PoopMap2.ViewModels
{
	public partial class AllUsersViewModel : BaseViewModel
	{
        [ObservableProperty]
        ObservableCollection<UserModel> following;

        [RelayCommand]
        public void OnAppearing()
        {
            ObservableCollection<UserModel> followingList = new ObservableCollection<UserModel>(DAO.GetAllUsers());
            Following = followingList;
        }

        [RelayCommand]
        public async Task Follow_Clicked(string userId)
        {
            IsBusy = true;
            await DAO.FollowUser(RealmService.CurrentUser.Id, userId);
            IsBusy = false;
            OnAppearing();
        }

        [RelayCommand]
        public async Task Unfollow_Clicked(string userId)
        {
            IsBusy = true;
            await DAO.UnfollowUser(RealmService.CurrentUser.Id, userId);
            IsBusy = false;
            OnAppearing();
        }
    }
}

