using EventPass.Models;
using EventPass.Models.Events;
using EventPass.Models.Tickets;

namespace EventPass.Interfaces
{
    public interface IUser
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<Order> Orders { get; set; }

        public bool PutMoney(decimal money);
        public bool WithdrawMoney(decimal money);
        public bool MakeOrder(Event orderedEvent, TicketBase ticket, out int orderId);
        public bool BuyOrder(int orderId);
        public List<Order> GetListOfOrders();
        public bool DeleteAccount();
    }
}
