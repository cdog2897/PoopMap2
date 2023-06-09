﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PoopMap2.Models;
using PoopMap2.Services;
using PoopMap2.Views;
using PoopMap2.Views.Profile;

namespace PoopMap2.ViewModels.Profile
{
	public partial class ProfileViewModel : BaseViewModel
	{
		[ObservableProperty]
		public ImageSource profilePic;
		
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
            Followers = DAO.GetFollowers(thisUser.AppId).Count();
			Poops = DAO.GetPoopsOfUser(thisUser.AppId).Count();
			ProfilePic = PhotoService.ConvertBase64ToImageSource(thisUser.ProfilePic);
            OnPropertyChanged();
        }

		[RelayCommand]
		public async Task EditProfile_Clicked()
		{
			await Shell.Current.GoToAsync($"{nameof(EditProfileView)}");
		}

		[RelayCommand]
		public async Task Img_Clicked()
		{
			await Shell.Current.GoToAsync($"{nameof(EditProfilePictureView)}");
        }

		[RelayCommand]
		public async Task Following_Clicked()
		{
			await Shell.Current.GoToAsync($"{nameof(FollowingView)}");
        }

        [RelayCommand]
        public async Task Followers_Clicked()
        {
            await Shell.Current.GoToAsync($"{nameof(FollowersView)}");
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

