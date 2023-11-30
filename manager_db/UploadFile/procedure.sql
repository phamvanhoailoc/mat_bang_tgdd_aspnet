USE web_ecommerce
GO

DELETE FROM file_system;

SELECT * FROM file_system

DROP PROCEDURE InsertFileUpload;
GO

--lấy danh sách sản phẩm theo filter
CREATE PROCEDURE dbo.InsertFileUpload
            @file_type VARCHAR(255),
            @client_filename VARCHAR(255),
            @server_filename VARCHAR(255),
            @file_group VARCHAR(255),
            @file_path VARCHAR(255),
            @file_ext VARCHAR(255),
            @view_type VARCHAR(255),
            @file_size FLOAT,
            @user_create VARCHAR(255),
            @time_create DATE
AS
BEGIN
    INSERT INTO file_system(file_type, client_filename, server_filename, file_group, file_path, file_ext, view_type, file_size, user_create, time_create)
    VALUES (@file_type, @client_filename, @server_filename, @file_group, @file_path, @file_ext, @view_type, @file_size, @user_create, @time_create);
END;
GO

DROP PROCEDURE DeleteFile;
GO

--lấy danh sách sản phẩm theo filter
CREATE PROCEDURE dbo.DeleteFile
            @server_filename VARCHAR(255),
            @success BIT OUTPUT
AS
BEGIN
    SET @success = 0;
    IF EXISTS (SELECT 1 FROM file_system WHERE server_filename = @server_filename)
     BEGIN
        -- Xóa sản phẩm từ bảng Products
        DELETE FROM file_system WHERE server_filename = @server_filename;
        SET @success = 1;
    END
    RETURN @success;
END;
GO

EXEC dbo.DeleteFile 'asdasd'

