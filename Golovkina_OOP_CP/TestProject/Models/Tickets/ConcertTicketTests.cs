using EventPass.Models.Tickets;

namespace UnitTests.Models.Tickets
{
    [TestClass]
    public class ConcertTicketTests
    {
        [TestMethod]
        public void Constructor_ValidData_ShouldCreateTicket()
        {
            // Arrange
            int eventId = 1;
            decimal price = 50.0m;
            string singer = "Imagine Dragons";

            // Act
            var ticket = new ConcertTicket(eventId, price, singer);

            // Assert
            Assert.AreEqual(eventId, ticket.EventId);
            Assert.AreEqual(price, ticket.Price);
            Assert.AreEqual(singer, ticket.Singer);
            Assert.IsNull(ticket.UserLogin);
            Assert.IsTrue(ticket.Id > 0);
        }

        [DataTestMethod]
        [DataRow("0")]
        [DataRow("-1")]
        [DataRow("-99,99")]
        public void Constructor_InvalidPrice_ShouldThrow(string strPrice)
        {
            // Act + Assert
            decimal badPrice = decimal.Parse(strPrice);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var ticket = new ConcertTicket(1, badPrice, "Valid Name");
            });
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("1")]
        [DataRow("Jo")]
        [DataRow("!@#")]
        public void Constructor_InvalidSinger_ShouldThrow(string badSinger)
        {
            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var ticket = new ConcertTicket(1, 100, badSinger);
            });
        }

        [TestMethod]
        public void GetPrice_ShouldReturnCorrectValue()
        {
            // Arrange
            decimal price = 75.5m;
            var ticket = new ConcertTicket(1, price, "Eminem");

            // Act
            var result = ticket.GetPrice();

            // Assert
            Assert.AreEqual(price, result);
        }

        [TestMethod]
        public void UserLogin_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var ticket = new ConcertTicket(1, 80, "Coldplay");

            // Act
            ticket.UserLogin = "user123";

            // Assert
            Assert.AreEqual("user123", ticket.UserLogin);
        }
    }
}
