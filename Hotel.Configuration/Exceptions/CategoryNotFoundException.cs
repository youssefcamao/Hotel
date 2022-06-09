namespace Hotel.Configuration.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(string category) : base($"{category} was not found!")
        {

        }
    }
}
