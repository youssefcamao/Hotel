using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Core.SearchHelpers
{
    public static class UserSearchHelper
    {
        /// <summary>
        /// This static method takes <see cref="IList<<see cref="IUser"/>>"/> of users and returns a filtered list from the search content
        /// </summary>
        /// <param name="searchContent"></param>
        /// <param name="userList"></param>
        /// <returns> empty <see cref="IList<<see cref="IUser"/>>"/> if no user is found</returns>
        public static IList<IUser> GetUsersFromNameOrEmail(string searchContent, IList<IUser> userList)
        {
            var filterSearchList = new List<IUser>(userList.Where(x =>
            {
                var name = x.FirstName + " " + x.LastName;
                return name.Contains(searchContent, StringComparison.OrdinalIgnoreCase)
                || x.Email.Contains(searchContent, StringComparison.OrdinalIgnoreCase);
            }));
            return filterSearchList;
        }
    }
}
