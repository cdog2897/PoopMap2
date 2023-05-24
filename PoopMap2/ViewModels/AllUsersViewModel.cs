using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PoopMap2.Models;
using PoopMap2.Services;
using Realms.Sync;

namespace PoopMap2.ViewModels
{
	public partial class AllUsersViewModel : BaseViewModel
	{
        ObservableCollection<UserModel> following;

        [ObservableProperty]
        ObservableCollection<UserModel> searchList;


        [RelayCommand]
        public void OnAppearing()
        {
            following = new ObservableCollection<UserModel>(DAO.GetAllUsers());
        }

        [RelayCommand]
        public void SearchForUsers(string searchTerm)
        {
            SearchList = new ObservableCollection<UserModel>(following.Where(i => i.Username.Contains(searchTerm)).Take(30));
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

