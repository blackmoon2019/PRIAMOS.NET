Partial Class Priamos_NETDataSet2
    Partial Public Class COL_INHDataTable
        Private Sub COL_INHDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.inhIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class COL_APTDataTable
    End Class

    Partial Public Class DataTable1DataTable
    End Class
End Class

Namespace Priamos_NETDataSet2TableAdapters
    Partial Public Class vw_COL_BDGTableAdapter
    End Class

    Partial Public Class vw_COLTableAdapter
    End Class

    Partial Public Class vw_COLHTableAdapter
    End Class

    Partial Public Class vw_COL_INHTableAdapter
    End Class
End Namespace
