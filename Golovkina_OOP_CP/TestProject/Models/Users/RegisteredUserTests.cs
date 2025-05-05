using EventPass.Models.Users;

namespace UnitTests.Models.Users
{
    [TestClass]
    public class RegisteredUserTests
    {
        [DataTestMethod]
        [DataRow("", false)]
        [DataRow("И", false)]
        [DataRow("Ivan", false)]
        [DataRow("Ivan P", false)]
        [DataRow("Ivan Petrov", true)]
        [DataRow("Jo Jo", false)]
        public void FullNameValidation(string fullName, bool expectedIsValid)
        {
            try
            {
                var user = CreateValidUser();
                user.FullName = fullName;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [DataTestMethod]
        [DataRow("123456789", true)]
        [DataRow("12345678", false)]
        [DataRow("abcdefgh", false)]
        public void PhoneNumberValidation(string input, bool expectedIsValid)
        {
            try
            {
                var user = CreateValidUser();
                user.PhoneNumber = input;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [DataTestMethod]
        [DataRow("email@example.com", true)]
        [DataRow("abc", false)]
        [DataRow("", false)]
        [DataRow("test@com", false)]
        public void EmailValidation(string input, bool expectedIsValid)
        {
            try
            {
                var user = CreateValidUser();
                user.Email = input;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [DataTestMethod]
        [DataRow("newLogin", true)]
        [DataRow("", false)]
        public void LoginValidation(string login, bool expectedIsValid)
        {
            try
            {
                RegisteredUser.UnregisterLogin("newLogin");
                var user = CreateValidUser();
                user.Login = login;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [DataTestMethod]
        [DataRow("pass1234", true)]
        [DataRow("1234567", false)]
        [DataRow("password", false)]
        [DataRow("abc123", false)]
        public void PasswordValidation(string input, bool expectedIsValid)
        {
            try
            {
                var user = CreateValidUser();
                user.Password = input;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        [DataTestMethod]
        [DataRow("100", true)]
        [DataRow("0", true)]
        [DataRow("-1", false)]
        public void BalanceValidation(string strvalue, bool expectedIsValid)
        {
            try
            {
                decimal value = decimal.Parse(strvalue);
                var user = CreateValidUser();
                user.Balance = value;
                Assert.IsTrue(expectedIsValid);
            }
            catch (ArgumentException)
            {
                Assert.IsFalse(expectedIsValid);
            }
        }

        private RegisteredUser CreateValidUser()
        {
            return new RegisteredUser(
                fullName: "Ivan Petrov",
                birthDate: new DateOnly(1990, 1, 1),
                phoneNumber: "123456789",
                email: "ivan@example.com",
                login: Guid.NewGuid().ToString(),
                password: "Password1"
            );
        }
    }
}
