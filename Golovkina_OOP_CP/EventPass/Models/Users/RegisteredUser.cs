using EventPass.Interfaces;
using EventPass.Models.Events;
using EventPass.Models.Tickets;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;

namespace EventPass.Models.Users
{
    [JsonObject]
    public class RegisteredUser : IUser, IEnumerable<Order>
    {
        private static readonly HashSet<string> ExistingLogins = [];

        private string? fullName;
        private DateOnly birthDate;
        private string? phoneNumber;
        private string? email;
        private string? login;
        private string? password;
        private decimal balance;

        public static event Action<string>? UserRegistered;

        [JsonProperty]
        public string FullName
        {
            get => fullName!;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty");

                var parts = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2 || parts.Any(p => p.Length < 3))
                    throw new ArgumentException("Full name: 2+ words, 3+ chars each");

                fullName = value;
            }
        }

        [JsonProperty]
        public DateOnly BirthDate
        {
            get => birthDate;
            set
            {
                if (value.Year < 1950)
                    throw new ArgumentException("Birth year must be no earlier than 1950");
                birthDate = value;
            }
        }

        [JsonProperty]
        public string PhoneNumber
        {
            get => phoneNumber!;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{9}$"))
                    throw new ArgumentException("Phone number must contain exactly 9 digits");
                phoneNumber = "(+380)" + value;
            }
        }

        [JsonProperty]
        public string Email
        {
            get => email!;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || !value.Contains('@') || !value.Contains('.'))
                    throw new ArgumentException("Email: 5+ chars, must include \"@\" and \".\"");
                email = value;
            }
        }

        [JsonProperty]
        public string Login
        {
            get => login!;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Login cannot be empty");

                if (login != null)
                    ExistingLogins.Remove(login); // удалить старый

                if (ExistingLogins.Contains(value))
                    throw new ArgumentException("This login is already taken");

                login = value;
            }
        }

        [JsonProperty]
        public string Password
        {
            get => password!;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 8 ||
                    !Regex.IsMatch(value, @"[A-Za-z]") || !Regex.IsMatch(value, @"\d"))
                    throw new ArgumentException("Password: 8+ chars, letters & digits required");

                password = value;
            }
        }

        [JsonIgnore]
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                balance = value;
            }
        }

        [JsonIgnore]
        public List<Order> Orders { get; set; } = [];

        RegisteredUser() { }

        public RegisteredUser(string? fullName, DateOnly birthDate, string? phoneNumber, string? email, string? login, string? password)
        {
            FullName = fullName!;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber!;
            Email = email!;
            Login = login!;
            Password = password!;
            UserRegistered?.Invoke(Login);
            ExistingLogins.Add(login!);
        }

        public static void RegisterLogin(string login) => ExistingLogins.Add(login);
        public static void UnregisterLogin(string login) => ExistingLogins.Remove(login);

        public static bool SignIn(string? login, string? password, out RegisteredUser user)
        {
            user = UserRepository.Users.FirstOrDefault(u => u.Login == login && u.Password == password)!;
            if (user != null)
                return true;
            else return false;
        }

        public bool PutMoney(decimal money)
        {
            if (money <= 0) return false;
            Balance += money;
            return true;
        }

        public bool WithdrawMoney(decimal money)
        {
            if (money <= 0 || money > Balance) return false;
            Balance -= money;
            return true;
        }

        public bool MakeOrderAndBuy(Event orderedEvent, TicketBase ticket, out int orderId)
        {
            orderId = -1;

            if (orderedEvent.CountFreeTickets == 0 || ticket == null)
                return false;

            if (Balance < ticket.Price)
                return false;

            var newOrder = new Order(Login, orderedEvent, ticket.Price, ticket);
            Orders.Add(newOrder);

            orderedEvent.Tickets.Remove(ticket);
            orderedEvent.CountFreeTickets--;

            Balance -= ticket.Price;
            orderId = newOrder.Id;

            return true;
        }

        public List<Order> GetListOfOrders()
        {
            return Orders;
        }

        public bool DeleteAccount()
        {
            ExistingLogins.Remove(Login);
            return UserRepository.RemoveUser(Login!);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return Orders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GenerateOrderId()
        {
            return Orders.Count > 0 ? Orders.Max(o => o.Id) + 1 : 1;
        }
    }
}
