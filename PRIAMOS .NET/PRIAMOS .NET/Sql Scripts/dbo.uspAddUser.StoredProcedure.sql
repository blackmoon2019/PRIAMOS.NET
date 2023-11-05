USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[uspAddUser]    Script Date: 5/11/2023 7:25:01 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspAddUser]
    @pLogin NVARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pRealName NVARCHAR(200) = NULL, 
	@pDateLogin datetime = NULL, 
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO dbo.[USR] (un, pwd, realname, dtLogin )
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword), @pRealName , @pDateLogin )

        SET @responseMessage='Success'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END