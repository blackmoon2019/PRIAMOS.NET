USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_Calculate]    Script Date: 30/11/2022 5:14:19 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 23/05/2021
-- Description:	Υπολογισμός Κοινοχρήστων
-- =============================================
ALTER PROCEDURE [dbo].[inv_Calculate]	(
	@inhid as uniqueidentifier,				--ID Παραστατικού
	@bdgid as uniqueidentifier,				--ID Πολυκατοικίας
	@ahpbHID as uniqueidentifier,			--ID Header μετρήσεων ωρών
	@ahpbHIDB as uniqueidentifier			--ID Header μετρήσεων ωρών Boiler
										)			
	
AS
BEGIN

--print @inhid
--print @BDGID
--print @ahpbHID
--print @ahpbHIDB
-- *****************THIS FOR EXAMPLE IF I WANT TO TEST PROCEDURE***************************
/*
DECLARE 	
	@inhid as uniqueidentifier,				--ID Παραστατικού
	@bdgid as uniqueidentifier,				--ID Πολυκατοικίας
	@ahpbHID as uniqueidentifier,			--ID Header μετρήσεων ωρών
	@ahpbHIDB as uniqueidentifier			--ID Header μετρήσεων ωρών Boiler

	set @inhid	  = '814ca51d-e2b4-4026-8b72-3f774c0486dd'
	set @bdgid	  = '0875644E-79F6-4F9C-BB2F-74470E54C036'
	set @ahpbHID  = 'A489D8F3-A44E-4C94-936E-D9ACDF192A12'
	set @ahpbHIDB = '00000000-0000-0000-0000-000000000000'

*/
--**********ΑΝΤΙΣΤΟΙΧΙΣΗ ΠΙΝΑΚΑ [CALC_CAT] ΜΕ ΣΤΗΛΕΣ ΑΠΟ ΤΟΝ ΠΙΝΑΚΑ [INC]*****************
--ΜΟΝΟΜΕΡΗ 1		3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE	monomers1
--ΜΟΝΟΜΕΡΗ 3		2AE90BA0-DD3D-424D-9F6E-DA7A9A518620	monomers3		
--ΜΟΝΟΜΕΡΗ 2		EBD46C24-FBB0-47AD-A325-143C953A4AB4	monomers2	
--ΘΕΡΜΑΝΣΕΩΣ		8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D	heating	
--ΑΝΕΛΚΥΣΤΗΡΑ		7FA0D7BA-2713-405C-8748-61DD8537A9CC	elevator
--ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ	B139CE26-1ABA-4680-A1EE-623EC97C475B	heating_consumption		
--ΚΑΤ/ΣΗ BOILER		2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72	boiler_consumption
--ΕΚΔΟΣΗ			9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB	billing
--ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ	BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3	special_costs
--ΘΕΣΕΙΣ ΓΚΑΡΑΖ		8D417A79-9757-4B18-8695-AE1BDF9416DD	garage
--ΚΟΙΝΟΧΡΗΣΤΩΝ		C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9	shared
--ΙΔΙΟΚΤΗΤΩΝ		E371555E-BB81-425B-9702-FB1EDE8DE73D	owners
--*****************************************************************************************
	SET NOCOUNT ON;
declare @ind_ID uniqueidentifier		-- Μεταβλητή που αποθηκευει το ID της γραμμής του εξόδου παραστατικού
declare @ApmilTotal decimal(9,3)		-- Μεταβλητή που αποθηκευει το σύνολο των χιλιοστών με μειώσεις για μια συγκεκριμένη κατηγορία χιλιοστών
declare @calcCatID uniqueidentifier		-- Μεταβλητή που αποθηκευει το ID του τύπου υπολογισμού 
declare @CalcType uniqueidentifier		-- Μεταβλητή που αποθηκευει το ID του τύπου θέρμανσης
declare @CalcTypeB uniqueidentifier		-- Μεταβλητή που αποθηκευει το ID του τύπου Boiler
declare @Hpc int						-- Πάγιο Θέρμανσης
declare @Hpb int						-- Πάγιο Boiler
declare @amt decimal(8,2)				-- Ποσό που αφορά μόνο την κατανάλωση θέρμανσης σε περίπτωση που η ποληκατοικία έχει αυτονομία με σταθερό πάγιο
declare @TotMil 	decimal(15,3)		-- Σύνολο χιλιοστών( αφορά τον υπολογισμό κατανάλωσης θέρμανσης)
declare @TotNewMil	decimal(15,3)		-- Σύνολο νέων χιλιοστών( αφορά τον υπολογισμό κατανάλωσης θέρμανσης)
declare @Totmilhour decimal(15,6)		-- Σύνολο χιλιοστών θέρμανσης * ώρες
declare @ToteiΩ decimal(15,6)			-- Σύνολο χιλιοστών θέρμανσης * ώρες
declare @Totfimil   decimal(15,6)		-- Σύνολο χιλιοστών θέρμανσης * ώρες
declare @isManaged bit					-- Flag αν η πολυκατοικία είναι διαχείριση
declare @ColHID uniqueidentifier		-- Μεταβλητή που αποθηκευει το ID του Header Είσπραξης
declare @debitusrID uniqueidentifier	-- Μεταβλητή που αποθηκεύει τον χρήστη που έχει	

