using System;
using PoopMap2.Models;
using Realms;
using Realms.Sync;

namespace PoopMap2.Services
{
    public static class RealmService
    {

        private static bool serviceInitialised;

        private static Realms.Sync.App app;

        private static Realm mainThreadRealm;

        public static User CurrentUser => app.CurrentUser;


        public static void Init()
        {
            if (serviceInitialised)
            {
                return;
            }

            var appConfiguration = new Realms.Sync.AppConfiguration("application-0-vxmyn")
            {
                BaseUri = new Uri("https://realm.mongodb.com")
            };

            app = Realms.Sync.App.Create(appConfiguration);

            serviceInitialised = true;
        }

        public static Realm GetMainThreadRealm()
        {
            return mainThreadRealm ??= GetRealm();
        }

        public static Realm GetRealm()
        {
            var config = new FlexibleSyncConfiguration(app.CurrentUser)
            {
                PopulateInitialSubscriptions = (realm) =>
                {
                    var allPoops = realm.All<PoopModel>();
                    realm.Subscriptions.Add(allPoops);

                    var allUsers = realm.All<UserModel>();
                    realm.Subscriptions.Add(allUsers);
                }
            };

            return Realm.GetInstance(config);
        }



        public static async Task LoginAsync(string email, string password)
        {
            await app.LogInAsync(Credentials.EmailPassword(email, password));

            //This will populate the initial set of subscriptions the first time the realm is opened
            using var realm = GetRealm();
            await realm.Subscriptions.WaitForSynchronizationAsync();
        }

        public static async Task LogoutAsync()
        {
            await app.CurrentUser.LogOutAsync();
            mainThreadRealm?.Dispose();
            mainThreadRealm = null;
        }

        public static async Task RegisterAsync(string email, string password)
        {
            await app.EmailPasswordAuth.RegisterUserAsync(email, password);
        }
    }
}

