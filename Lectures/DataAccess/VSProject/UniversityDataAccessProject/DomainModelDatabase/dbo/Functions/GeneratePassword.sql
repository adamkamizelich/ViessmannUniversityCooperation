
CREATE FUNCTION dbo.GeneratePassword(@letters INT = NULL, @numbers INT = NULL, @symbols INT = NULL)
RETURNS VARCHAR(256)
AS
BEGIN
    -- actual defaults
    IF @letters IS NULL SET @letters = 6
    IF @numbers IS NULL SET @numbers = 3
    IF @symbols IS NULL SET @symbols = 1

    IF @letters < 0 SET @letters = 0
    IF @numbers < 0 SET @numbers = 0
    IF @symbols < 0 SET @symbols = 0

    IF @letters > 256 SET @letters = 256
    IF @numbers > 256 SET @numbers = 256
    IF @symbols > 256 SET @symbols = 256

    DECLARE @letterSet VARCHAR(52) = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ',
            @numberSet VARCHAR(10) = '0123456789',
            @symbolSet VARCHAR(20) = '!@#$%^&*()_+-=[]{}',
            @pwdLen INT = @letters + @numbers + @symbols

    IF @pwdLen > 256 SET @pwdLen = 256

    -- 256 is max possible password length
    DECLARE @pwd VARCHAR(256) = ''

    -- 2048 = (4 bytes rnd set + 4 bytes rnd position in set) * 256 max password length
    DECLARE @noise VARBINARY(2048) = (SELECT n.Bytes FROM dbo.RandomNoise n)

    DECLARE @i INT = 0

    WHILE @i < @pwdLen
    BEGIN
        SET @i = @i + 1

        -- [0,1)
        DECLARE @who FLOAT = (CAST(CAST(SUBSTRING(@noise, @i    , 4) AS INT) AS FLOAT) + 2147483648.0) / 4294967296.0,
                @pos FLOAT = (CAST(CAST(SUBSTRING(@noise, @i + 4, 4) AS INT) AS FLOAT) + 2147483648.0) / 4294967296.0

        IF @who < (@letters / CAST(@letters + @numbers + @symbols AS FLOAT))
        BEGIN
            SET @pwd = @pwd + SUBSTRING(@letterSet, CAST(@pos * LEN(@letterSet) + 1 AS INT), 1)
            SET @letters = @letters - 1
        END
        ELSE
        IF @who < ((@letters + @numbers) / CAST(@letters + @numbers + @symbols AS FLOAT))
        BEGIN
            SET @pwd = @pwd + SUBSTRING(@numberSet, CAST(@pos * LEN(@numberSet) + 1 AS INT), 1)
            SET @numbers = @numbers - 1
        END
        ELSE
        BEGIN
            SET @pwd = @pwd + SUBSTRING(@symbolSet, CAST(@pos * LEN(@symbolSet) + 1 AS INT), 1)
            SET @symbols = @symbols - 1
        END
    END

    RETURN @pwd
	END