BEGIN TRY
    BEGIN TRANSACTION

	--Διαγραφή  από πίνακα υπολογισμού όλα τα διαμερίσματα της πολυκατοικίας για το συγκεκριμένο παραστατικό
	delete from INC where inhID=@inhid
	--Πριν διαγράψω τις εισπράξεις όλες αποθηκεύω πρώτα τις επιβεβαιωμένες για να τις ξαναχρεώσω συστημικά
	INSERT INTO COL_D_TEMP
	SELECT	D.[ID], D.[code], D.[colID], D.[bdgID], D.[aptID], D.[inhID], 
			D.[debitusrID], D.[Credit], D.[debit], D.[Bal], D.[agreed], D.[modifiedBy], D.[modifiedOn], D.[createdOn],
			D.[tenant], COL.ColMethodID ,NULL,NULL
	FROM COL
	INNER JOIN COL_D D ON D.colID = COL.ID
	WHERE agreed=1 AND COL.inhID=@inhid

	--Διαγραφή  από πίνακα  Ιστορικότητας των υπολοίπων
	delete from APT_BAL_HIST where inhID=@inhid
	--Διαγραφή  από πίνακα  Εισπράξεων για το συγκεκριμένο παραστατικό μόνο αυτά που δεν είναι επιβεβαιωμένα
	delete from COL where inhID=@inhid
	--Διαγραφή  από πίνακα  Εισπράξεων για το συγκεκριμένο παραστατικό. Αφορά τα προοδευτικά χρέωσης
	delete from COL_P where inhID=@inhid
	--Διαγραφή  από πίνακα  Εισπράξεων για το συγκεκριμένο παραστατικό
	delete from COL_H where inhID=@inhid
	--Διαγραφή  από πίνακα  Των Εισπράξεων για το συγκεκριμένο παραστατικό που δεν είναι διαχειρίση
	delete from COL_EXT where inhID=@inhid

	--Παίρνω τον τύπο Θέρμανσης Και το ποσοστό Παγίου και αν είναι διαχείριση
	select @isManaged=isManaged, @Hpc =isnull(hpc,0)  ,@Hpb =isnull(hpb,0),   @CalcType = HTypeID, @CalcTypeB = BTypeID   from bdg  where id=upper(@bdgid)
 
	--Η δημιουργία αυτού του πίνακα βοηθάει για να συγκεντρωθούν όλες οι πληροφορίες που αφορούν το διαμέρισμα όσο αφορά όσά και χιλιοστά		
 		create table #INVOICE
	(
		IncID uniqueidentifier,						-- ID πίνακα υπολογισμού
		inhID uniqueidentifier,						-- ID Παραστατικού
		indid uniqueidentifier,						-- ID εξόδου
		bdgID uniqueidentifier,						-- ID Πολυκατοικίας
		aptID uniqueidentifier,						-- ID Διαμερίσματος
		aptid_out uniqueidentifier,					-- ID Διαμερίσματος εκτός
		aptid_closed uniqueidentifier,				-- ID Διαμερίσματος Κλειστού
		CalcCatID uniqueidentifier,				    -- ID Τύπου Υπολογισμού
		ttl nvarchar(150),							-- Τίτλος Διαμερίσματος					
		AptNam nvarchar(150),						-- Όνομα Διαμερίσματος
		AptOrd int,									-- Ταξινόμηση  Διαμερίσματος
		repName nvarchar(250),						-- Λεκτικό Εκτύπωσης
		INDAmt decimal(9,2),						-- Συνολικό ποσό εξόδου διαμερίσματος
		elevator decimal(9,2),						-- Ποσό Ανελκυστήρα
		shared decimal(9,2),						-- Ποσό Κοινοχρήστων
		heating decimal(9,2),						-- Ποσό Θέρμανση
		boiler decimal(9,2),						-- Ποσό Boiler
		heating_consumption decimal(9,2),			-- Ποσό Κατανάλωσης Θέρμανσης
		boiler_consumption decimal(9,2),			-- Ποσό Κατανάλωσης Boiler
		special_costs decimal(9,2),					-- Ποσό Ειδικών Δαπανών
		owners decimal(9,2),						-- Ποσό Ιδιοκτητών
		billing decimal(9,2),						-- Ποσό Έκδοσης
		garage decimal(9,2),						-- Ποσό Γκαράζ
		monomers1 decimal(9,2),						-- Ποσό Μονομερή1
		monomers2 decimal(9,2),						-- Ποσό Μονομερή2
		monomers3 decimal(9,2),						-- Ποσό Μονομερή3
		elevator_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Ανελκυστήρα
		shared_epivar decimal(9,2),					-- Ποσό Επιβάρυνσης Κοινοχρήστων
		heating_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Θέρμανση
		boiler_epivar decimal(9,2),					-- Ποσό Επιβάρυνσης Boiler
		heating_consumption_epivar decimal(9,2),	-- Ποσό Επιβάρυνσης Κατανάλωσης Θέρμανσης
		boiler_consumption_epivar decimal(9,2),		-- Ποσό Επιβάρυνσης Κατανάλωσης Boiler
		special_costs_epivar decimal(9,2),			-- Ποσό Επιβάρυνσης Ειδικών Δαπανών
		owners_epivar decimal(9,2),					-- Ποσό Επιβάρυνσης Ιδιοκτητών
		billing_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Έκδοσης
		garage_epivar decimal(9,2),					-- Ποσό Επιβάρυνσης Γκαράζ
		monomers1_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Μονομερή1
		monomers2_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Μονομερή2
		monomers3_epivar decimal(9,2),				-- Ποσό Επιβάρυνσης Μονομερή3
		tot_elevator decimal(9,2),					-- Τελικό Ποσό Πληρωμής Ανελκυστήρα
		tot_shared decimal(9,2),					-- Τελικό Ποσό Πληρωμής Κοινοχρήστων
		tot_heating decimal(9,2),					-- Τελικό Ποσό Πληρωμής Θέρμανση
		tot_boiler decimal(9,2),					-- Τελικό Ποσό Πληρωμής Boiler
		tot_heating_consumption decimal(9,2),		-- Τελικό Ποσό Πληρωμής Κατανάλωσης Θέρμανσης
		tot_boiler_consumption decimal(9,2),		-- Τελικό Ποσό Πληρωμής Κατανάλωσης Boiler
		tot_special_costs decimal(9,2),				-- Τελικό Ποσό Πληρωμής Ειδικών Δαπανών
		tot_owners decimal(9,2),					-- Τελικό Ποσό Πληρωμής Ιδιοκτητών
		tot_billing decimal(9,2),					-- Τελικό Ποσό Πληρωμής Έκδοσης
		tot_garage decimal(9,2),					-- Τελικό Ποσό Πληρωμής Γκαράζ
		tot_monomers1 decimal(9,2),					-- Τελικό Ποσό Πληρωμής Μονομερή1
		tot_monomers2 decimal(9,2),					-- Τελικό Ποσό Πληρωμής Μονομερή2
		tot_monomers3 decimal(9,2),					-- Τελικό Ποσό Πληρωμής Μονομερή3
		mil_elevator decimal(10,6),					-- Κανονικά Χιλιοστά Ανελκυστήρα
		mil_shared decimal(10,6),					-- Κανονικά Χιλιοστά Κοινοχρήστων
		mil_heating decimal(10,6),					-- Κανονικά Χιλιοστά Θέρμανση
		mil_boiler decimal(10,6),					-- Κανονικά Χιλιοστά Boiler
		mil_heating_consumption decimal(10,6),		-- Κανονικά Χιλιοστά Κατανάλωσης Θέρμανσης
		mil_boiler_consumption decimal(10,6),		-- Κανονικά Χιλιοστά Κατανάλωσης Boiler
		mil_heating_boiler decimal(10,6),			-- Κανονικά Χιλιοστά Κατανάλωσης Boiler
		mil_special_costs decimal(10,6),			-- Κανονικά Χιλιοστά Ειδικών Δαπανών
		mil_owners decimal(10,6),					-- Κανονικά Χιλιοστά Ιδιοκτητών
		mil_billing decimal(10,6),					-- Κανονικά Χιλιοστά Έκδοσης
		mil_garage decimal(10,6),					-- Κανονικά Χιλιοστά Γκαράζ
		mil_monomers1 decimal(10,6),				-- Κανονικά Χιλιοστά Μονομερή1
		mil_monomers2 decimal(10,6),				-- Κανονικά Χιλιοστά Μονομερή2
		mil_monomers3 decimal(10,6),				-- Κανονικά Χιλιοστά Μονομερή3
		c_mil_elevator decimal(10,6),				-- Χιλιοστά Κλειστού Ανελκυστήρα
		c_mil_shared decimal(10,6),					-- Χιλιοστά Κλειστού Κοινοχρήστων
		c_mil_heating decimal(10,6),				-- Χιλιοστά Κλειστού Θέρμανση
		c_mil_boiler decimal(10,6),					-- Χιλιοστά Κλειστού Boiler
		c_mil_heating_consumption decimal(10,6),	-- Χιλιοστά Κλειστού Κατανάλωσης Θέρμανσης
		c_mil_boiler_consumption decimal(10,6),		-- Χιλιοστά Κλειστού Κατανάλωσης Boiler
		c_mil_special_costs decimal(10,6),			-- Χιλιοστά Κλειστού Ειδικών Δαπανών
		c_mil_owners decimal(10,6),					-- Χιλιοστά Κλειστού Ιδιοκτητών
		c_mil_billing decimal(10,6),				-- Χιλιοστά Κλειστού Έκδοσης
		c_mil_garage decimal(10,6),					-- Χιλιοστά Κλειστού Γκαράζ
		c_mil_monomers1 decimal(10,6),				-- Χιλιοστά Κλειστού Μονομερή1
		c_mil_monomers2 decimal(10,6),				-- Χιλιοστά Κλειστού Μονομερή2
		c_mil_monomers3 decimal(10,6),				-- Χιλιοστά Κλειστού Μονομερή3
		d_mil_elevator decimal(10,6),				-- Χιλιοστά με μειώσεις Ανελκυστήρα
		d_mil_shared decimal(10,6),					-- Χιλιοστά με μειώσεις Κοινοχρήστων
		d_mil_heating decimal(10,6),				-- Χιλιοστά με μειώσεις Θέρμανση
		d_mil_boiler decimal(10,6),					-- Χιλιοστά με μειώσεις Boiler
		d_mil_heating_consumption decimal(10,6),	-- Χιλιοστά με μειώσεις Κατανάλωσης Θέρμανσης
		d_mil_boiler_consumption decimal(10,6),		-- Χιλιοστά με μειώσεις Κατανάλωσης Boiler
		d_mil_special_costs decimal(10,6),			-- Χιλιοστά με μειώσεις Ειδικών Δαπανών
		d_mil_owners decimal(10,6),					-- Χιλιοστά με μειώσεις Ιδιοκτητών
		d_mil_billing decimal(10,6),				-- Χιλιοστά με μειώσεις Έκδοσης
		d_mil_garage decimal(10,6),					-- Χιλιοστά με μειώσεις Γκαράζ
		d_mil_monomers1 decimal(10,6),				-- Χιλιοστά με μειώσεις Μονομερή1
		d_mil_monomers2 decimal(10,6),				-- Χιλιοστά με μειώσεις Μονομερή2
		d_mil_monomers3 decimal(10,6),				-- Χιλιοστά με μειώσεις Μονομερή3
		tot_mil_elevator decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Ανελκυστήρα
		tot_mil_shared decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Κοινοχρήστων
		tot_mil_heating decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Θέρμανση
		tot_mil_boiler decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Boiler
		tot_mil_heating_consumption decimal(10,6),	-- Σύνολο Κανονικών Χιλιοστών Κατανάλωσης Θέρμανσης
		tot_mil_boiler_consumption decimal(10,6),	-- Σύνολο Κανονικών Χιλιοστών Κατανάλωσης Boiler
		tot_mil_special_costs decimal(10,6),		-- Σύνολο Κανονικών Χιλιοστών Ειδικών Δαπανών
		tot_mil_owners decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Ιδιοκτητών
		tot_mil_billing decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Έκδοσης
		tot_mil_garage decimal(10,6),				-- Σύνολο Κανονικών Χιλιοστών Γκαράζ
		tot_mil_monomers1 decimal(10,6),			-- Σύνολο Κανονικών Χιλιοστών Μονομερή1
		tot_mil_monomers2 decimal(10,6),			-- Σύνολο Κανονικών Χιλιοστών Μονομερή2
		tot_mil_monomers3 decimal(10,6),			-- Σύνολο Κανονικών Χιλιοστών Μονομερή3
		tot_d_mil_elevator decimal(10,6),			-- Σύνολο Χιλιοστών με μειώσεις Ανελκυστήρα
		tot_d_mil_shared decimal(10,6),				-- Σύνολο Χιλιοστών με μειώσεις Κοινοχρήστων
		tot_d_mil_heating decimal(10,6),			-- Σύνολο Χιλιοστών με μειώσεις Θέρμανση
		tot_d_mil_boiler decimal(10,6),				-- Σύνολο Χιλιοστών με μειώσεις Boiler
		tot_d_mil_heating_consumption decimal(10,6),-- Σύνολο Χιλιοστών με μειώσεις Κατανάλωσης Θέρμανσης
		tot_d_mil_boiler_consumption decimal(10,6),	-- Σύνολο Χιλιοστών με μειώσεις Κατανάλωσης Boiler
		tot_d_mil_special_costs decimal(10,6),		-- Σύνολο Χιλιοστών με μειώσεις Ειδικών Δαπανών
		tot_d_mil_owners decimal(10,6),				-- Σύνολο Χιλιοστών με μειώσεις Ιδιοκτητών
		tot_d_mil_billing decimal(10,6),			-- Σύνολο Χιλιοστών με μειώσεις Έκδοσης
		tot_d_mil_garage decimal(10,6),				-- Σύνολο Χιλιοστών με μειώσεις Γκαράζ
		tot_d_mil_monomers1 decimal(10,6),			-- Σύνολο Χιλιοστών με μειώσεις Μονομερή1
		tot_d_mil_monomers2 decimal(10,6),			-- Σύνολο Χιλιοστών με μειώσεις Μονομερή2
		tot_d_mil_monomers3 decimal(10,6)			-- Σύνολο Χιλιοστών με μειώσεις Μονομερή3
	)
	insert into #INVOICE(IncID,inhID,indid,bdgID,aptID,aptid_out,aptid_closed,CalcCatID,ttl,aptNam,AptOrd,repName,INDAmt,
						elevator_epivar,shared_epivar,heating_epivar,heating_consumption_epivar,special_costs_epivar,owners_epivar,billing_epivar,garage_epivar,monomers1_epivar,monomers2_epivar,monomers3_epivar,boiler_epivar,boiler_consumption_epivar, 
						elevator,shared,heating,heating_consumption,special_costs,owners,billing,garage,monomers1,monomers2,monomers3,boiler,boiler_consumption, 
						tot_elevator,tot_shared,tot_heating,tot_heating_consumption,tot_special_costs,tot_owners,tot_billing,tot_garage,tot_monomers1,tot_monomers2,tot_monomers3,tot_boiler,tot_boiler_consumption, 
						mil_elevator,mil_shared,mil_heating,mil_heating_consumption,mil_special_costs,mil_owners,mil_billing,mil_garage,mil_monomers1,mil_monomers2,mil_monomers3,mil_boiler,mil_boiler_consumption, 
						c_mil_elevator,c_mil_shared,c_mil_heating,c_mil_heating_consumption,c_mil_special_costs,c_mil_owners,c_mil_billing,c_mil_garage,c_mil_monomers1,c_mil_monomers2,c_mil_monomers3,c_mil_boiler,c_mil_boiler_consumption ,
						d_mil_elevator,d_mil_shared,d_mil_heating,d_mil_heating_consumption,d_mil_special_costs,d_mil_owners,d_mil_billing,d_mil_garage,d_mil_monomers1,d_mil_monomers2,d_mil_monomers3,d_mil_boiler,d_mil_boiler_consumption, 
						tot_mil_elevator,tot_mil_shared,tot_mil_heating,tot_mil_heating_consumption,tot_mil_special_costs,tot_mil_owners,tot_mil_billing,tot_mil_garage,tot_mil_monomers1,tot_mil_monomers2,tot_mil_monomers3,tot_mil_boiler,tot_mil_boiler_consumption,
						tot_d_mil_elevator,tot_d_mil_shared,tot_d_mil_heating,tot_d_mil_heating_consumption,tot_d_mil_special_costs,tot_d_mil_owners,tot_d_mil_billing,tot_d_mil_garage,tot_d_mil_monomers1,tot_d_mil_monomers2,tot_d_mil_monomers3 ,tot_d_mil_boiler,tot_d_mil_boiler_consumption 
					)


