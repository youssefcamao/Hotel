namespace Hotel.Configuration.Exceptions
{
    /// <summary>
    /// this Exception is thrown if the category is not found
    /// </summary>
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(string category) : base($"{category} was not found!")
        {

        }
    }
}
