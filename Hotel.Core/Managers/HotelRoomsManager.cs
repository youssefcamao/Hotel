using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;

namespace Hotel.Core.Managers
{
    public class HotelRoomsManager
    {
        private readonly IRepository<IRoom> _roomRepository;
        private readonly IRepository<IRoomCategory> _categoryRepository;

        /// <summary>
        /// gets all the room categories from the database
        /// </summary>
        public IList<IRoomCategory> RoomCategories => _categoryRepository.GetAll();
        /// <summary>
        /// gets all the rooms from the database
        /// </summary>
        public IList<IRoom> HotelRoomsList => _roomRepository.GetAll();

        public HotelRoomsManager(IRepository<IRoom> roomRepository, IRepository<IRoomCategory> categoryRepository)
        {
            _roomRepository = roomRepository;
            _categoryRepository = categoryRepository;
        }
        /// <summary>
        /// This Method returns a category from its id and returns Null if Category Not Found
        /// </summary>
        /// <param name="roomCategoryId"></param>
        /// <returns> IRoomCategory or Null If not found</returns>
        public IRoomCategory? GetCategoryFromId(Guid roomCategoryId)
        {
            return RoomCategories.FirstOrDefault(x => x.Id == roomCategoryId);
        }
        /// <summary>
        /// This Method return category by its name
        /// <para><remarks>if no categery is found <see cref="ArgumentException"/> is thrown.</remarks></para>
        /// <para><remarks>if more than one category is found <see cref="InvalidOperationException"/> is thrown.</remarks></para>
        /// </summary>
        /// <returns> the room category if found and null if not</returns>
        /// <param name="categoryName"></param>
        public IRoomCategory? GetCategoryFromCategoryName(string categoryName)
        {
            var selectedCategories = RoomCategories.Where(x => x.CategoryName == categoryName);
            if (selectedCategories.Count() == 0)
            {
                throw new ArgumentNullException("No Category was found!");
            }
            else if (selectedCategories.Count() != 1)
            {
                throw new InvalidOperationException("There is more than one category with the same name");
            }
            else
            {
                return selectedCategories.First();
            }
        }

        /// <summary>
        /// This Method returns a room from its roomNumber and returns Null if Category Not Found
        /// </summary>
        /// <param name="roomCategoryId"></param>
        /// <returns> <see cref="IRoom"/> or null If not found</returns>
        public IRoom? GetRoomFromNumber(int roomNumber)
        {
            return HotelRoomsList.FirstOrDefault(x => x.RoomNumber == roomNumber);
        }
        /// <summary>
        /// This Method returns category from its Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns> <see cref="IRoomCategory"/> if found and null if not</returns>
        public IRoomCategory? GetRoomCategoryFromId(Guid categoryId)
        {
            return RoomCategories.FirstOrDefault(x => x.Id == categoryId);
        }
    }
}