--ΓΕΝΙΚΟΣ ΤΥΠΟΣ (ΠΟΣΟ ΧΡΕΩΣΗΣ / ΣΥΝΟΛΟ ΧΙΛΙΟΣΤΩΝ ΜΕ ΜΕΙΩΣΕΙΣ) * ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ ΔΙΑΜΕΡΙΣΜΑΤΟΣ 
select 	IncID,inhID,indid,bdgID,aptID,AptOut,AptClosed,CalcCatID,ttl,Nam, Ord,repName,indamt, 
/*ΕΠΙΒ. ΑΝΕΛΚΥΣΤΗΡΑ*/	    CAST(case when tot_mil_elevator=0  then 0 else case when c_elevator=100 and calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then (((INDamt / tot_mil_d_elevator) * d_elevator)- (INDamt/tot_mil_elevator)*m_elevator)  else 0 end end AS DECIMAL(9,2)) as elevator_epivar,
/*ΕΠΙΒ. ΚΟΙΝΟΧΡΗΣΤΩΝ*/		CAST(case when tot_mil_shared=0  then 0 else case when c_shared=100 and calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9'	 then (((INDamt / tot_mil_d_shared) * d_shared)- (INDamt/tot_mil_shared)*m_shared) else 0 end end AS DECIMAL(9,2)) as shared_epivar,
/*ΕΠΙΒ. ΘΕΡΜΑΝΣΕΩΣ*/	    CAST(case when tot_mil_heating=0  then 0 else case when c_heating=100 and calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D'  then (((INDamt / tot_mil_d_heating) * d_heating)- (INDamt/tot_mil_heating)*m_heating) else 0 end end AS DECIMAL(9,2))  as heating_epivar,
/*ΕΠΙΒ. ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/	CAST(case when tot_mil_heating_consumption=0 then 0 else case when c_heating_consumption=100 and calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B' --AND UPPER(@CalcType) <>'9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE'  
																																			 then (((INDamt / tot_mil_d_heating_consumption) * d_heating_consumption)- (INDamt/tot_mil_heating_consumption)*m_heating_consumption) else 0 end end AS DECIMAL(9,2))  as heating_consumption_epivar, 
/*ΕΠΙΒ.ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/	CAST(case when tot_mil_special_costs=0  then 0 else case when c_special_costs=100 and calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then (((INDamt / tot_mil_d_special_costs) * d_special_costs)- (INDamt/tot_mil_special_costs)*m_special_costs) else 0 end end AS DECIMAL(9,2))  as special_costs_epivar,
/*ΕΠΙΒ.ΙΔΙΟΚΤΗΤΩΝ*/			CAST(case when tot_mil_owners=0  then 0 else case when c_owners=100 and calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' then (((INDamt / tot_mil_d_owners) * d_owners)- (INDamt/tot_mil_owners)*m_owners) 	else 0 end end AS DECIMAL(9,2))  as owners_epivar,
/*ΕΠΙΒ.ΕΚΔΟΣΗ*/				CAST(case when tot_mil_billing=0  then 0 else case when c_billing=100 and calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then (((INDamt / tot_mil_d_billing) * d_billing)- (INDamt/tot_mil_billing)*m_billing)	else 0 end end AS DECIMAL(9,2))  as billing_epivar,
/*ΕΠΙΒ.ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/		CAST(case when tot_mil_garage=0	then 0 else case when c_garage=100 and calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' then (((INDamt / tot_mil_d_garage) * d_garage)- (INDamt/tot_mil_garage)*m_garage)	else 0 end end AS DECIMAL(9,2))  as garage_epivar,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 1*/			CAST(case when tot_mil_monomers1=0  then 0 else case when c_monomers1=100 and calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then (((INDamt / tot_mil_d_monomers1) * d_monomers1)- (INDamt/tot_mil_monomers1)*m_monomers1) else 0 end end AS DECIMAL(9,2))  as monomers1_epivar,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 2*/			CAST(case when tot_mil_monomers2=0  then 0 else case when c_monomers2=100 and calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then (((INDamt / tot_mil_d_monomers2) * d_monomers2)- (INDamt/tot_mil_monomers2)*m_monomers2) else 0 end end AS DECIMAL(9,2))  as monomers2_epivar,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 3*/			CAST(case when tot_mil_monomers3=0  then 0 else case when c_monomers3=100 and calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' then (((INDamt / tot_mil_d_monomers3) * d_monomers3)- (INDamt/tot_mil_monomers3)*m_monomers3) else 0 end end AS DECIMAL(9,2))  as monomers3_epivar,
/*ΕΠΙΒ.ΘΕΡΜΑΝΣΕΩΣ(Boiler)*/	CAST(case when tot_mil_boiler=0  then 0 else case when c_boiler =100 and calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D'  then (((INDamt / tot_mil_d_boiler) * d_boiler)- (INDamt/tot_mil_boiler)*m_boiler) else 0 end end AS DECIMAL(9,2))  as boiler_epivar,
/*ΕΠΙΒ. ΚΑΤ/ΣΗ BOILER*/		CAST(case when tot_mil_boiler_consumption=0 then 0 else case when c_boiler_consumption=100 and calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'-- AND UPPER(@CalcTypeB) <>'9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE'  
																																					 then (((INDamt / tot_mil_d_boiler_consumption) * d_boiler_consumption)- (INDamt/tot_mil_boiler_consumption)*m_boiler_consumption) else 0 end end AS DECIMAL(9,2))  as boiler_consumption_epivar, 
							
	/*ΑΝΕΛΚΥΣΤΗΡΑ*/			CAST(case when tot_mil_elevator=0  then 0 else case when c_elevator=100 and calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then (INDamt / tot_mil_elevator)  * m_elevator else (INDamt / tot_mil_d_elevator) * d_elevator end end AS DECIMAL(9,2))  as elevator,
	/*ΚΟΙΝΟΧΡΗΣΤΩΝ*/		CAST(case when tot_mil_shared=0  then 0 else case when c_shared=100 and calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' then (INDamt / tot_mil_shared) * m_shared  else (INDamt / tot_mil_d_shared) * d_shared end end AS DECIMAL(9,2))  as shared,
	/*ΘΕΡΜΑΝΣΕΩΣ*/			CAST(case when tot_mil_heating=0  then 0 else case when c_heating=100 and calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then (INDamt / tot_mil_heating) *  m_heating else (INDamt / tot_mil_d_heating) * d_heating end end AS DECIMAL(9,2))  as heating,
	/*ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/	CAST(case when tot_mil_heating_consumption=0  then 0 else case when c_heating_consumption=100 and calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B'-- AND UPPER(@CalcType) <>'9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE'  
																					  then (INDamt / tot_mil_heating_consumption) * m_heating_consumption else (INDamt / tot_mil_d_heating_consumption) * d_heating_consumption end end AS DECIMAL(9,2))  as heating_consumption, 
	/*ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/		CAST(case when tot_mil_special_costs=0  then 0 else case when c_special_costs=100 and calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then (INDamt / tot_mil_special_costs) * m_special_costs else (INDamt / tot_mil_d_special_costs) * d_special_costs end end AS DECIMAL(9,2))  as special_costs,
	/*ΙΔΙΟΚΤΗΤΩΝ*/			CAST(case when tot_mil_owners=0  then 0 else case when c_owners=100 and calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' then (INDamt / tot_mil_owners)		* m_owners 		else (INDamt / tot_mil_d_owners) * d_owners  end end AS DECIMAL(9,2))  as owners,
	/*ΕΚΔΟΣΗ*/				CAST(case when tot_mil_billing=0  then 0 else case when c_billing=100 and calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then (INDamt / tot_mil_billing)		* m_billing		else (INDamt / tot_mil_d_billing) * d_billing end end AS DECIMAL(9,2))  as billing,
	/*ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/		CAST(case when tot_mil_garage=0  then 0 else case when c_garage=100 and calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' then (INDamt / tot_mil_garage)		* m_garage 		else (INDamt / tot_mil_d_garage) * d_garage end end AS DECIMAL(9,2))  as garage,
	/*ΜΟΝΟΜΕΡΗ 1*/			CAST(case when tot_mil_monomers1=0  then 0 else case when c_monomers1=100 and calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then (INDamt / tot_mil_monomers1)	* m_monomers1 	else (INDamt / tot_mil_d_monomers1) * d_monomers1 end end AS DECIMAL(9,2))  as monomers1,
	/*ΜΟΝΟΜΕΡΗ 2*/			CAST(case when tot_mil_monomers2=0  then 0 else case when c_monomers2=100 and calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then (INDamt / tot_mil_monomers2)	* m_monomers2 	else (INDamt / tot_mil_d_monomers2) * d_monomers2 end end AS DECIMAL(9,2))  as monomers2,
	/*ΜΟΝΟΜΕΡΗ 3*/			CAST(case when tot_mil_monomers3=0  then 0 else case when c_monomers3=100 and calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' then (INDamt / tot_mil_monomers3)	* m_monomers3 	else (INDamt / tot_mil_d_monomers3) * d_monomers3 end end AS DECIMAL(9,2))  as monomers3,
	/*ΘΕΡΜΑΝΣΕΩΣ(BOILER)*/	CAST(case when tot_mil_boiler=0  then 0 else case when c_boiler=100 and calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then (INDamt / tot_mil_boiler) *  m_boiler else (INDamt / tot_mil_d_boiler) * d_boiler end end AS DECIMAL(9,2))  as boiler,
	/*ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/	CAST(case when tot_mil_boiler_consumption=0  then 0 else case when c_boiler_consumption=100 and calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'  --AND UPPER(@CalcTypeB) <>'9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE'  
																				  then (INDamt / tot_mil_boiler_consumption) * m_boiler_consumption else (INDamt / tot_mil_d_boiler_consumption) * d_boiler_consumption end end AS DECIMAL(9,2))  as boiler_consumption, 

						0,0,0,0,0,0,0,0,0,0,0,0,0,
	m_elevator,m_shared,m_heating,m_heating_consumption,m_special_costs,m_owners,m_billing,m_garage,m_monomers1,m_monomers2,m_monomers3,m_boiler,m_boiler_consumption,
	c_elevator,c_shared,c_heating,c_heating_consumption,c_special_costs,c_owners,c_billing,c_garage,c_monomers1,c_monomers2,c_monomers3,c_boiler,c_boiler_consumption,
	d_elevator,d_shared,d_heating,d_heating_consumption,d_special_costs,d_owners,d_billing,d_garage,d_monomers1,d_monomers2,d_monomers3,d_boiler,d_boiler_consumption ,
	tot_mil_elevator,tot_mil_shared,tot_mil_heating,tot_mil_heating_consumption,tot_mil_special_costs,tot_mil_owners,tot_mil_billing,tot_mil_garage,tot_mil_monomers1,tot_mil_monomers2,tot_mil_monomers3,tot_mil_boiler,tot_mil_boiler_consumption,
	tot_mil_d_elevator,tot_mil_d_shared,tot_mil_d_heating,tot_mil_d_heating_consumption,tot_mil_d_special_costs,tot_mil_d_owners,tot_mil_d_billing,tot_mil_d_garage,tot_mil_d_monomers1,tot_mil_d_monomers2,tot_mil_d_monomers3 ,tot_mil_d_boiler,tot_mil_d_boiler_consumption 

					
from(					

	select NEWID() as IncID,@inhid  as InhID,IND.ID as INDId,
			BDG.ID as BDGId,APT.ID as APTId,IND.amt as INDAmt,ind.repName, calcCatID,
			APT.ttl,APT.ord,APT.nam,
			case when apt.out=1 then apt.id else NULL END AS AptOut,
			case when apt.closed=1 then apt.id else NULL END AS AptClosed,
			apmil.elevator as m_elevator ,apmil.shared as m_shared,apmil.heating as m_heating,apmil.heating_consumption as m_heating_consumption,apmil.special_costs as m_special_costs ,apmil.owners as m_owners,
			apmil.billing as m_billing ,apmil.garage as m_garage,apmil.monomers1 as m_monomers1,apmil.monomers2 as m_monomers2,apmil.monomers3 as m_monomers3,apmil.boiler as m_boiler,APMIL.boiler_consumption as m_boiler_consumption,
			apmil.c_elevator,apmil.c_shared,apmil.c_heating,apmil.c_heating_consumption,apmil.c_special_costs,apmil.c_owners,apmil.c_billing,apmil.c_garage,apmil.c_monomers1,apmil.c_monomers2,apmil.c_monomers3,apmil.d_elevator,c_boiler,c_boiler_consumption, 	
			apmil.d_shared,apmil.d_heating,apmil.d_heating_consumption,apmil.d_special_costs,apmil.d_owners,apmil.d_billing,apmil.d_garage,apmil.d_monomers1,apmil.d_monomers2,apmil.d_monomers3,apmil.d_boiler,d_boiler_consumption, 	
			(select sum(elevator) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0  )				as tot_mil_elevator,
			(select sum(shared) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_shared,
			(select sum(heating) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_heating,
			(select sum(heating_consumption) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )	as tot_mil_heating_consumption,
			(select sum(special_costs) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )		as tot_mil_special_costs,
			(select sum(owners) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_owners,
			(select sum(billing) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_billing,
			(select sum(garage) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_garage,
			(select sum(monomers1) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_monomers1,
			(select sum(monomers2) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_monomers2,
			(select sum(monomers3) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_monomers3,
			(select sum(boiler) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_boiler,
			(select sum(boiler_consumption) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )	as tot_mil_boiler_consumption,
			(select sum(d_elevator) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_elevator,
			(select sum(d_shared) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_d_shared,
			(select sum(d_heating) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_heating,
			(select sum(d_heating_consumption) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0)	as tot_mil_d_heating_consumption,
			(select sum(d_special_costs) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )		as tot_mil_d_special_costs,
			(select sum(d_owners) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_d_owners,
			(select sum(d_billing) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_billing,
			(select sum(d_garage) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_d_garage,
			(select sum(d_monomers1) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_monomers1,
			(select sum(d_monomers2) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_monomers2,
			(select sum(d_monomers3) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )			as tot_mil_d_monomers3,
			(select sum(d_boiler) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and apt.out=0 )				as tot_mil_d_boiler,
			(select sum(d_boiler_consumption) from APMIL inner join apt on apt.id=apmil.aptid  WHERE APMIL.bdgID= BDG.ID and  apt.out=0 )	as tot_mil_d_boiler_consumption
		from INH 				
		inner join IND on IND.inhID = INH.ID    
		inner join CALC_CAT  on CALC_CAT.ID  = IND.calcCatID 
		inner join BDG on BDG.ID = INH.bdgID 
		inner join APT on APT.bdgID  = BDG.ID
		inner join APMIL  on APMIL.aptID  = APT.ID
		where inh.ID =@inhid and APT.out=0
	) as s

	UPDATE #INVOICE SET 
	tot_elevator =				isnull(elevator + elevator_epivar,0),
	tot_shared =				isnull(shared + shared_epivar,0) ,
	tot_heating =				isnull(heating + heating_epivar,0) ,
	tot_heating_consumption  =	isnull(heating_consumption + heating_consumption_epivar,0) ,
	tot_special_costs =			isnull(special_costs + special_costs_epivar,0) ,
	tot_owners  =				isnull(owners + owners_epivar,0) ,
	tot_billing =				isnull(billing + billing_epivar,0) ,
	tot_garage =				isnull(garage + garage_epivar,0) ,
	tot_monomers1 =				isnull(monomers1 + monomers1_epivar,0) ,
	tot_monomers2=				isnull(monomers2 + monomers2_epivar,0) ,
	tot_monomers3=				isnull(monomers3 + monomers3_epivar,0), 
	tot_boiler=					isnull(boiler + boiler_epivar,0),
	tot_boiler_consumption=		isnull(boiler_consumption  + boiler_consumption_epivar ,0)


 --ΓΕΝΙΚΟΣ ΤΥΠΟΣ (ΠΟΣΟ ΧΡΕΩΣΗΣ / ΣΥΝΟΛΟ ΧΙΛΙΟΣΤΩΝ ΜΕ ΜΕΙΩΣΕΙΣ) * ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ ΔΙΑΜΕΡΙΣΜΑΤΟΣ 
 --(Υπάρχει ανάλυση του υπολογισμού στο excel που έχω στο Onenote με όνομα "ΥΠΟΛΟΓΙΣΜΟΣ ΚΛΕΙΣΤΩΝ1.xlsx")
	insert into INC(ID,inhID,indid,bdgID,aptID,aptid_out,aptid_closed,
					ep_elevator,ep_shared ,ep_heating ,ep_heating_consumption ,ep_special_costs ,ep_owners ,ep_billing ,ep_garage ,ep_monomers1 ,ep_monomers2 ,ep_monomers3 ,ep_boiler,ep_boiler_consumption,
					elevator,shared,heating,heating_consumption,special_costs,owners,billing,garage,monomers1,monomers2,monomers3,boiler,boiler_consumption,
					tot_elevator,tot_shared,tot_heating,tot_heating_consumption,tot_special_costs,tot_owners,tot_billing,tot_garage,tot_monomers1,tot_monomers2,tot_monomers3,tot_boiler,tot_boiler_consumption)
					
	select 	IncID,inhID,indid,bdgID,aptID,aptid_out,aptid_closed,
/*ΕΠΙΒ.ΑΝΕΛΚΥΣΤΗΡΑ*/			case when calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then elevator_epivar else 0 end,
/*ΕΠΙΒ.ΚΟΙΝΟΧΡΗΣΤΩΝ*/			case when calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' then shared_epivar else 0 end ,
/*ΕΠΙΒ.ΘΕΡΜΑΝΣΕΩΣ*/				case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then heating_epivar else 0 end,
/*ΕΠΙΒ.ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/		case when calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B' then heating_consumption_epivar else 0 end , 
/*ΕΠΙΒ.ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/		case when calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then special_costs_epivar else 0 end ,
/*ΕΠΙΒ.ΙΔΙΟΚΤΗΤΩΝ*/				case when calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' then owners_epivar else 0 end ,
/*ΕΠΙΒ.ΕΚΔΟΣΗ*/					case when calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then billing_epivar	else 0 end ,
/*ΕΠΙΒ.ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/			case when calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' then garage_epivar else 0 end ,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 1*/				case when calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then monomers1_epivar else 0 end ,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 2*/				case when calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then monomers2_epivar else 0 end ,
/*ΕΠΙΒ.ΜΟΝΟΜΕΡΗ 3*/				case when calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' then monomers3_epivar else 0 end ,
/*ΕΠΙΒ.ΘΕΡΜΑΝΣΕΩΣ(BOILER)*/		case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then boiler_epivar else 0 end,
/*ΕΠΙΒ.ΚΑΤ/ΣΗ BOILER*/			case when calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' then boiler_consumption_epivar else 0 end , 

/*ΑΝΕΛΚΥΣΤΗΡΑ*/					case when calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then elevator else 0 end,
/*ΚΟΙΝΟΧΡΗΣΤΩΝ*/				case when calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' then shared else 0 end ,
/*ΘΕΡΜΑΝΣΕΩΣ*/					case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then heating else 0 end,
/*ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/			case when calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B' then heating_consumption else 0 end , 
/*ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/				case when calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then special_costs else 0 end ,
/*ΙΔΙΟΚΤΗΤΩΝ*/					case when calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' then owners else 0 end ,
/*ΕΚΔΟΣΗ*/						case when calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then billing	else 0 end ,
/*ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/				case when calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' then garage else 0 end ,
/*ΜΟΝΟΜΕΡΗ 1*/					case when calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then monomers1 else 0 end ,
/*ΜΟΝΟΜΕΡΗ 2*/					case when calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then monomers2 else 0 end ,
/*ΜΟΝΟΜΕΡΗ 3*/					case when calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' then monomers3 else 0 end ,
/*ΘΕΡΜΑΝΣΕΩΣ(BOILER)*/			case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then boiler else 0 end,
/*ΚΑΤ/ΣΗ BOILER*/				case when calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' then boiler_consumption else 0 end , 

/*ΣΥΝΟΛΟ ΑΝΕΛΚΥΣΤΗΡΑ*/			case when calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then tot_elevator else 0 end,
/*ΣΥΝΟΛΟ ΚΟΙΝΟΧΡΗΣΤΩΝ*/			case when calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' then tot_shared else 0 end ,
/*ΣΥΝΟΛΟ ΘΕΡΜΑΝΣΕΩΣ*/			case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then tot_heating else 0 end,
/*ΣΥΝΟΛΟ ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/		case when calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B' then tot_heating_consumption else 0 end , 
/*ΣΥΝΟΛΟ ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/		case when calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then tot_special_costs else 0 end ,
/*ΣΥΝΟΛΟ ΙΔΙΟΚΤΗΤΩΝ*/			case when calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' then tot_owners else 0 end ,
/*ΣΥΝΟΛΟ ΕΚΔΟΣΗ*/				case when calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then tot_billing	else 0 end ,
/*ΣΥΝΟΛΟ ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/		case when calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' then tot_garage else 0 end ,
/*ΣΥΝΟΛΟ ΜΟΝΟΜΕΡΗ 1*/			case when calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then tot_monomers1 else 0 end ,
/*ΣΥΝΟΛΟ ΜΟΝΟΜΕΡΗ 2*/			case when calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then tot_monomers2 else 0 end ,
/*ΣΥΝΟΛΟ ΜΟΝΟΜΕΡΗ 3*/			case when calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' then tot_monomers3 else 0 end, 
/*ΣΥΝΟΛΟ ΘΕΡΜΑΝΣΕΩΣ(BOILER)*/	case when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then tot_boiler else 0 end,
/*ΣΥΝΟΛΟ ΚΑΤ/ΣΗ BOILER*/		case when calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' then tot_boiler_consumption else 0 end  

	FROM #INVOICE 

	drop table #INVOICE
	
	--Δημιουργία Αρίθμησης αποδείξεων-Ειδοποιητηρίων
	EXEC CREATEINVNUMBERS @inhid	

	--print '1'
		--Παλαια αυτονομια = ΑΥΤΟΝΟΜΙΑ ΜΕ ΣΤΑΘΕΡΟ ΠΑΓΙΟ 
		--(Υπάρχει ανάλυση του υπολογισμού στο excel που έχω στο Onenote με όνομα "ΚΑΤΑΜΕΡΙΣΜΟΣ ΘΕΡΜΑΝΣΗΣ ΣΤΑΘΕΡΟΥ ΠΑΓΙΟΥ2.xlsx")
		--ΘΕΡΜΑΝΣΗ
		if UPPER(@CalcType) ='9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE' and @ahpbHID <> '00000000-0000-0000-0000-000000000000'
		begin
			--Προσωρινός πίνακας που θα αποθηκεύσει τον υπολογισμό της κατανάλωσης θέρμανσης
			create table #CalcHeatingConsumption
			(
				AptID uniqueidentifier,						-- Διαμέρισμα
				ttl nvarchar(150),							-- Τίτλος Διαμερίσματος	
				Ord int,									-- Ταξινόμηση  Διαμερίσματος
				mesdif decimal(9,3) default 0,				-- Ώρες που έκαψε
				c_heating_consumption  int default 0,		-- Ποσοστό  κλειστών κατανάλωσης
				d_heating_consumption decimal(8,2) default 0,-- Χιλιοστα με εκπτώσεις κατανάλωσης
				m_heating_consumption decimal(8,2) default 0,-- Χιλιοστα κανονικά κατανάλωσης
				heating_consumption decimal(8,2) default 0,	-- Ποσό κατανάλωσης
				[ei*Ω] decimal(14,6) default 0,				-- Ώρες * Χιλιοστά με μειώσεις = [ei*Ω]
				fixedamount  decimal(8,2) default 0,		-- Ποσό Παγίου
				finalamount  decimal(8,2) default 0			-- Τελικό ποσό
			)


			DECLARE db_IND_CURSOR CURSOR FOR 

				-- Ποσό Κατανάλωσης θέρμανσης( Είναι αυτό που καταχωρεί στα έξοδα του παραστατικού)
				select ID, isnull(amt,0)  from ind where inhID=@inhid  and calcCatID='B139CE26-1ABA-4680-A1EE-623EC97C475B'

			OPEN db_IND_CURSOR
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
		  
			  -- Αν έχει περάσει ποσό στο παραστατικό
				if isnull(@amt,0) <> 0
				begin

					--Εισαγωγή διαμερισμάτων στον προσωρινό πίνακα
					insert into #CalcHeatingConsumption (AptID,ttl,ord,d_heating_consumption,c_heating_consumption,m_heating_consumption)
					select A.id,A.ttl,A.ord,APMIL.d_heating_consumption ,APMIL.c_heating_consumption,heating_consumption  
					from APT A
					inner join APMIL  on APMIL.aptID  = A.ID
					where APMIL.bdgID=@bdgid 


					--Ενημέρωση διαμερισμάτων στον προσωρινό πίνακα
					UPDATE C
					SET heating_consumption = apmil.d_heating_consumption,
					mesdif= isnull(ahpb.mesDif,0),
					c.d_heating_consumption =isnull(apmil.d_heating_consumption,0),
					c_heating_consumption=APMIL.c_heating_consumption,
					fixedamount=0,finalamount=0,
					[ei*Ω]=cast(isnull(ahpb.mesDif,0) * isnull(apmil.d_heating_consumption,0) as decimal(14,6))
					FROM #CalcHeatingConsumption C
					INNER JOIN AHPB ON AHPB.aptID=C.AptID 
					inner join APMIL  on APMIL.aptID  = C.AptID
					WHERE ahpbHID=@ahpbHID  and ahpb.boiler=0


					--Σύνολο Χιλιοστών κανονικών
					--select @TotMil=sum(m_heating_consumption) from #CalcHeatingConsumption

					--Σύνολο Χιλιοστών με εκπτώσεις
					select @TotNewMil=sum(d_heating_consumption) from #CalcHeatingConsumption
				
					--Σύνολο Χιλιοστών με εκπτώσεις * Ώρες(ei*Ω)
					select @ToteiΩ=sum([ei*Ω]) from #CalcHeatingConsumption
		   

					--Ενημέρωση προσωρινού πίνακα	
					update  #CalcHeatingConsumption
					set heating_consumption = cast(case when mesdif = 0 then 0 else  ((@amt *(c_heating_consumption  - @Hpc )/100) / @ToteiΩ)*[ei*Ω] end as decimal(9,2)),
					fixedamount=cast((((@amt*@Hpc) /100)/@TotNewMil )*d_heating_consumption  as decimal(9,2))

		   
 
					--Added at 28/09/2021
					update  #CalcHeatingConsumption set finalamount=isnull(heating_consumption,0) + fixedamount


					--Ενημέρωση τελικού πίνακα κατανάλωσης
					update INC set 
					heating_consumption = ISNULL(C.heating_consumption ,0),
					fixedamount=ISNULL(c.fixedamount,0 ),
					finalAmount=ISNULL(c.finalAmount,0 ),
					ep_heating_consumption= ISNULL(c.fixedamount,0 ),
					tot_heating_consumption=ISNULL(C.heating_consumption ,0) + ISNULL(c.fixedamount,0 ),
					[ei*Ω] = C.[ei*Ω]
					from INC 
					INNER JOIN  #CalcHeatingConsumption C ON C.AptID=INC.aptID 
					INNER JOIN dbo.IND ON dbo.INC.indID = dbo.IND.ID
					where INC.inhID =@inhid  and calcCatID='B139CE26-1ABA-4680-A1EE-623EC97C475B' and ind.id=@ind_ID 

					truncate table #CalcHeatingConsumption

				end
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			end
			CLOSE db_IND_CURSOR
			DEALLOCATE db_IND_CURSOR
			
			--Ενημέρωση εγγραφής ωρών ότι έχει οριστικοποιηθεί ώστε να μην εμφανιστεί στο  combo Που επιλέγεις ώρες
			update AHPB_H set finalized=1 where id =@ahpbHID and boiler=0


			drop table #CalcHeatingConsumption
		end
		
		set @amt = 0
		
		--print '2'
		--Παλαια αυτονομια = ΑΥΤΟΝΟΜΙΑ ΜΕ ΣΤΑΘΕΡΟ ΠΑΓΙΟ 
		--(Υπάρχει ανάλυση του υπολογισμού στο excel που έχω στο Onenote με όνομα "ΚΑΤΑΜΕΡΙΣΜΟΣ ΘΕΡΜΑΝΣΗΣ ΣΤΑΘΕΡΟΥ ΠΑΓΙΟΥ2.xlsx")
		--ΘΕΡΜΑΝΣΗ ΤΥΠΟΥ BOILER
		if UPPER(@CalcTypeB) ='9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE' and @ahpbHIDB <> '00000000-0000-0000-0000-000000000000'
		begin
			--Προσωρινός πίνακας που θα αποθηκεύσει τον υπολογισμό της κατανάλωσης θέρμανσης
			create table #CalcBoilerConsumption
			(
				AptID uniqueidentifier,						-- Διαμέρισμα
				ttl nvarchar(150),							-- Τίτλος Διαμερίσματος	
				Ord int,									-- Ταξινόμηση  Διαμερίσματος
				mesdif decimal(9,3) default 0,				-- Ώρες που έκαψε
				c_boiler_consumption int default 0,			-- Ποσοστό κατανάλωσης
				d_boiler_consumption decimal(8,2) default 0,-- Χιλιοστα με εκπτώσεις κατανάλωσης
				m_boiler_consumption decimal(8,2) default 0,-- Χιλιοστα κανονικά κατανάλωσης
				boiler_consumption decimal(8,2) default 0,	-- Ποσό κατανάλωσης
				[ei*Ω] decimal(14,6) default 0,				-- Ώρες * Χιλιοστά με μειώσεις = [ei*Ω]
				fixedamount  decimal(8,2) default 0,		-- Ποσό Παγίου
				finalamount  decimal(8,2) default 0			-- Τελικό ποσό
			)

			DECLARE db_IND_CURSOR CURSOR FOR 

			   -- Ποσό Κατανάλωσης θέρμανσης( Είναι αυτό που καταχωρεί στα έξοδα του παραστατικού)
				select ID,isnull(amt,0)  from ind where inhID=@inhid  and calcCatID='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'

			OPEN db_IND_CURSOR
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			WHILE @@FETCH_STATUS = 0  
			BEGIN  


				-- Αν έχει περάσει ποσό στο παραστατικό
				if isnull(@amt,0)<> 0
				begin


					--Εισαγωγή διαμερισμάτων στον προσωρινό πίνακα
					insert into #CalcBoilerConsumption (AptID,ttl,ord,d_boiler_consumption,c_boiler_consumption,m_boiler_consumption )
					select A.id,A.ttl,A.ord,APMIL.d_boiler_consumption ,APMIL.c_boiler_consumption,APMIL.boiler_consumption 
					from APT A
					inner join APMIL  on APMIL.aptID  = A.ID
					where APMIL.bdgID=@bdgid 

					--Ενημέρωση διαμερισμάτων στον προσωρινό πίνακα
					UPDATE C
					SET boiler_consumption = apmil.d_boiler_consumption,
					mesdif= isnull(ahpb.mesDif,0),
					c.d_boiler_consumption =isnull(apmil.d_boiler_consumption ,0),
					c_boiler_consumption=APMIL.c_boiler_consumption,
					fixedamount=0,finalamount=0,
					[ei*Ω]=cast(isnull(ahpb.mesDif,0) * isnull(apmil.d_boiler_consumption,0) as decimal(14,6))
					FROM #CalcBoilerConsumption C
					INNER JOIN AHPB ON AHPB.aptID=C.AptID 
					inner join APMIL  on APMIL.aptID  = C.AptID
					WHERE ahpbHID=@ahpbHIDB  and ahpb.boiler=1


					--Σύνολο Χιλιοστών κανονικών
					--select @TotMil=sum(m_heating_consumption) from #CalcHeatingConsumption

					--Σύνολο Χιλιοστών με εκπτώσεις
					select @TotNewMil=sum(d_boiler_consumption) from #CalcBoilerConsumption
				
					--Σύνολο Χιλιοστών με εκπτώσεις * Ώρες(ei*Ω)
					select @ToteiΩ=sum([ei*Ω]) from #CalcBoilerConsumption
		   

					--Ενημέρωση προσωρινού πίνακα	
					update  #CalcBoilerConsumption
					set boiler_consumption  = cast(case when mesdif = 0 then 0 else  ((@amt *(c_boiler_consumption  - @Hpb )/100) / @ToteiΩ)*[ei*Ω] end as decimal(9,2)),
					fixedamount=cast((((@amt*@Hpb) /100)/@TotNewMil )*d_boiler_consumption  as decimal(9,2))

 
					--Added at 28/09/2021
					update  #CalcBoilerConsumption set finalamount=isnull(boiler_consumption,0) + fixedamount

					--Ενημέρωση τελικού πίνακα κατανάλωσης
					update INC set 
					boiler_consumption = ISNULL(C.boiler_consumption ,0),
					fixedAmountB=ISNULL(c.fixedamount,0 ),
					finalAmount=ISNULL(c.finalAmount,0 ),
					ep_boiler_consumption= ISNULL(c.fixedamount,0 ),
					tot_boiler_consumption=ISNULL(C.boiler_consumption ,0) + ISNULL(c.fixedamount,0 ),
					[ei*Ω]=C.[ei*Ω] 
					from INC 
					INNER JOIN  #CalcBoilerConsumption  C ON C.AptID=INC.aptID 
					INNER JOIN dbo.IND ON dbo.INC.indID = dbo.IND.ID
					where INC.inhID =@inhid  and calcCatID='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'and ind.id=@ind_ID 

					truncate table #CalcBoilerConsumption

				end
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			end
			CLOSE db_IND_CURSOR
			DEALLOCATE db_IND_CURSOR

			--Ενημέρωση εγγραφής ωρών ότι έχει οριστικοποιηθεί ώστε να μην εμφανιστεί στο  combo Που επιλέγεις ώρες
			update AHPB_H set finalized=1 where id =@ahpbHID and boiler=0
		    drop table #CalcBoilerConsumption

		end
		set @amt = 0


		--print '3'
		
		--Υπολογισμος με FI  = ΑΥΤΟΝΟΜΙΑ ΜΕ ΧΡΗΣΗ FI (Υπάρχει ανάλυση του υπολογισμού στο excel που έχω στο Onenote με όνομα "ΥΠΟΛΟΓΙΣΜΟΣ ΜΕ FI.xlsx")
		--θερμανση
		if UPPER(@CalcType) ='11F7A89C-F64D-4596-A5AF-005290C5FA49' and @ahpbHID <> '00000000-0000-0000-0000-000000000000'
		begin
			--Προσωρινός πίνακας που θα αποθηκεύσει τον υπολογισμό της κατανάλωσης θέρμανσης με FI
			create table #CalcHeatingConsumptionFI
			(
				AptID uniqueidentifier,						-- Διαμέρισμα
				ttl nvarchar(150),							-- Τίτλος Διαμερίσματος	
				Ord int,									-- Ταξινόμηση  Διαμερίσματος
				fi decimal(8,3)  Default 0,					-- fi Διαμερίσματος
				mil decimal(9,3) Default 0,					-- Χιλιοστά Διαμερίσματος
				mesdif decimal(9,3) Default 0,				-- Ώρες που έκαψε
				milhour decimal(8,3) Default 0,				-- Χιλιοστά με μειώσεις * ώρες 
				[fi*ei] decimal(12,6) Default 0,			-- fi * Χιλιοστά με μειώσεις = [fi*ei]
				[ei*Ω] decimal(14,6) default 0,				-- Ώρες * Χιλιοστά με μειώσεις = [ei*Ω]
				heating_consumption decimal(7,2) Default 0,	-- Ποσό κατανάλωσης
				fixedamount  decimal(8,2) Default 0,		-- Ποσό Παγίου
				finalamount  decimal(8,2) Default 0			-- Τελικό ποσό
			)
		
			DECLARE db_IND_CURSOR CURSOR FOR 

				-- Ποσό Κατανάλωσης θέρμανσης( Είναι αυτό που καταχωρεί στα έξοδα του παραστατικού)
				select ID,isnull(amt,0)  from ind where inhID=@inhid  and calcCatID='B139CE26-1ABA-4680-A1EE-623EC97C475B'

			OPEN db_IND_CURSOR
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
		
			  -- Αν έχει περάσει ποσό στο παραστατικό
			  if isnull(@amt,0) <> 0
			  begin
			
			
				   --Εισαγωγή διαμερισμάτων στον προσωρινό πίνακα
				   insert into #CalcHeatingConsumptionFI (AptID,ttl,ord,mil,fi )
				   select A.id,A.ttl,A.ord,APMIL.d_heating_consumption,d_fi  
				   from APT A
				   inner join APMIL  on APMIL.aptID  = A.ID
				   where APMIL.bdgID=@bdgid 		

				   --Σύνολο Χιλιοστών
				   select @TotMil=sum(Mil) from #CalcHeatingConsumptionFI 

			
				--Ενημέρωση διαμερισμάτων στον προσωρινό πίνακα
				   UPDATE C
				   SET 
				   heating_consumption = apmil.d_heating_consumption,
				   mesdif= isnull(ahpb.mesDif,0),
				   fixedamount=0,finalamount=0
				   FROM #CalcHeatingConsumptionFI C
				   INNER JOIN AHPB ON AHPB.aptID=C.AptID 
				   inner join APMIL  on APMIL.aptID  = C.AptID
				   WHERE ahpbHID=@ahpbHID  and ahpb.boiler=0
		   
				 --Ενημέρωση προσωρινού πίνακα	
				   update  #CalcHeatingConsumptionFI 
				   set milhour=(heating_consumption/@TotMil)*mesdif,
				   [fi*ei]=fi*(mil/@TotMil),
				   [ei*Ω]=mesdif * (mil/@TotMil),
				   fixedamount = (fi*(mil/@TotMil))*@amt 
			   
			   
				   --Σύνολο χιλιοστών * ώρες διαμερισμάτων
				   select @Totmilhour   = sum(isnull(milhour,0)),@Totfimil = sum(isnull([fi*ei],0)) from  #CalcHeatingConsumptionFI 
			   
			   
				 --Ενημέρωση προσωρινού πίνακα	με την Κατανάλωση
				   update  #CalcHeatingConsumptionFI    
				   set heating_consumption=	case when mesdif = 0 then 0 else isnull(((milhour /@Totmilhour)  * (1-@Totfimil )) * @amt ,0) end
		   
 
				   --Added at 28/09/2021
				   update  #CalcHeatingConsumptionFI set finalamount=isnull(heating_consumption,0) + fixedamount

					--Ενημέρωση τελικού πίνακα κατανάλωσης
					update INC set 
					heating_consumption = ISNULL(C.heating_consumption ,0),
					fixedamount=ISNULL(c.fixedamount,0 ),
					finalAmount=ISNULL(c.finalAmount,0 ),
					ep_heating_consumption= ISNULL(c.fixedamount,0 ),
					tot_heating_consumption=ISNULL(C.heating_consumption ,0) + ISNULL(c.fixedamount,0 ),
					[fi*ei] = C.[fi*ei] ,
					fi = C.[fi*ei] ,
					[ei*Ω] = C.[ei*Ω]
					from INC 
					INNER JOIN  #CalcHeatingConsumptionFI C ON C.AptID=INC.aptID 
					INNER JOIN dbo.IND ON dbo.INC.indID = dbo.IND.ID
					where INC.inhID =@inhid  and calcCatID='B139CE26-1ABA-4680-A1EE-623EC97C475B' and ind.id=@ind_ID 

					truncate table #CalcHeatingConsumptionFI

				end

			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			end
			CLOSE db_IND_CURSOR
			DEALLOCATE db_IND_CURSOR			

			--Ενημέρωση εγγραφής ωρών ότι έχει οριστικοποιηθεί ώστε να μην εμφανιστεί στο  combo Που επιλέγεις ώρες
			update AHPB_H set finalized=1 where id =@ahpbHID  and boiler=0

		
			drop table #CalcHeatingConsumptionFI   		   

		end
		
		set @amt = 0

		--print '4'
		--Υπολογισμος με FI BOILER  = ΑΥΤΟΝΟΜΙΑ ΜΕ ΧΡΗΣΗ FI BOILER (Υπάρχει ανάλυση του υπολογισμού στο excel που έχω στο Onenote με όνομα "ΥΠΟΛΟΓΙΣΜΟΣ ΜΕ FI.xlsx")
		--Boiler
		if UPPER(@CalcTypeB) ='11F7A89C-F64D-4596-A5AF-005290C5FA49' and @ahpbHIDB <> '00000000-0000-0000-0000-000000000000'
		begin
			--Προσωρινός πίνακας που θα αποθηκεύσει τον υπολογισμό της κατανάλωσης θέρμανσης με FI
			create table #CalcboilerConsumptionFI
			(
				AptID uniqueidentifier,						-- Διαμέρισμα
				ttl nvarchar(150),							-- Τίτλος Διαμερίσματος	
				Ord int,									-- Ταξινόμηση  Διαμερίσματος
				fi decimal(8,3)  Default 0,					-- fi Διαμερίσματος
				mil decimal(9,3) Default 0,					-- Χιλιοστά Διαμερίσματος
				mesdif decimal(9,3) Default 0,				-- Ώρες που έκαψε
				milhour decimal(8,6) Default 0,				-- Χιλιοστά με μειώσεις * ώρες 
				[fi*ei] decimal(12,6) Default 0,			-- fi * Χιλιοστά με μειώσεις = [fi*ei]
				[ei*Ω] decimal(14,6) default 0,				-- Ώρες * Χιλιοστά με μειώσεις = [ei*Ω]
				boiler_consumption decimal(7,2),			-- Ποσό κατανάλωσης
				fixedamount  decimal(8,2) Default 0,		-- Ποσό Παγίου
				finalamount  decimal(8,2) Default 0			-- Τελικό ποσό
			)
		

			DECLARE db_IND_CURSOR CURSOR FOR 

			-- Ποσό Κατανάλωσης θέρμανσης( Είναι αυτό που καταχωρεί στα έξοδα του παραστατικού)
			  select ID, isnull(amt,0)  from ind where inhID=@inhid  and calcCatID='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'

			OPEN db_IND_CURSOR
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
		  
			  -- Αν έχει περάσει ποσό στο παραστατικό
			  if isnull(@amt,0) <> 0
			  begin
			

				   --Εισαγωγή διαμερισμάτων στον προσωρινό πίνακα
				   insert into #CalcboilerConsumptionFI (AptID,ttl,ord,mil,fi )
				   select A.id,A.ttl,A.ord,APMIL.d_boiler_consumption,d_fi  
				   from APT A
				   inner join APMIL  on APMIL.aptID  = A.ID
				   where APMIL.bdgID=@bdgid 		

				   --Σύνολο Χιλιοστών
				   select @TotMil=sum(Mil) from #CalcboilerConsumptionFI 

				--Ενημέρωση διαμερισμάτων στον προσωρινό πίνακα
				   UPDATE C
				   SET boiler_consumption = apmil.d_boiler_consumption,
				   mesdif= isnull(ahpb.mesDif,0),
				   fixedamount=0,finalamount=0
				   FROM #CalcboilerConsumptionFI C
				   INNER JOIN AHPB ON AHPB.aptID=C.AptID 
				   inner join APMIL  on APMIL.aptID  = C.AptID
				   WHERE ahpbHID=@ahpbHIDB  and ahpb.boiler=1
		   
				 --Ενημέρωση προσωρινού πίνακα	
				   update  #CalcboilerConsumptionFI 
				   set milhour=(boiler_consumption/@TotMil)*mesdif,
				   [fi*ei]=fi*(mil/@TotMil),
				   [ei*Ω]=mesdif * (mil/@TotMil),
				   fixedamount = (fi*(mil/@TotMil))*@amt 

				   --Σύνολο χιλιοστών * ώρες διαμερισμάτων
				   select @Totmilhour   = sum(isnull(milhour,0)),@Totfimil = sum(isnull([fi*ei],0)) from  #CalcboilerConsumptionFI 

					--Ενημέρωση προσωρινού πίνακα	με την Κατανάλωση
					update  #CalcboilerConsumptionFI    
					set boiler_consumption=	case when mesdif = 0 then 0 else isnull((milhour /@Totmilhour )  * (1-@Totfimil ) * @amt ,0) end
		   
 
					--Added at 28/09/2021
					update  #CalcboilerConsumptionFI set finalamount=isnull(boiler_consumption,0) + fixedamount

					--Ενημέρωση τελικού πίνακα κατανάλωσης
					update INC set 
					boiler_consumption = ISNULL(C.boiler_consumption ,0),
					fixedAmountB=ISNULL(c.fixedamount,0 ),
					finalAmountB=ISNULL(c.finalAmount,0 ),
					ep_boiler_consumption= ISNULL(c.fixedamount,0 ),
					tot_boiler_consumption=ISNULL(C.boiler_consumption ,0) + ISNULL(c.fixedamount,0 ),
					[fi*ei] = C.[fi*ei] ,
					fiBoiler = C.[fi*ei] ,
					[ei*Ω] = C.[ei*Ω]
					from INC 
					INNER JOIN  #CalcboilerConsumptionFI C ON C.AptID=INC.aptID 
					INNER JOIN dbo.IND ON dbo.INC.indID = dbo.IND.ID
					where INC.inhID =@inhid  and calcCatID='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' and ind.id=@ind_ID 

					truncate table #CalcboilerConsumptionFI
			  end
			
			FETCH NEXT FROM db_IND_CURSOR INTO @ind_ID ,@amt
			end
			CLOSE db_IND_CURSOR
			DEALLOCATE db_IND_CURSOR

			--Ενημέρωση εγγραφής ωρών ότι έχει οριστικοποιηθεί ώστε να μην εμφανιστεί στο  combo Που επιλέγεις ώρες
			update AHPB_H set finalized=1 where id =@ahpbHIDB and boiler=1

			drop table #CalcboilerConsumptionFI   		   

		end
		
		set @amt = 0

		--print '5'

		if @ahpbHID = '00000000-0000-0000-0000-000000000000' set @ahpbHID =null
		if @ahpbHIDB = '00000000-0000-0000-0000-000000000000' set @ahpbHIDB =null
		
		--Ενημέρωση Πίνακα για τα κλειστά διαμερίσματα. Εμφανίζεται στο report της συγκεντρωτικής
		exec [RepClosed] @inhid
		--print '6'
		--Ενημέρωση Παραστατικού ότι : υπλογίστηκε - δεν εκτυπώθηκε - Ώρες μέτρησης - Σύνολο εξόδων
		UPDATE INH 
		SET CALCULATED=1,DateOfCalculate =GETDATE(),dateofprint=null,ahpb_hid=@ahpbHID,ahpb_hidB=@ahpbHIDB ,TotalInh= (select sum(ind.amt ) from IND where inhid=@inhid )
		FROM INH 
		WHERE INH.ID = @inhid 
		
 
		--Εαν είναι διαχείρηση μόνο τότε καταχωρείται είσπραξη
		if @isManaged=1 
		begin
			-- Καταχώρηση Συνολικής Χρεωσης στις Εισπράξεις
			SET @ColHID  = NEWID()		
			insert into COL_H (ID , bdgID,inhID,[TotalDebit],[Totalcredit],[TotalBal],[createdOn])
			select @ColHID  ,bdgID, inhID,[debit] as TotalDebit,'0.00' as Totalcredit ,[debit] as TotalBal,GETDATE() as createdOn
			FROM(
			select  bdgID,inhID,
					SUM(SHARED)+ SUM(ELEVATOR) + SUM(BILLING) + SUM(HEATING) + SUM(SPECIAL_COSTS) + SUM(GARAGE) +
					SUM(owners) + SUM(MONOMERS1) + SUM(MONOMERS2) + SUM(MONOMERS3) + SUM(HEATING_CONSUMPTION) + SUM(boiler_consumption) AS [debit]
			from vw_inc 
			where inhID   = @inhid
			group by bdgID,inhID
			) as Cols
 
 
			-- Καταχώρηση κινήσεων Χρεώσεων στις Εισπράξεις
			--Στο πεδίο Bal βάζουμε την χρέωση και λογικό ειναι αφου δεν υπάρχει πίστωση ακομα
			insert into COL (colHID, bdgID,aptID,inhID,[debit], [createdOn],[bal],[credit],[tenant],[completed],[reserveAPT],debitusrID )
			select @ColHID , bdgID, aptID,inhID,[debit],createdOn,[debit],'0.00' as [credit],tenant,0,0,'26521B58-5590-4880-A31E-4E91A6CF964D' --System User
			FROM(
			select  bdgID,aptID, inhID ,
					SUM(tot_shared)+ SUM(tot_elevator) + SUM(tot_billing) + SUM(tot_heating ) + SUM(tot_special_costs ) + SUM(tot_garage ) + sum(tot_boiler_consumption) +
					SUM(tot_monomers1) + SUM(tot_monomers2) + SUM(tot_monomers3) + SUM(tot_heating_consumption) + sum(owners) AS [debit],
					GETDATE() as createdOn,1 as tenant
			from vw_inc 
			where inhID   = @inhid and owner_tenant=1
			group by bdgID,aptID,inhID
			union
			select  bdgID,aptID,inhID,
			SUM(tot_shared)+ SUM(tot_elevator) + SUM(tot_billing) + SUM(tot_heating ) + SUM(tot_special_costs ) + SUM(tot_garage ) + sum(tot_boiler_consumption) +
			SUM(tot_monomers1) + SUM(tot_monomers2) + SUM(tot_monomers3) + SUM(tot_heating_consumption) + sum(owners) AS [debit],
			GETDATE() as createdOn,0 as tenant
			from vw_inc 
			where inhID   = @inhid and owner_tenant=0
			--Removed at 10/08/2022 calcCatID ='E371555E-BB81-425B-9702-FB1EDE8DE73D'
			group by bdgID,aptID,inhID
			
			) as Cols WHERE debit<>0
			
			-- Καταχώρηση Χρέωσης στις εισπράξεις . Αφορά τα προοδευτικα
			INSERT INTO COL_P (BDGID,APTID,INHID,debit,tenant)
			select BDGID,APTID,INHID,sum(debit),tenant FROM COL WHERE inhID=@inhid AND debit<>0 group by BDGID,APTID,INHID,tenant

	end
	--Εαν δεν είναι διαχείρηση μόνο τότε καταχωρείται είσπραξη στις λοιπές εισπράξεις και μόνο για το πάγιο που έχει ορισρθεί ότι 
	-- δημιουργεί είσπραξη
	if @isManaged=0 
	Begin
		insert into COL_EXT (ID, bdgID,inhID,debit,bal,dtCredit )
		select newid(),@bdgid,@inhid,SUM(BILLING) ,SUM(BILLING),GETDATE()
		from vw_inc where inhID   = @inhid and calcCatID ='9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB'
	end
	--else
	--begin

	--		--***************************************************************************************************
	--		--***********************ΕΠΑΝΑΥΠΟΛΟΓΙΣΜΟΣ ΣΥΜΦΩΝΗΘΕΝΤΩΝ ΕΙΣΠΡΑΞΕΩΝ***********************************
	--		--***************************************************************************************************
	--		declare @debitusrID as uniqueidentifier,@aptID as uniqueidentifier,
	--				@Givencredit decimal(18,2),@modifiedBy as uniqueidentifier,
	--				@ColMethodID as uniqueidentifier,@TenantOwner bit

	--		DECLARE db_COL_CURSOR CURSOR FOR 
	--			select debitusrID ,@bdgID ,aptID ,@inhID ,Credit ,modifiedBy ,tenant ,ColMethodID
	--			From COL_D_TEMP where inhID=@inhID 
	--		OPEN db_COL_CURSOR
	--		FETCH NEXT FROM db_COL_CURSOR INTO @debitusrID ,@bdgID ,@aptID ,@inhID ,@Givencredit ,@modifiedBy  ,@TenantOwner,@ColMethodID 
	--		WHILE @@FETCH_STATUS = 0  
	--		BEGIN  

	--			exec [dbo].[col_Calculate] @debitusrID ,@bdgID ,@aptID ,@inhID ,@Givencredit ,@modifiedBy  , @ColMethodID , @TenantOwner ,1

	--		FETCH NEXT FROM db_COL_CURSOR INTO @debitusrID ,@bdgID ,@aptID ,@inhID ,@Givencredit ,@modifiedBy  ,@TenantOwner,@ColMethodID 
	--		end
	--		CLOSE db_COL_CURSOR
	--		DEALLOCATE db_COL_CURSOR

	--		--Σβήνω τις εγγραφές από τον προσωρινό πίνακα
	--		DELETE FROM COL_D_TEMP WHERE inhID=@inhid 
	--end
	--***************************************************************************************************
	--***********************ΕΝΗΜΕΡΩΣΗ ΥΠΟΛΟΙΠΩΝ ΔΙΑΜΕΡΙΣΜΑΤΩΝ***********************************
	--***************************************************************************************************
	
	if @isManaged=0
	begin
		Update apt set apt.bal_notadm  = bal_notadm   +  (select isnull(sum(COL_EXT.bal),0) from COL_EXT where completed=0 And bdgID  = @bdgid AND aptID=apt.ID  ) where bdgID  = @bdgid and APT.out=0 
	End
	else
	begin 
	
		DECLARE @aptID uniqueidentifier,@InhDebit decimal(18,3)
		--Δημιουργία προσωρινού πίνακα με τα διαμερίσματα που έχουν αρνητικά υπόλοιπα
		create table #AptWithNegativeBal(AptID uniqueidentifier, bal_adm decimal(18,3) )
		
		--Ενημέρωση προσωρινού πίνακα με τα διαμερίσματα που έχουν αρνητικό υπόλοιπο
		insert into #AptWithNegativeBal
		select apt.id,(bal_adm *(-1))
		From APT 
		inner join bdg on bdg.id=apt.bdgID 
		where bal_adm<0 AND  APT.bdgID= @bdgid

		--Ενημέρωση υπολοίπου Διαμερισμάτων. Είναι ασύγχρονο με την είσπραξη
		Update apt set apt.bal_adm  = CASE WHEN bal_adm<0 then bal_adm else 0 end + (select isnull(sum(COL.bal ),0) from COL where completed=0 And bdgID  = @bdgid AND aptID=apt.ID) where bdgID  = @bdgid and apt.out=0 

		--Καταχώρηση υπολοίπων διαμερισμάτων στον πίνακα Ιστορικότητας 
		insert into apt_bal_hist 
		Select id,@inhID, bal_adm,bal_notadm  from APT where bdgID=@bdgid  

		--ΑΥΤΟΜΑΤΗ ΕΙΣΠΡΑΞΗ ΓΙΑ ΔΙΑΜΕΡΙΣΜΑΤΑ ΜΕ ΑΡΝΗΤΙΚΟ ΥΠΟΛΟΙΠΟ
		DECLARE db_COL_CURSOR CURSOR FOR 
			SELECT AptID,bal_adm FROM #AptWithNegativeBal
		OPEN db_COL_CURSOR
		FETCH NEXT FROM db_COL_CURSOR INTO  @aptID,@InhDebit --@aptID,@InhDebit ,@debitusrID
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			--Εκτέλεση Είσπραξης για τα αρνητικά υπόλοιπα
			exec [dbo].[col_Calculate] '26521b58-5590-4880-a31e-4e91a6cf964d',@bdgID ,@aptID ,@inhID ,@InhDebit ,'26521b58-5590-4880-a31e-4e91a6cf964d'  , '75E3251D-077D-42B0-B79A-9F2886381A97' , 2 ,1,2,NULL

		FETCH NEXT FROM db_COL_CURSOR INTO @aptID,@InhDebit --@aptID,@InhDebit ,@debitusrID 
		end
		CLOSE db_COL_CURSOR
		DEALLOCATE db_COL_CURSOR

		drop table #AptWithNegativeBal
		

		
	end
	
COMMIT TRAN -- Transaction Success!
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN --RollBack in case of Error

    -- <EDIT>: From SQL2008 on, you must raise error messages as follows:
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

    SELECT   
       @ErrorMessage = ERROR_MESSAGE(),  
       @ErrorSeverity = ERROR_SEVERITY(),  
       @ErrorState = ERROR_STATE();  

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
    -- </EDIT>
END CATCH
END


 