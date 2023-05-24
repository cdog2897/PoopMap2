﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PoopMap2.Models;
using PoopMap2.Services;
using PoopMap2.Views;

namespace PoopMap2.ViewModels.Profile
{
	public partial class ProfileViewModel : BaseViewModel
	{

		[ObservableProperty]
		public string username;

		[ObservableProperty]
		public string bio;

		[ObservableProperty]
		public int poops;

		[ObservableProperty]
		public int followers;

		[ObservableProperty]
		public int following;

		public UserModel thisUser;

		[RelayCommand]
		public void OnAppearing()
		{
            thisUser = DAO.GetUserById(RealmService.CurrentUser.Id);
            Username = thisUser.Username;
            Bio = thisUser.Bio;
            Following = JsonConvert.DeserializeObject<List<string>>(thisUser.Following).Count();
            Followers = 0;
            OnPropertyChanged();
        }

		[RelayCommand]
		public async Task Following_Clicked()
		{
			await Shell.Current.GoToAsync($"{nameof(FollowingView)}");
        }

		[RelayCommand]
		public async Task Logout()
		{
            IsBusy = true;
            await RealmService.LogoutAsync();
            IsBusy = false;

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }

		[RelayCommand]
		public async Task AllUsers()
		{
			await Shell.Current.GoToAsync($"{nameof(AllUsersView)}");
		}

		[RelayCommand]
		public async Task Search()
		{
			await Shell.Current.GoToAsync($"{nameof(AllUsersView)}");
		}


	}
}
