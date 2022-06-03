using DevExpress.Xpf.Core;
using System.Windows;

namespace WPF_GridControl_Custom_Drag_and_Drop {
    public partial class MainWindow : Window  {
        public MainWindow() {
            InitializeComponent();
            gridControl.ItemsSource = Staff.GetStaff();
        }
        
        void OnDropRecord(object sender, DropRecordEventArgs e) {
            object data = e.Data.GetData(typeof(RecordDragDropData));

            foreach (Employee employee in ((RecordDragDropData)data).Records) {
                employee.Position = ((Employee)e.TargetRecord).Position;
                employee.Department = ((Employee)e.TargetRecord).Department;
            }

            if (e.DropPosition == DropPosition.Inside) {
                foreach(Employee employee in ((RecordDragDropData)data).Records) {
                    employee.Position = "";
                }
            }
        }
    }
}