USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[col_H_Calculate]    Script Date: 5/11/2023 7:20:22 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 23/05/2021
-- Description:	Υπολογισμός Εισπραξης
-- =============================================

ALTER PROCEDURE [dbo].[col_H_Calculate]	(@colHid as uniqueidentifier)			--ID Είσπραξης
	
AS
BEGIN
DECLARE @TotalDebit DECIMAL (18,2),@TotalCredit DECIMAL (18,2),@TotalBal DECIMAL (18,2)

select @TotalDebit=SUM(debit),@TotalCredit=SUM(credit),@TotalBal=SUM(bal)
from COL WHERE COL.colHID =@colHid 


update COL_H set TotalDebit=@TotalDebit,TotalCredit=@TotalCredit,TotalBal=@TotalBal
from COL_H
WHERE ID =@colHid 


end
