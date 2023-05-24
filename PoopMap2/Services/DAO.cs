using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using PoopMap2.Models;

namespace PoopMap2.Services
{
    public static class DAO
    {

        public static List<PoopModel> GetAllPoops()
        {
            var realm = RealmService.GetMainThreadRealm();

            var poops = realm.All<PoopModel>().ToList();

            return poops;
        }

        public static async Task CreatePoop(PoopModel p)
        {
            var realm = RealmService.GetMainThreadRealm();

            await realm.WriteAsync(() =>
            {
                realm.Add(new PoopModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    DateTime = p.DateTime,
                    Rating = p.Rating,
                    Location = p.Location,
                    Owner = RealmService.CurrentUser.Id,
                    Image = p.Image

                });
            });
        }

        public static ObservableCollection<PoopModel> GetRecentPoopsObs(int index)
        {
            List<PoopModel> allPoops = DAO.GetAllPoops();
            ObservableCollection<PoopModel> returnThis = new ObservableCollection<PoopModel>();

            for (int i = index; i < index + 10; i++)
            {
                try
                {
                    returnThis.Add(allPoops.ElementAt(i));
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            return returnThis;

        }

        public static PoopModel GetById(ObjectId id)
        {
            var realm = RealmService.GetMainThreadRealm();
            var poop = realm.All<PoopModel>().Where(i => i.Id == id).First();
            return poop;
        }

        public static UserModel GetUserById(string id)
        {
            var realm = RealmService.GetMainThreadRealm();
            var user = realm.All<UserModel>().Where(i => i.AppId == id).First();
            return user;
        }

        public static List<PoopModel> GetPoopsOfUser(string id)
        {
            var allPoops = DAO.GetAllPoops();
            var userPoops = new List<PoopModel>();

            foreach (PoopModel p in allPoops)
            {
                if (p.Owner == id)
                {
                    userPoops.Add(p);
                }
            }

            return userPoops;
        }

        public static List<UserModel> GetAllUsers()
        {
            var realm = RealmService.GetMainThreadRealm();

            var users = realm.All<UserModel>().ToList();

            return users;
        }

        public static List<UserModel> GetFollowing(string appId)
        {
            var realm = RealmService.GetMainThreadRealm();
            var thisUser = DAO.GetUserById(appId);

            var users = realm.All<UserModel>().ToList();

            List<string> followList = JsonConvert.DeserializeObject<List<string>>(thisUser.Following);

            List<UserModel> returnThis = new List<UserModel>();

            foreach (string follower in followList)
            {
                foreach (UserModel user in users)
                {
                    if (follower == user.AppId)
                    {
                        returnThis.Add(user);
                    }
                }
            }

            return returnThis;

        }

        public async static Task CreateUser(string id, string username)
        {
            // check if user is already in database:
            var allUsers = DAO.GetAllUsers();
            foreach (UserModel u in allUsers)
            {
                if (u.AppId == id)
                {
                    return;
                }
            }

            var realm = RealmService.GetMainThreadRealm();
            await realm.WriteAsync(() =>
            {
                realm.Add(new UserModel()
                {
                    Username = username,
                    AppId = id,
                    Following = JsonConvert.SerializeObject(new List<string> { id })
                });
            });

        }

        public async static Task UpdateUserBio(string id, string bio)
        {
            var realm = RealmService.GetMainThreadRealm();
            await realm.WriteAsync(() =>
            {
                var thisUser = realm.All<UserModel>().Where(i => i.AppId == id).First();
                thisUser.Bio = bio;
            });
        }

        public async static Task UpdateFriendsLists(string id, string stringToUpdate)
        {
            var realm = RealmService.GetMainThreadRealm();
            await realm.WriteAsync(() =>
            {
                var thisUser = realm.All<UserModel>().Where(i => i.AppId == id).First();
                thisUser.Following = stringToUpdate;
            });
        }

        public static async Task DeletePoopById(ObjectId id)
        {
            var realm = RealmService.GetMainThreadRealm();
            await realm.WriteAsync(() =>
            {
                var poop = realm.All<PoopModel>().Where(i => i.Id == id).First();
                realm.Remove(poop);
                poop = null;
            });
        }

        public static async Task FollowUser(string thisUserId, string userToFollowId)
        {
            var thisUser = DAO.GetUserById(thisUserId);

            List<string> following = JsonConvert.DeserializeObject<List<string>>(thisUser.Following);
            following.Add(userToFollowId);
            string followingString = JsonConvert.SerializeObject(following);

            await DAO.UpdateFriendsLists(RealmService.CurrentUser.Id, followingString);
        }

        public static List<UserModel> SearchForUsers(string searchTerm)
        {
            var realm = RealmService.GetMainThreadRealm();
            var results = realm.All<UserModel>().Where(i => i.Username.Contains(searchTerm)).ToList();

            return results;
        }

        public static async Task UnfollowUser(string thisUserId, string userToUnfollow)
        {
            var thisUser = DAO.GetUserById(thisUserId);
            List<string> following = JsonConvert.DeserializeObject<List<string>>(thisUser.Following);
            List<string> endFollowing = new List<string>();
            foreach (string s in following)
            {
                if (s != userToUnfollow)
                {
                    endFollowing.Add(s);
                }

            }
            string followingString = JsonConvert.SerializeObject(endFollowing);
            await DAO.UpdateFriendsLists(thisUserId, followingString);
        }
    }
}

