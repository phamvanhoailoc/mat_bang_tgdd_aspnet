
DROP PROCEDURE CountRecordSieuThi;
GO

--đếm số lượng sieu thi
CREATE PROCEDURE dbo.CountRecordSieuThi
            @keyword NVARCHAR(255),
			@tinhst NVARCHAR(255),
            @huyenst NVARCHAR(255),
            @xast NVARCHAR(255),
         	@fromDate NVARCHAR(255),
            @toDate NVARCHAR(255)
AS
BEGIN
    DECLARE @totalSieuThi INT;
    DECLARE @query NVARCHAR(MAX);
    SET @query  = 'SELECT COUNT(*) FROM sieuthi WHERE 1=1 ';

    IF @keyword IS NOT NULL AND @keyword != '' 
    BEGIN
        SET @query = @query + 'AND tenst LIKE ''%'  + @keyword + '%''';
    END 

    IF @tinhst IS NOT NULL AND @tinhst != '' 
    BEGIN
        SET @query = @query + 'AND tinhst = '''+ @tinhst +'''' ;
    END 
    
    IF @huyenst IS NOT NULL AND @huyenst != '' 
    BEGIN
        SET @query = @query + 'AND huyenst = '''+ @huyenst + '''' ;
    END
    
    IF @xast IS NOT NULL AND @xast != '' 
    BEGIN
        SET @query = @query + 'AND xast = '''+ @xast + '''' ;
    END
    
    IF @fromDate IS NOT NULL AND @fromDate != '' AND @toDate IS NOT NULL AND @toDate !=''
    BEGIN
        SET @query = @query + 'AND NgayCN >= CONVERT(DATE, '''+ @fromDate +''') AND NgayCN <= CONVERT(DATE, '''+ @toDate + ''')' ;
    END
    
     IF @fromDate IS NOT NULL AND @fromDate != '' AND (@toDate IS NULL OR @toDate ='')
    BEGIN
        SET @query = @query + 'AND NgayCN >= CONVERT(DATE, '''+ @fromDate + ''') ';
    END
    
     IF @toDate IS NOT NULL AND @toDate != '' AND (@fromDate IS NULL OR @fromDate ='')
    BEGIN
        SET @query = @query + 'AND NgayCN <=CONVERT(DATE, '''+ @toDate + ''')' ;
    END
   
    -- Thực hiện câu truy vấn và lưu kết quả vào biến @totalSieuThi
    EXEC sp_executesql @query, N'@totalSieuThi INT OUTPUT', @totalSieuThi OUTPUT;

    -- Trả về kết quả
    RETURN @totalSieuThi;
END;
GO

EXEC dbo.CountRecordSieuThi N'','T?nh A','Huy?n B','Xã C','2023-01-01','2023-01-02';
GO

CREATE PROCEDURE dbo.FilterSieuThi
            @keyword NVARCHAR(255),
			@page INT,
            @limit INT,
			@fromDate NVARCHAR(255),
            @toDate NVARCHAR(255),
			@tinhst NVARCHAR(255),
            @huyenst NVARCHAR(255),
            @xast NVARCHAR(255)
      
AS
BEGIN
    DECLARE @query NVARCHAR(MAX);
    SET @query  = 'SELECT mast, tenst, dcst, NguoiCN  FROM sieuthi WHERE 1=1 ';

    IF @keyword IS NOT NULL AND @keyword != '' 
    BEGIN
        SET @query = @query + 'AND tenst LIKE ''%'  + @keyword + '%''';
    END 

    IF @tinhst IS NOT NULL AND @tinhst != '' 
    BEGIN
        SET @query = @query + 'AND tinhst = '''+ @tinhst +'''' ;
    END 
    
    IF @huyenst IS NOT NULL AND @huyenst != '' 
    BEGIN
        SET @query = @query + 'AND huyenst = '''+ @huyenst + '''' ;
    END
    
    IF @xast IS NOT NULL AND @xast != '' 
    BEGIN
        SET @query = @query + 'AND xast = '''+ @xast + '''' ;
    END
    
    IF @fromDate IS NOT NULL AND @fromDate != '' AND @toDate IS NOT NULL AND @toDate !=''
    BEGIN
        SET @query = @query + 'AND NgayCN >= CONVERT(DATE, '''+ @fromDate +''') AND NgayCN <= CONVERT(DATE, '''+ @toDate + ''')' ;
    END
    
     IF @fromDate IS NOT NULL AND @fromDate != '' AND (@toDate IS NULL OR @toDate ='')
    BEGIN
        SET @query = @query + 'AND NgayCN >= CONVERT(DATE, '''+ @fromDate + ''') ';
    END
    
     IF @toDate IS NOT NULL AND @toDate != '' AND (@fromDate IS NULL OR @fromDate ='')
    BEGIN
        SET @query = @query + 'AND NgayCN <=CONVERT(DATE, '''+ @toDate + ''')' ;
    END 

    SET @query = @query + 'ORDER BY mast OFFSET ' + CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT ' + CAST(@limit AS NVARCHAR(10)) + ' ROWS ONLY;';
    -- Thực hiện câu truy vấn và trả về kết quả
    EXEC sp_executesql @query;
END;
GO

EXEC dbo.FilterSieuThi N'',0,5,'','','','','';
GO


DROP PROCEDURE GetSieuThisById;
GO

CREATE PROCEDURE GetSieuThisById
    @Id INT
AS
BEGIN
	IF @Id IS NOT NULL AND @Id >= 0
	BEGIN
    DECLARE @Query NVARCHAR(MAX);
    SET @Query = '
        SELECT TOP 1 mast, tenst, dcst, dmhh, sbntST, SbnlST, NguoiCN
        FROM sieuthi
        WHERE mast = @Id';
		-- Execute the dynamic SQL query
    EXEC sp_executesql @Query, N'@Id INT', @Id;
	END  
	ELSE
    BEGIN
        -- If @Id is NULL or less than 0, return an empty result set
        SELECT NULL AS mast, NULL AS tenst, NULL AS dcst, NULL AS dmhh, NULL AS sbntST, NULL AS SbnlST, NULL AS NguoiCN;
    END
END;
GO


EXEC dbo.GetSieuThisById 1;
GO


DROP PROCEDURE UpdateSieuThiById;
GO


CREATE PROCEDURE UpdateSieuThiById
    @Id INT,
    @NewSbntST DECIMAL,
    @NewSbnlST DECIMAL,
	@NewNguoiCN INT,
    @Success BIT OUTPUT
AS
BEGIN
    SET @Success = 0; -- Mặc định là thất bại

    IF @Id IS NOT NULL AND @Id >= 0
    BEGIN
        BEGIN TRY
            UPDATE sieuthi
            SET sbntST = @NewSbntST,
                SbnlST = @NewSbnlST,
				NguoiCN = @NewNguoiCN
            WHERE mast = @Id;

            SET @Success = 1; -- Đánh dấu là thành công
        END TRY
        BEGIN CATCH
            -- Xử lý lỗi nếu có
        END CATCH
    END
END;
GO


EXEC UpdateSieuThiById @Id = 1, @NewSbntST = 500, @NewSbnlST = 700;
