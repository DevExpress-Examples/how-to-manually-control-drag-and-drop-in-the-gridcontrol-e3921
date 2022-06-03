Imports DevExpress.Xpf.Core
Imports System.Windows

Namespace WPF_GridControl_Custom_Drag_and_Drop

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.gridControl.ItemsSource = GetStaff()
        End Sub

        Private Sub OnDropRecord(ByVal sender As Object, ByVal e As DropRecordEventArgs)
            Dim data As Object = e.Data.GetData(GetType(RecordDragDropData))
            For Each employee As Employee In CType(data, RecordDragDropData).Records
                employee.Position = CType(e.TargetRecord, Employee).Position
                employee.Department = CType(e.TargetRecord, Employee).Department
            Next

            If e.DropPosition = DropPosition.Inside Then
                For Each employee As Employee In CType(data, RecordDragDropData).Records
                    employee.Position = ""
                Next
            End If
        End Sub
    End Class
End Namespace
