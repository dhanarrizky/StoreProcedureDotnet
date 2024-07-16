use newdbforlearnsp;

USE newdbforlearnsp;

-- Create a stored procedure to drop another procedure
CREATE PROCEDURE dbo.dropProcedure
    @name VARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'DROP PROCEDURE ' + QUOTENAME(@name);
    EXEC sp_executesql @sql;
END


DECLARE @procName VARCHAR(100);

DECLARE proc_cursor CURSOR FOR
SELECT routine_name
FROM information_schema.routines
WHERE routine_type = 'PROCEDURE';

OPEN proc_cursor;

FETCH NEXT FROM proc_cursor INTO @procName;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Execute the dropProcedure stored procedure for each procedure name
    EXEC dbo.dropProcedure @name = @procName;

    FETCH NEXT FROM proc_cursor INTO @procName;
END

CLOSE proc_cursor;
DEALLOCATE proc_cursor;

select routine_name from information_schema.routines where routine_type = 'procedure'