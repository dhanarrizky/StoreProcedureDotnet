use newdbforlearnsp;

SELECT 
	SPECIFIC_NAME
FROM
	INFORMATION_SCHEMA.ROUTINES
WHERE
	ROUTINE_TYPE = 'PROCEDURE';


-- create procedure get all with pagination
-- how much per page 
-- current location page

CREATE PROCEDURE GetAllDataUsersWithPagination
	@CurrentPage INT,
	@DataPerPage INT,
	@TotalData INT OUTPUT,
	@TotalPage INT OUTPUT
AS
BEGIN
	SELECT *
	FROM users
	ORDER BY id
	OFFSET (@CurrentPage - 1) * @DataPerPage ROWS
	FETCH NEXT @DataPerPage ROWS ONLY;

	SELECT @TotalData = COUNT(*) FROM users;
	SET @TotalPage = CEILING((CAST(@TotalData AS FLOAT) / @DataPerPage));
END


DECLARE @TotalData INT, @TotalPage INT;

-- Eksekusi prosedur tersimpan
EXEC GetAllDataUsersWithPagination 
    @CurrentPage = 1,  -- Menggunakan halaman 1 sebagai contoh
    @DataPerPage = 10,
    @TotalData = @TotalData OUTPUT,
    @TotalPage = @TotalPage OUTPUT;

-- Menampilkan hasil output
SELECT @TotalData AS TotalData, @TotalPage AS TotalPage;
