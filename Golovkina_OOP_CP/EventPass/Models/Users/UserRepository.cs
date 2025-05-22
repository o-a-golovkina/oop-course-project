using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                Converters = { new DateOnlyJsonConverter() }
            };
            var json = JsonSerializer.Serialize(Users, options);
            File.WriteAllText(filePath, json);
        }

        public static void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };

            var json = File.ReadAllText(filePath);
            var usersFromFile = JsonSerializer.Deserialize<List<RegisteredUser>>(json, options);

            Users = usersFromFile ?? [];
            foreach (var user in Users)
                RegisteredUser.RegisterLogin(user.Login);
        }
    }
}
