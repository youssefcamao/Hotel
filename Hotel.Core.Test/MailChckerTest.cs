using Xunit;

namespace Hotel.Core.Test
{
    public class MailChckerTest
    {
        [Theory]
        [InlineData("youssef@mail.com",true)]
        [InlineData("youssefmail.com", false)]
        public void CheckMailValid_Successful(string email, bool expectedReturn)
        {
            var emailChecker = new EmailCheckService();
            var result = emailChecker.CheckIfEmailValid(email);
            Assert.Equal(expectedReturn, result);
        }
    }
}