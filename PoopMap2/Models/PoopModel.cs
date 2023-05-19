using System;
using MongoDB.Bson;
using Realms;

namespace PoopMap2.Models
{
    public partial class PoopModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("description")]
        public string Description { get; set; }

        [MapTo("dateTime")]
        public DateTimeOffset DateTime { get; set; }

        [MapTo("location")]
        public string Location { get; set; }

        [MapTo("rating")]
        public int Rating { get; set; }

        [MapTo("image")]
        public string Image { get; set; }

        [MapTo("owner")]
        public string Owner { get; set; }


        public PoopModel(DateTime dateTime, string location)
        {
            this.DateTime = dateTime;
            this.Location = location;
        }

        public PoopModel() { }

    }
}

