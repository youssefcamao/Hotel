--Begin


--Insert into dbo.UsersTable (Id, FirstName, LastName, Email, Password, IsUserAdmin)
--Values (NEWID(), 'Ramon', 'Grothe', 'ramon@admin.com', HASHBYTES('SHA2_512', 'ramon123'), 1),
--(NEWID(), 'Youssef', 'Sbai', 'youssef@admin.com', HASHBYTES('SHA2_512', 'youssef123'), 1),
--(NEWID(), 'Jannik', 'Krusch', 'jannik@gmail.com', HASHBYTES('SHA2_512', 'jannik123'), 0),
--(NEWID(), 'Paul', 'Maibach', 'paul@gmail.com', HASHBYTES('SHA2_512', 'paul123'), 0);



--Declare @SingleRoomCategoryId uniqueidentifier;
--Declare @DoubleRoomCategoryId uniqueidentifier
--set @SingleRoomCategoryId = NEWID();
--set @DoubleRoomCategoryId = NEWID();


--Insert Into dbo.CategoriesTable (Id, Description, CategoryName, RoomPriceForNight) 
--Values (@SingleRoomCategoryId, 'This Room is only available for 1 Person', 'Single Room', 20),
--(@DoubleRoomCategoryId, 'This Room is available for up to 2 People', 'Double Room', 40);



--Insert Into dbo.RoomsTable (RoomNumber, IsRoomAvailable, CategoryId)
--Values(1, 1, @SingleRoomCategoryId),
--(2, 1, @SingleRoomCategoryId),
--(3, 1, @SingleRoomCategoryId),
--(4, 1, @SingleRoomCategoryId),
--(5, 1, @SingleRoomCategoryId),

--(6, 1, @DoubleRoomCategoryId),
--(7, 1, @DoubleRoomCategoryId),
--(8, 1, @DoubleRoomCategoryId),
--(9, 1, @DoubleRoomCategoryId),
--(10, 1, @DoubleRoomCategoryId);

--End
