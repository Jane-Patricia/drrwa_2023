using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi{
    public class User
    {
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public User (string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

