using Xunit;

namespace Hotel.Core.Test
{
    public class MailCheckerTest
    {
        [Theory]
        [InlineData("youssef@mail.com", true)]
        [InlineData("youssefmail.com", false)]
        public void CheckMailValid_Successful(string email, bool expectedReturn)
        {
            var emailChecker = new EmailCheckService();
            var result = emailChecker.CheckIfValid(email);
            Assert.Equal(expectedReturn, result);
        }
    }
}