USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CreateInvNumbers]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 27/07/2022
-- Description:	Αρίθμηση Αποδείξεων ανα παραστατικό
-- =============================================
CREATE PROCEDURE [dbo].[CreateInvNumbers]	(@inhid as uniqueidentifier)				--ID Παραστατικού
										
	
AS
BEGIN

insert into INVNUMBERS 
SELECT DISTINCT INHid,APTid FROM INC WHERE INC.inhID=@inhid 
AND NOT EXISTS (SELECT 1 FROM INVNUMBERS I WHERE I.inhID=INC.inhID AND I.aptID=INC.aptID )



end

GO
