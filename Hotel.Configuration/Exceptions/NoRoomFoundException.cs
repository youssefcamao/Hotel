namespace Hotel.Configuration.Exceptions
{
    public class NoRoomFoundException : Exception
    {
        public NoRoomFoundException() : base("No room was found under the given details!")
        {

        }
    }
}
