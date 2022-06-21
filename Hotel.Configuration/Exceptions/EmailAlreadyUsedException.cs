namespace Hotel.Configuration.Exceptions
{
    /// <summary>
    /// this Exception is thrown if the email already exists in the database
    /// </summary>
    public class EmailAlreadyUsedException : Exception
    {
        public EmailAlreadyUsedException(string email) : base($"The Given Email is Taken!") { }
    }
}
