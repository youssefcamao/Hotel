namespace Hotel.Configuration.Exceptions
{
    /// <summary>
    /// this Exception is thrown if no available room is found
    /// </summary>
    public class NoRoomFoundException : Exception
    {
        public NoRoomFoundException() : base("No room was found under the given details!")
        {

        }
    }
}
