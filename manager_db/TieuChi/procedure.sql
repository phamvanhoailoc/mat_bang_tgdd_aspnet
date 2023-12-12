
DROP PROCEDURE GetTieuchiInfo;
GO

CREATE PROCEDURE GetTieuchiInfo
    @maltc INT
AS
BEGIN
	BEGIN TRY
    SELECT
        ltc.tenltc,
        tc.tentc,
        tc.matc
    FROM
        tieuchi tc
    INNER JOIN
        loaitieuchi ltc ON tc.maltc = ltc.maltc
    WHERE
        tc.maltc = @maltc;
	END TRY
	BEGIN CATCH

       PRINT ERROR_MESSAGE();
    END CATCH
END;

EXEC GetTieuchiInfo @maltc = 123;