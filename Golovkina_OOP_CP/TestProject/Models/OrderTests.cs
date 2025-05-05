using EventPass.Models;
using EventPass.Models.Events;
using EventPass.Models.Tickets;

namespace UnitTests.Models
{
    [TestClass]
    public class OrderTests
    {
        private Event CreateSampleEvent() =>
            new Event("Concert", DateTime.Now.AddDays(10), 100m, "Kharkiv", @"C:\images\event.jpg", 200, EventType.ConcertEvent);

        private TicketBase CreateSampleTicket() =>
            new ConcertTicket(1, 100m, "Artem Pivovarov");

        [TestMethod]
        [DataRow("", false)]
        [DataRow("  ", false)]
        [DataRow(null, false)]
        [DataRow("validUser", true)]
        public void UserLoginValidation(string userLogin, bool expectedIsValid)
        {
            try
            {
                var order = new Order(userLogin, CreateSampleEvent(), 50, CreateSampleTicket());
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [TestMethod]
        [DataRow("100", true)]
        [DataRow("0", false)]
        [DataRow("-50", false)]
        public void PriceValidation(string strPrice, bool expectedIsValid)
        {
            try
            {
                decimal price = decimal.Parse(strPrice);
                var order = new Order("testUser", CreateSampleEvent(), price, CreateSampleTicket());
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [TestMethod]
        public void OrderedEvent_ShouldThrowIfNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new Order("testUser", null, 50, CreateSampleTicket()));
        }

        [TestMethod]
        public void Ticket_ShouldThrowIfNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new Order("testUser", CreateSampleEvent(), 50, null));
        }

        [TestMethod]
        public void CompareTo_ShouldReturnPositiveIfGreater()
        {
            var order1 = new Order("user", CreateSampleEvent(), 100, CreateSampleTicket());
            var order2 = new Order("user", CreateSampleEvent(), 50, CreateSampleTicket());

            var result = order1.CompareTo(order2);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_ShouldReturnNegativeIfSmaller()
        {
            var order1 = new Order("user", CreateSampleEvent(), 30, CreateSampleTicket());
            var order2 = new Order("user", CreateSampleEvent(), 50, CreateSampleTicket());

            var result = order1.CompareTo(order2);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_ShouldReturnZeroIfEqual()
        {
            var order1 = new Order("user", CreateSampleEvent(), 75, CreateSampleTicket());
            var order2 = new Order("user", CreateSampleEvent(), 75, CreateSampleTicket());

            var result = order1.CompareTo(order2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_ShouldThrowIfObjectIsNotOrder()
        {
            var order = new Order("user", CreateSampleEvent(), 50, CreateSampleTicket());

            Assert.ThrowsException<ArgumentException>(() =>
                order.CompareTo("NotAnOrder"));
        }
    }
}
