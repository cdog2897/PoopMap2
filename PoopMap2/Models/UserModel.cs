using System;
using MongoDB.Bson;
using Realms;

namespace PoopMap2.Models
{
    public partial class UserModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("appId")]
        public string AppId { get; set; }

        [MapTo("following")]
        public string Following { get; set; }

        [MapTo("username")]
        public string Username { get; set; }

        [MapTo("bio")]
        public string Bio { get; set; }

    }
}

