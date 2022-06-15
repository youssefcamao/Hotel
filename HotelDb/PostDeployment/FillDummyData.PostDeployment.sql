Begin
Declare @SingleRoomCategoryId uniqueidentifier;
Declare @DoubleRoomCategoryId uniqueidentifier;
set @SingleRoomCategoryId = NEWID();
set @DoubleRoomCategoryId = NEWID();
if Not Exists (select 1 from dbo.UsersTable)
Begin
Insert into dbo.UsersTable (Id, FirstName, LastName, Email, UserPassword, IsUserAdmin)
Values (NEWID(), 'Ramon', 'Grothe', 'ramon@admin.com', HASHBYTES('SHA2_512', CAST('ramon123'as nvarchar(50))), 1),
(NEWID(), 'Youssef', 'Sbai', 'youssef@admin.com', HASHBYTES('SHA2_512', CAST('youssef123'as nvarchar(50))), 1),
(NEWID(), 'Jannik', 'Krusch', 'jannik@gmail.com', HASHBYTES('SHA2_512', CAST('jannik123'as nvarchar(50))), 0),
(NEWID(), 'Paul', 'Maibach', 'paul@gmail.com', HASHBYTES('SHA2_512', CAST('paul123'as nvarchar(50))), 0);
End


if not Exists (select 1 from dbo.CategoriesTable)
begin
Insert Into dbo.CategoriesTable (Id, Description, CategoryName, RoomPriceForNight) 
Values (@SingleRoomCategoryId, 'This Room is only available for 1 Person', 'Single Room', 20),
(@DoubleRoomCategoryId, 'This Room is available for up to 2 People', 'Double Room', 40);
end
else
begin 
if not Exists (select * from dbo.CategoriesTable where Id = @SingleRoomCategoryId or Id = @DoubleRoomCategoryId)
begin 
Delete From dbo.ReservationsTable;
Delete From dbo.RoomsTable;
Delete From dbo.CategoriesTable;
Insert Into dbo.CategoriesTable (Id, Description, CategoryName, RoomPriceForNight) 
Values (@SingleRoomCategoryId, 'This Room is only available for 1 Person', 'Single Room', 20),
(@DoubleRoomCategoryId, 'This Room is available for up to 2 People', 'Double Room', 40);
end
end

if not Exists (select 1 from dbo.RoomsTable)
begin
Insert Into dbo.RoomsTable (RoomNumber, IsRoomAvailable, CategoryId)
Values(1, 1, @SingleRoomCategoryId),
(2, 1, @SingleRoomCategoryId),
(3, 1, @SingleRoomCategoryId),
(4, 1, @SingleRoomCategoryId),
(5, 1, @SingleRoomCategoryId),

(6, 1, @DoubleRoomCategoryId),
(7, 1, @DoubleRoomCategoryId),
(8, 1, @DoubleRoomCategoryId),
(9, 1, @DoubleRoomCategoryId),
(10, 1, @DoubleRoomCategoryId);
end
End
