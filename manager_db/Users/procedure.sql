USE web_ecommerce
GO

DROP PROCEDURE RegisterUser;
GO

--tạo user mới
CREATE PROCEDURE dbo.RegisterUser
    @user_name NVARCHAR(100),
    @hash_password NVARCHAR(200),
    @created_at DATE
AS
BEGIN
    INSERT INTO users(user_name, hash_password, created_at)
    VALUES (@user_name, HASHBYTES('SHA2_256',@hash_password), @created_at);
    SELECT * FROM users WHERE user_id = @@IDENTITY;
END;
GO

EXEC dbo.RegisterUser N'asdasdassd','123456','2023-10-27';
GO

--kiểm tra xem user_name đã tồn tại trong table hay không

-- DROP PROCEDURE CheckUserNameExists;
-- GO
CREATE PROCEDURE CheckUserNameExists
    @user_name NVARCHAR(100)
AS
BEGIN
    SELECT * FROM users WHERE [user_name] = @user_name;
END;
GO

EXEC dbo.CheckUserNameExists N'asdasdassd';
GO

--kiểm tra login

-- DROP PROCEDURE CheckLogin;
-- GO
CREATE PROCEDURE CheckLogin
    @user_name NVARCHAR(100),
    @hash_password NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @hashPassword VARBINARY(32)
    SET @hashPassword = HASHBYTES('SHA2_256', @hash_password);
    BEGIN
       SELECT * FROM users WHERE [user_name] IN
       (SELECT [user_name] FROM users WHERE [user_name] = @user_name AND hash_password = @hashPassword)
    END
END;
GO

EXEC dbo.CheckLogin N'user1','123456';