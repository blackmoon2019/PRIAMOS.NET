
Imports DevExpress.DataAccess
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class INH
    Public Function InsertIND(ByVal sID As String, ByVal fDate As String, sBdgID As String, ByVal Months As Long) As Boolean
        Dim sSQL As String
        Try
            sSQL = "INSERT INTO IND (inhID, calcCatID, repName, amt, owner_tenant,regardingdeposit) " &
                    "Select " & toSQLValueS(sID) & ",calcCatID,repName,
                    case when calcCatID = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then amt 
                        when aptID is not null then (select sum(AmtPerCalc)  from vw_inc where inhid = 
                    (select top 1 ID from INH (nolock) where bdgid = vw_inc.bdgID  and extraordinary=0 and Calorimetric=0 and reserveAPT=0 and fdate< " & fDate & "  order by fDate desc)
                        and aptID=IEP.aptID    )   " &
                    " else (amt * " & Months & ") end as amt ,owner_tenant,regardingdeposit from iep where bdgID = " & sBdgID
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Ενημέρωση των ποσών όλων των εξόδων ανάλογα με το διάστημα που έχει επιλεχθεί, πλην της έκδοσης
    Public Function UpdateIND(ByVal sID As String, ByVal Months As Long) As Boolean
        Dim sSQL As String
        Try
            sSQL = "Update IND Set amt=IEP.amt * " & Months & " 
                From IND
                inner Join INH on INH.ID = IND.inhID 
                inner Join IEP on IEP.bdgID  = INH.bdgID And IND.calcCatID = IEP.calcCatID 
                where inhID =" & toSQLValueS(sID) & "  and IEP.calcCatID <>'9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB'"

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function DeleteIND(ByVal sID As String) As Boolean
        Dim sSQL As String
        Try
            sSQL = "DELETE FROM IND where inhID = " & toSQLValueS(sID)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Όταν είναι αυτονομία και έχουμε πάγια τότε καταχωρούμε αυτόματα το πάγιο σύμφωνα με το επιλεγμένο τιμολόγιο(Αφορά μόνο το Φυσικό Αέριο)

    ' Όταν είναι Κεντρική Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης σύμφωνα με το επιλεγμένο τιμολόγιο
    Public Function InsertINDCentralHeating(ByVal sID As String, sBdgID As String, ByVal cboinvOil As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal cboinvGas As DevExpress.XtraEditors.CheckedComboBoxEdit) As Boolean
        Dim sSQL As String
        Try
            For i As Integer = 0 To cboinvOil.Properties.Items.Count - 1
                If cboinvOil.Properties.Items(i).CheckState = CheckState.Checked Then
                    sSQL = "UPDATE INV_OIL SET InhID = " & toSQLValueS(sID) & " where ID = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                    sSQL = "INSERT INTO IND (inhID, calcCatID,invOilID,repName, amt, owner_tenant) " &
                            "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B', " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString) &
                            ", 'ΠΕΤΡΕΛΑΙΟ ΛΙΤΡΑ  ' + cast(liters as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ ΘΕΡΜΑΝΣΗ' ,totalPrice,'1' 
                            From INV_OIL
                            INNER JOIN BDG ON BDG.ID = INV_OIL.bdgID
                            where ftypeID = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' and BDG.ID = " & toSQLValueS(sBdgID) & " and INV_OIL.ID  = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                End If
            Next

            For i As Integer = 0 To cboinvGas.Properties.Items.Count - 1
                If cboinvGas.Properties.Items(i).CheckState = CheckState.Checked Then
                    sSQL = "UPDATE INV_GAS SET InhID = " & toSQLValueS(sID) & " where ID = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                    sSQL = "INSERT INTO IND (inhID, calcCatID,invGasID, repName, amt, owner_tenant) " &
                            "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B', " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString) &
                            ", 'ΦΥΣΙΚΟ ΑΕΡΙΟ  ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105),totalPrice,'1' 
                            From INV_GAS
                            INNER JOIN BDG ON BDG.ID = INV_GAS.bdgID
                            where ftypeID = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' and BDG.ID = " & toSQLValueS(sBdgID) & " and INV_GAS.ID  = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Όταν είναι Κεντρική Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης σύμφωνα με το επιλεγμένο τιμολόγιο
    Public Function UpdateINDCentralHeating(ByVal sID As String, sBdgID As String, ByVal cboinvOil As DevExpress.XtraEditors.CheckedComboBoxEdit, ByVal cboinvGas As DevExpress.XtraEditors.CheckedComboBoxEdit) As Boolean
        Dim sSQL As String
        Try
            For i As Integer = 0 To cboinvOil.Properties.Items.Count - 1
                If cboinvOil.Properties.Items(i).CheckState = CheckState.Checked Then
                    sSQL = "UPDATE INV_OIL SET InhID = " & toSQLValueS(sID) & " where ID = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                    sSQL = "INSERT INTO IND (inhID, calcCatID,invOilID,repName, amt, owner_tenant) " &
                           "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B', " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString) &
                           ", 'ΠΕΤΡΕΛΑΙΟ ΛΙΤΡΑ  ' + cast(liters as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ ΘΕΡΜΑΝΣΗ' ,totalPrice,'1' 
                            From INV_OIL
                            INNER JOIN BDG ON BDG.ID = INV_OIL.bdgID
                            LEFT JOIN IND on IND.invOilID = INV_OIL.ID
                            where IND.invOilID is null and ftypeID = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' and BDG.ID = " & toSQLValueS(sBdgID) & " and INV_OIL.ID  = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)

                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Else
                    sSQL = "UPDATE INV_OIL SET InhID = NULL   where ID = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                    sSQL = "DELETE from IND where inhID = " & toSQLValueS(sID) & " and invOilID  = " & toSQLValueS(cboinvOil.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                End If
            Next
            For i As Integer = 0 To cboinvGas.Properties.Items.Count - 1
                If cboinvGas.Properties.Items(i).CheckState = CheckState.Checked Then
                    sSQL = "UPDATE INV_GAS SET InhID = " & toSQLValueS(sID) & " where ID = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    sSQL = "INSERT INTO IND (inhID, calcCatID, invGasID,repName, amt, owner_tenant) " &
                       "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B'," & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString) &
                       ", 'ΦΥΣΙΚΟ ΑΕΡΙΟ  ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105),totalPrice,'1' 
                        From INV_GAS
                            INNER JOIN BDG ON BDG.ID = INV_GAS.bdgID
                            LEFT JOIN IND on IND.invGasID = INV_GAS.ID
                            where  IND.invGasID is null and  ftypeID = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' and BDG.ID = " & toSQLValueS(sBdgID) & " and INV_GAS.ID  = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)

                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Else
                    sSQL = "UPDATE INV_GAS SET InhID = NULL   where ID = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                    sSQL = "DELETE from IND where inhID = " & toSQLValueS(sID) & " and invGasID  = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
    Public Function InsertINDConsumption(ByVal sID As String, sBdgID As String, ByVal sAhpbH As String, ByVal shpbHB As String) As Boolean
        Dim sSQL As String
        Try
            sSQL = "INSERT INTO IND (inhID,consumptionID, calcCatID,repName, amt, owner_tenant) " &
                                   "Select " & toSQLValueS(sID) & ",CONSUMPTIONS.ID,'B139CE26-1ABA-4680-A1EE-623EC97C475B',
                                   case when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' then 'ΠΕΤΡΕΛΑΙΟ  ' + cast(consumptionLiterH as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ ΘΕΡΜΑΝΣΗ' 
	                                    when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' then 'ΦΥΣ. ΑΕΡΙΟ ΓΙΑ ΘΕΡΜ. ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105)
	                                    else '' end as repName,consumptionH,'1' 
                                    FROM CONSUMPTIONS 
                                     LEFT JOIN INV_GAS ON INV_GAS.ID = CONSUMPTIONS.invGasID             
                                        where consumptionH<> 0 and ahpbHIDH  = " & sAhpbH
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            sSQL = "INSERT INTO IND (inhID, consumptionID,calcCatID, repName, amt, owner_tenant) " &
               "Select " & toSQLValueS(sID) & ",CONSUMPTIONS.ID,'2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72',
                                   case when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' then 'ΠΕΤΡΕΛΑΙΟ  ' + cast(consumptionLiterB as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ BOILER' 
	                                    when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' then 'ΦΥΣ. ΑΕΡΙΟ ΓΙΑ BOILER ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105)
	                                    else '' end as repName, consumptionB,'1' 
                                        FROM CONSUMPTIONS 
                                        LEFT JOIN INV_GAS ON INV_GAS.ID = CONSUMPTIONS.invGasID             
                                        where consumptionB<> 0 and ahpbHIDB  = " & shpbHB
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
    Public Function UpdateINDConsumption(ByVal sID As String, sBdgID As String, Optional ByVal sAhpbH As String = "", Optional ByVal sAhpbHB As String = "") As Boolean
        Dim sSQL As String
        Try
            If sAhpbH.Length > 0 Then
                ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
                sSQL = "INSERT INTO IND (inhID,consumptionID, calcCatID, repName, amt, owner_tenant) " &
                        "Select " & toSQLValueS(sID) & ",CONSUMPTIONS.ID,'B139CE26-1ABA-4680-A1EE-623EC97C475B',
                                case when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' then 'ΠΕΤΡΕΛΑΙΟ  ' + cast(consumptionLiterH as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ ΘΕΡΜΑΝΣΗ' 
	                                    when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' then 'ΦΥΣ. ΑΕΡΙΟ ΓΙΑ ΘΕΡΜ. ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105)
	                    else '' end as repName, consumptionH,'1' 
                            FROM CONSUMPTIONS 
                            LEFT JOIN INV_GAS ON INV_GAS.ID = CONSUMPTIONS.invGasID             
                        where consumptionH<> 0 and ahpbHIDH  = " & sAhpbH &
                        " and 'B139CE26-1ABA-4680-A1EE-623EC97C475B' not in(select   calcCatID from ind LEFT JOIN INV_GAS ON INV_GAS.ID = ind.invGasID   where isnull(fixed,0) = 0 and  ind.inhID= " & toSQLValueS(sID) & ")"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
            If sAhpbHB.Length > 0 Then
                sSQL = "INSERT INTO IND (inhID,consumptionID, calcCatID, repName,  amt, owner_tenant) " &
                        "Select " & toSQLValueS(sID) & ",CONSUMPTIONS.ID,'2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72',
                                    case when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = 'AA662AEB-2B3B-4189-8253-A904669E7BCB' then 'ΠΕΤΡΕΛΑΙΟ  ' + cast(consumptionLiterB as nvarchar(10)) + ' ΛΙΤΡΑ ΓΙΑ BOILER' 
	                                        when (select top 1 ftypeID from BDG where ID = " & sBdgID & ") = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' then 'ΦΥΣ. ΑΕΡΙΟ ΓΙΑ BOILER ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105)
	                        else '' end as repName,consumptionB,'1' 
                            FROM CONSUMPTIONS 
                            LEFT JOIN INV_GAS ON INV_GAS.ID = CONSUMPTIONS.invGasID             
                            where consumptionB<>0 and ahpbHIDB  = " & sAhpbHB &
                        " and  '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' not in (select   calcCatID from ind LEFT JOIN INV_GAS ON INV_GAS.ID = ind.invGasID   where isnull(fixed,0)  = 0 and ind.inhID= " & toSQLValueS(sID) & ")"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function InsertINDFixedConsumption(ByVal sID As String, ByVal sBdgID As String, ByVal sInvGasID As String, ByVal mode As Integer, Optional ByVal cboinvGas As DevExpress.XtraEditors.CheckedComboBoxEdit = Nothing) As Boolean
        Dim sSQL As String
        Try
            Select Case mode
                Case 0
                    sSQL = "INSERT INTO IND (inhID, calcCatID,invGasID, repName, amt, owner_tenant) " &
                    "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B', " & toSQLValueS(sInvGasID) &
                    ", case when (select top 1 ftypeID from BDG where ID = " & toSQLValueS(sBdgID) & ") = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' then 'ΦΥΣ. ΑΕΡΙΟ ΠΑΓΙΟ ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105) else '' end as repName, 
                    totalPrice,'1' 
                    FROM INV_GAS
                    where inhID  = " & toSQLValueS(sID) & " and ID = " & toSQLValueS(sInvGasID)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

                Case 1
                    For i As Integer = 0 To cboinvGas.Properties.Items.Count - 1
                        If cboinvGas.Properties.Items(i).CheckState = CheckState.Checked Then
                            sSQL = "UPDATE INV_GAS SET InhID = " & toSQLValueS(sID) & " where ID = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using

                            sSQL = "INSERT INTO IND (inhID, calcCatID,invGasID, repName, amt, owner_tenant) " &
                            "Select " & toSQLValueS(sID) & ",'B139CE26-1ABA-4680-A1EE-623EC97C475B', " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString) &
                            ", 'ΦΥΣ. ΑΕΡΙΟ ΠΑΓΙΟ  ' + CONVERT(VARCHAR(10), INV_GAS.fDateConsumption  , 105) + ' - ' + CONVERT(VARCHAR(10), INV_GAS.tDateConsumption  , 105),totalPrice,'1' 
                            From INV_GAS
                            INNER JOIN BDG ON BDG.ID = INV_GAS.bdgID
                            where " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString) & " not in( select invGasID from IND where IND.invGasID  =  " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString) & ")" &
                            " and ftypeID = '3E3B5B65-6B09-4CAA-B467-24A1108C0F0C' and BDG.ID = " & toSQLValueS(sBdgID) &
                            " and INV_GAS.ID  = " & toSQLValueS(cboinvGas.Properties.Items(i).Value.ToString)
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                        End If
                    Next

            End Select
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


End Class
