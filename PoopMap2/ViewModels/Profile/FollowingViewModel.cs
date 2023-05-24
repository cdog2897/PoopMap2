using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PoopMap2.Models;
using PoopMap2.Services;

namespace PoopMap2.ViewModels.Profile
{
	public partial class FollowingViewModel : BaseViewModel
	{
		[ObservableProperty]
		ObservableCollection<UserModel> following;

		[RelayCommand]
		public void OnAppearing()
		{
			UserModel thisUser = DAO.GetUserById(RealmService.CurrentUser.Id);
			List<string> followingString = JsonConvert.DeserializeObject<List<string>>(thisUser.Following);
            ObservableCollection<UserModel> followingList = new();

            foreach (string s in followingString)
			{
				followingList.Add(DAO.GetUserById(s));
			}


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

