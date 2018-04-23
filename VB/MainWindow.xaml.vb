Imports System.Collections.ObjectModel
Imports System.Windows
Imports DevExpress.Xpf.Core

Namespace WPF_GridControl_Custom_Drag_and_Drop
    Partial Public Class MainWindow
        Inherits Window

        Public Class Employee
            Public Property ID() As Integer
            Public Property ParentID() As Integer
            Public Property Name() As String
            Public Property Position() As String
            Public Property Department() As String
            Public Overrides Function ToString() As String
                Return Name
            End Function
        End Class

        Public NotInheritable Class Stuff

            Private Sub New()
            End Sub

            Public Shared Function GetStuff() As ObservableCollection(Of Employee)

                Dim stuff_Renamed As New ObservableCollection(Of Employee)()
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 1, _
                    .ParentID = 0, _
                    .Name = "Gregory S. Price", _
                    .Department = "", _
                    .Position = "President" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 2, _
                    .ParentID = 1, _
                    .Name = "Irma R. Marshall", _
                    .Department = "Marketing", _
                    .Position = "Vice President" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 3, _
                    .ParentID = 1, _
                    .Name = "John C. Powell", _
                    .Department = "Operations", _
                    .Position = "Vice President" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 4, _
                    .ParentID = 1, _
                    .Name = "Christian P. Laclair", _
                    .Department = "Production", _
                    .Position = "Vice President" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 5, _
                    .ParentID = 1, _
                    .Name = "Karen J. Kelly", _
                    .Department = "Finance", _
                    .Position = "Vice President" _
                })

                stuff_Renamed.Add(New Employee() With { _
                    .ID = 6, _
                    .ParentID = 2, _
                    .Name = "Brian C. Cowling", _
                    .Department = "Marketing", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 7, _
                    .ParentID = 2, _
                    .Name = "Thomas C. Dawson", _
                    .Department = "Marketing", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 8, _
                    .ParentID = 2, _
                    .Name = "Angel M. Wilson", _
                    .Department = "Marketing", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 9, _
                    .ParentID = 2, _
                    .Name = "Bryan R. Henderson", _
                    .Department = "Marketing", _
                    .Position = "Manager" _
                })

                stuff_Renamed.Add(New Employee() With { _
                    .ID = 10, _
                    .ParentID = 3, _
                    .Name = "Harold S. Brandes", _
                    .Department = "Operations", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 11, _
                    .ParentID = 3, _
                    .Name = "Michael S. Blevins", _
                    .Department = "Operations", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 12, _
                    .ParentID = 3, _
                    .Name = "Jan K. Sisk", _
                    .Department = "Operations", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 13, _
                    .ParentID = 3, _
                    .Name = "Sidney L. Holder", _
                    .Department = "Operations", _
                    .Position = "Manager" _
                })

                stuff_Renamed.Add(New Employee() With { _
                    .ID = 14, _
                    .ParentID = 4, _
                    .Name = "James L. Kelsey", _
                    .Department = "Production", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 15, _
                    .ParentID = 4, _
                    .Name = "Howard M. Carpenter", _
                    .Department = "Production", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 16, _
                    .ParentID = 4, _
                    .Name = "Jennifer T. Tapia", _
                    .Department = "Production", _
                    .Position = "Manager" _
                })

                stuff_Renamed.Add(New Employee() With { _
                    .ID = 17, _
                    .ParentID = 5, _
                    .Name = "Judith P. Underhill", _
                    .Department = "Finance", _
                    .Position = "Manager" _
                })
                stuff_Renamed.Add(New Employee() With { _
                    .ID = 18, _
                    .ParentID = 5, _
                    .Name = "Russell E. Belton", _
                    .Department = "Finance", _
                    .Position = "Manager" _
                })
                Return stuff_Renamed
            End Function
        End Class
        Public Sub New()
            InitializeComponent()
            treeList.ItemsSource = Stuff.GetStuff()
        End Sub

        Private Sub OnDropRecord(ByVal sender As Object, ByVal e As DropRecordEventArgs)
            Dim data As Object = e.Data.GetData(GetType(RecordDragDropData))

            For Each employee As Employee In DirectCast(data, RecordDragDropData).Records
                employee.Position = CType(e.TargetRecord, Employee).Position
                employee.Department = CType(e.TargetRecord, Employee).Department
            Next employee

            If e.DropPosition = DropPosition.Inside Then
                For Each employee As Employee In DirectCast(data, RecordDragDropData).Records
                    employee.Position = ""
                Next employee
            End If
        End Sub
    End Class
End Namespace