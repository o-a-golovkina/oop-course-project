using EventPass.Models.Tickets;

namespace UnitTests.Models.Tickets
{
    [TestClass]
    public class StandUpTicketTests
    {
        [TestMethod]
        public void Constructor_ValidData_ShouldCreateTicket()
        {
            // Arrange
            int eventId = 2;
            decimal price = 35.0m;
            bool drinksIncluded = true;

            // Act
            var ticket = new StandUpTicket(eventId, price, drinksIncluded);

            // Assert
            Assert.AreEqual(eventId, ticket.EventId);
            Assert.AreEqual(price, ticket.Price);
            Assert.AreEqual(drinksIncluded, ticket.IsDrinkIncluded);
            Assert.IsTrue(ticket.Id > 0);
            Assert.IsNull(ticket.UserLogin);
        }

        [TestMethod]
        public void Constructor_InvalidPrice_ShouldThrow()
        {
            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var ticket = new StandUpTicket(1, -50, true); // ❌ ціна <= 0
            });
        }


        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void IsDrinkIncluded_ShouldStoreValueCorrectly(bool expected)
        {
            // Arrange
            var ticket = new StandUpTicket(4, 20, expected);

            // Act & Assert
            Assert.AreEqual(expected, ticket.IsDrinkIncluded);
        }

        [TestMethod]
        public void GetPrice_ShouldReturnCorrectPrice()
        {
            // Arrange
            decimal price = 55.0m;
            var ticket = new StandUpTicket(5, price, false);

            // Act
            var result = ticket.GetPrice();

            // Assert
            Assert.AreEqual(price, result);
        }

        [TestMethod]
        public void UserLogin_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var ticket = new StandUpTicket(6, 40, true);

            // Act
            ticket.UserLogin = "comedyFan123";

            // Assert
            Assert.AreEqual("comedyFan123", ticket.UserLogin);
        }
    }
}
