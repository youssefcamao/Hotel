namespace Hotel.Core
{
    public static class NamingHelper
    {
        /// <summary>
        /// This method fixes the naming of string
        /// </summary>
        /// <remarks> it makes the first letter capital and the rest small</remarks>
        /// <param name="name"></param>
        /// <returns> the fixed name if fixed or the same name if already fixed</returns>
        public static string FixNameFormat(string name)
        {
            if (name.Count() > 1)
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }
            return name;
        }
    }
}
