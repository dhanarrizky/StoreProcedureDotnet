--FROM CREATEING STOREPROCEDURE
use newdbforlearnsp;

select * from users;

-- get all data
CREATE PROCEDURE GetAllDataUsers
AS
BEGIN
	SELECT * FROM users;
END

exec GetAllDataUsers

-- get user by id
CREATE PROCEDURE GetUserById
	@Id INT
AS
BEGIN
	SELECT * FROM users WHERE id = @Id;
END

exec GetUserById @Id = 2006


-- adding new user
CREATE PROCEDURE AddNewUser
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100),
	@BiirthData DATE,
	@IsActive BIT
AS
BEGIN
	INSERT INTO users(firstname, lastname, birthdate, isActive)
		VALUES
	(@FirstName, @LastName, @BiirthData, @IsActive);
END

exec AddNewUser @FirstName = 'hhhhh' , @LastName = 'test', @BiirthData = '11-8-2001', @IsActive = 0

-- updateing exist user
CREATE PROCEDURE UpdateUserById
	@Id INT,
	@FirstName VARCHAR(100),
	@LastName VARCHAR(100),
	@BiirthData DATE,
	@IsActive BIT
AS
BEGIN
	UPDATE users
		SET 
		firstname = @FirstName, 
		lastname = @LastName, 
		birthdate = @BiirthData,
		isActive = @IsActive
	WHERE id = @Id;
END

exec UpdateUserById @Id = 3003, @FirstName = 'test' , @LastName = 'test', @BiirthData = '11-8-2001', @IsActive = 1


-- deleteing user by id
CREATE PROCEDURE DeleteUserById
	@Id int
AS
BEGIN
	DELETE FROM users  WHERE id = @Id
END

exec DeleteUserById @Id = 3003


-- mengambil 10 data terakhir
SELECT TOP 10 *
	FROM users ORDER BY id DESC