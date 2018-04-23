' Developer Express Code Central Example:
' An example of custom Drag and Drop
' 
' This example demonstrates how to customize Drag and Drop feature for the
' TreeList using Drag and Drop-related events.
' Values of the "Position" and
' "Department" fields change depending on the new location of a record.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3921

Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Grid
Imports System.Windows

Namespace WPF_TreeList_Custom_Drag_and_Drop
	Partial Public Class MainWindow
		Inherits Window
		Public Class Employee
			Private privateID As Integer
			Public Property ID() As Integer
				Get
					Return privateID
				End Get
				Set(ByVal value As Integer)
					privateID = value
				End Set
			End Property
			Private privateParentID As Integer
			Public Property ParentID() As Integer
				Get
					Return privateParentID
				End Get
				Set(ByVal value As Integer)
					privateParentID = value
				End Set
			End Property
			Private privateName As String
			Public Property Name() As String
				Get
					Return privateName
				End Get
				Set(ByVal value As String)
					privateName = value
				End Set
			End Property
			Private privatePosition As String
			Public Property Position() As String
				Get
					Return privatePosition
				End Get
				Set(ByVal value As String)
					privatePosition = value
				End Set
			End Property
			Private privateDepartment As String
			Public Property Department() As String
				Get
					Return privateDepartment
				End Get
				Set(ByVal value As String)
					privateDepartment = value
				End Set
			End Property
			Public Overrides Function ToString() As String
				Return Name
			End Function
		End Class

		Public NotInheritable Class Stuff
			Private Sub New()
			End Sub
			Public Shared Function GetStuff() As ObservableCollection(Of Employee)
				Dim stuff As New ObservableCollection(Of Employee)()
				stuff.Add(New Employee() With {.ID = 1, .ParentID = 0, .Name = "Gregory S. Price", .Department = "", .Position = "President"})
				stuff.Add(New Employee() With {.ID = 2, .ParentID = 1, .Name = "Irma R. Marshall", .Department = "Marketing", .Position = "Vice President"})
				stuff.Add(New Employee() With {.ID = 3, .ParentID = 1, .Name = "John C. Powell", .Department = "Operations", .Position = "Vice President"})
				stuff.Add(New Employee() With {.ID = 4, .ParentID = 1, .Name = "Christian P. Laclair", .Department = "Production", .Position = "Vice President"})
				stuff.Add(New Employee() With {.ID = 5, .ParentID = 1, .Name = "Karen J. Kelly", .Department = "Finance", .Position = "Vice President"})

				stuff.Add(New Employee() With {.ID = 6, .ParentID = 2, .Name = "Brian C. Cowling", .Department = "Marketing", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 7, .ParentID = 2, .Name = "Thomas C. Dawson", .Department = "Marketing", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 8, .ParentID = 2, .Name = "Angel M. Wilson", .Department = "Marketing", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 9, .ParentID = 2, .Name = "Bryan R. Henderson", .Department = "Marketing", .Position = "Manager"})

				stuff.Add(New Employee() With {.ID = 10, .ParentID = 3, .Name = "Harold S. Brandes", .Department = "Operations", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 11, .ParentID = 3, .Name = "Michael S. Blevins", .Department = "Operations", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 12, .ParentID = 3, .Name = "Jan K. Sisk", .Department = "Operations", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 13, .ParentID = 3, .Name = "Sidney L. Holder", .Department = "Operations", .Position = "Manager"})

				stuff.Add(New Employee() With {.ID = 14, .ParentID = 4, .Name = "James L. Kelsey", .Department = "Production", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 15, .ParentID = 4, .Name = "Howard M. Carpenter", .Department = "Production", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 16, .ParentID = 4, .Name = "Jennifer T. Tapia", .Department = "Production", .Position = "Manager"})

				stuff.Add(New Employee() With {.ID = 17, .ParentID = 5, .Name = "Judith P. Underhill", .Department = "Finance", .Position = "Manager"})
				stuff.Add(New Employee() With {.ID = 18, .ParentID = 5, .Name = "Russell E. Belton", .Department = "Finance", .Position = "Manager"})
				Return stuff
			End Function
		End Class
		Public Sub New()
			InitializeComponent()
			treeList.ItemsSource = Stuff.GetStuff()
		End Sub

		Private Sub TreeListDragDropManager_Drop(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.DragDrop.TreeListDropEventArgs)
			If e.TargetNode IsNot Nothing Then
				For Each node As TreeListNode In e.DraggedRows
					TryCast(node.Content, Employee).Position = (TryCast(e.TargetNode.Content, Employee)).Position
					TryCast(node.Content, Employee).Department = (TryCast(e.TargetNode.Content, Employee)).Department
				Next node
			End If
			If e.DropTargetType = DropTargetType.InsertRowsIntoNode Then
				For Each node As TreeListNode In e.DraggedRows
					TryCast(node.Content, Employee).Position = ""
				Next node
			End If
		End Sub
	End Class
End Namespace



