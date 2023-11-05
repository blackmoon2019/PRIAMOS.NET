USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CalculateunchargableOil]    Script Date: 5/11/2023 7:18:44 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 17/09/2023
-- Description:	Υπολογισμός αχρέωτου Πετρελαίου
-- =============================================
ALTER PROCEDURE [dbo].[CalculateunchargableOil] (@bdgID as uniqueidentifier)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @TotalunchargedLiters decimal(18,2)
	select  @TotalunchargedLiters = sum(INV_OIL.price  * INV_OILP.unchargedLiters  )
	from INV_OIL 
	inner join INV_OILP on INV_OILP.invOilID = INV_OIL.id
	where completed=0 and INV_OIL.bdgID=@bdgID

	
	update BDG	SET unchargableOil = @TotalunchargedLiters 	where ID=@bdgID
END