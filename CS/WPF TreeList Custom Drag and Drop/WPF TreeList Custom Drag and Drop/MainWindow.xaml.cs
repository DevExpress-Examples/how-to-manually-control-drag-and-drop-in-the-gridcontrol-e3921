// Developer Express Code Central Example:
// An example of custom Drag and Drop
// 
// This example demonstrates how to customize Drag and Drop feature for the
// TreeList using Drag and Drop-related events.
// Values of the "Position" and
// "Department" fields change depending on the new location of a record.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3921

using System.Windows.Controls;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace WPF_TreeList_Custom_Drag_and_Drop {
    public partial class MainWindow : Window  {
        public class Employee {
            public int ID { get; set; }
            public int ParentID { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
            public override string ToString() {
                return Name;
            }
        }

        public static class Stuff {
            public static ObservableCollection<Employee> GetStuff() {
                ObservableCollection<Employee> stuff = new ObservableCollection<Employee>();
                stuff.Add(new Employee() { ID = 1, ParentID = 0, Name = "Gregory S. Price", Department = "", Position = "President" });
                stuff.Add(new Employee() { ID = 2, ParentID = 1, Name = "Irma R. Marshall", Department = "Marketing", Position = "Vice President" });
                stuff.Add(new Employee() { ID = 3, ParentID = 1, Name = "John C. Powell", Department = "Operations", Position = "Vice President" });
                stuff.Add(new Employee() { ID = 4, ParentID = 1, Name = "Christian P. Laclair", Department = "Production", Position = "Vice President" });
                stuff.Add(new Employee() { ID = 5, ParentID = 1, Name = "Karen J. Kelly", Department = "Finance", Position = "Vice President" });

                stuff.Add(new Employee() { ID = 6, ParentID = 2, Name = "Brian C. Cowling", Department = "Marketing", Position = "Manager" });
                stuff.Add(new Employee() { ID = 7, ParentID = 2, Name = "Thomas C. Dawson", Department = "Marketing", Position = "Manager" });
                stuff.Add(new Employee() { ID = 8, ParentID = 2, Name = "Angel M. Wilson", Department = "Marketing", Position = "Manager" });
                stuff.Add(new Employee() { ID = 9, ParentID = 2, Name = "Bryan R. Henderson", Department = "Marketing", Position = "Manager" });

                stuff.Add(new Employee() { ID = 10, ParentID = 3, Name = "Harold S. Brandes", Department = "Operations", Position = "Manager" });
                stuff.Add(new Employee() { ID = 11, ParentID = 3, Name = "Michael S. Blevins", Department = "Operations", Position = "Manager" });
                stuff.Add(new Employee() { ID = 12, ParentID = 3, Name = "Jan K. Sisk", Department = "Operations", Position = "Manager" });
                stuff.Add(new Employee() { ID = 13, ParentID = 3, Name = "Sidney L. Holder", Department = "Operations", Position = "Manager" });

                stuff.Add(new Employee() { ID = 14, ParentID = 4, Name = "James L. Kelsey", Department = "Production", Position = "Manager" });
                stuff.Add(new Employee() { ID = 15, ParentID = 4, Name = "Howard M. Carpenter", Department = "Production", Position = "Manager" });
                stuff.Add(new Employee() { ID = 16, ParentID = 4, Name = "Jennifer T. Tapia", Department = "Production", Position = "Manager" });

                stuff.Add(new Employee() { ID = 17, ParentID = 5, Name = "Judith P. Underhill", Department = "Finance", Position = "Manager" });
                stuff.Add(new Employee() { ID = 18, ParentID = 5, Name = "Russell E. Belton", Department = "Finance", Position = "Manager" });
                return stuff;
            }
        }
        public MainWindow() {
            InitializeComponent();
            treeList.ItemsSource = Stuff.GetStuff();
        }

        private void TreeListDragDropManager_Drop(object sender, DevExpress.Xpf.Grid.DragDrop.TreeListDropEventArgs e) {
            if (e.TargetNode != null)
                foreach (TreeListNode node in e.DraggedRows) {
                    (node.Content as Employee).Position = (e.TargetNode.Content as Employee).Position;
                    (node.Content as Employee).Department = (e.TargetNode.Content as Employee).Department;
                }
            if (e.DropTargetType == DropTargetType.InsertRowsIntoNode)
                foreach (TreeListNode node in e.DraggedRows)
                    (node.Content as Employee).Position = "";
        }
    }
}



