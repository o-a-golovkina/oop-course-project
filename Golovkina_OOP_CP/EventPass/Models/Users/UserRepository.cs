using Newtonsoft.Json;
using System.IO;

namespace EventPass.Models.Users
{
    public static class UserRepository
    {
        public static List<RegisteredUser> Users { get; private set; } = [];

        public static bool AddUser(RegisteredUser user)
        {
            if (Users.Any(u => u.Login == user.Login))
                return false;

            Users.Add(user);
            RegisteredUser.RegisterLogin(user.Login);
            return true;
        }

        public static bool RemoveUser(string login)
        {
            var user = Users.Find(u => u.Login == login);
            if (user == null) return false;

            RegisteredUser.UnregisterLogin(user.Login);
            return Users.Remove(user);
        }

        public static void SaveToFile(string filePath)
        {
            string jsonstring = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(filePath, jsonstring);
        }

        public static void LoadFromFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            Users.AddRange(JsonConvert.DeserializeObject<List<RegisteredUser>>(text)!);
        }
    }
}
