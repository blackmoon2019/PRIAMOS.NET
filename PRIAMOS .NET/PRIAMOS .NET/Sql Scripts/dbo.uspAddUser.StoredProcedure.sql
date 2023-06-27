USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[uspAddUser]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddUser]
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
GO
