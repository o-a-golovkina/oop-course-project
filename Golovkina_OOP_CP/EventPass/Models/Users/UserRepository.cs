using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventPass.Models.Users
{
    public static class UserRepository
    {
        private static string FilePath = "users.json";

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

        public static void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    Converters = { new DateOnlyJsonConverter() }
                };
                var json = JsonSerializer.Serialize(Users, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error saving users: {ex.Message}");
            }
        }

        public static void LoadFromFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return;

                var options = new JsonSerializerOptions
                {
                    Converters = { new DateOnlyJsonConverter() }
                };

                var json = File.ReadAllText(FilePath);
                var usersFromFile = JsonSerializer.Deserialize<List<RegisteredUser>>(json, options);

                Users = usersFromFile ?? [];
                foreach (var user in Users)
                    RegisteredUser.RegisterLogin(user.Login);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error loading users: {ex.Message}");
            }
        }
    }
}
