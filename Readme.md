<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128651902/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3921)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid – Handle Drag & Drop Operations

This example adds custom logic to the built-in drag & drop feature of the [`GridControl`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) with a [`TreeListView`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView).

When a user drops one or more records, the grid updates `Position` and `Department` fields of the moved employees to match the target record. If the drop position is `Inside`, the grid clears the `Position` field.

![Handle Drag & Drop Operations](./Images/drag-and-drop.jpg)

You can handle drag & drop operations to integrate your business rules into the standard drag & drop process (for example, to update field values, trigger calculations, or adjust related records based on the drop target).

## Implementation Details

### Grid Setup

```xaml
<dxg:GridControl SelectionMode="Row" AutoGenerateColumns="AddNew">
  <dxg:GridControl.View>
    <dxg:TreeListView
      KeyFieldName="ID"
      ParentFieldName="ParentID"
      AutoExpandAllNodes="True"
      AllowDragDrop="True"
      DropRecord="OnDropRecord"/>
  </dxg:GridControl.View>
</dxg:GridControl>
```

### Custom Drop Logic

1. Retrieve dragged records from `e.Data` as [`RecordDragDropData`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Core.RecordDragDropData).
2. Assign **Position** and **Department** values from the target record to dragged employees.
3. If `e.DropPosition == DropPosition.Inside`, clear the **Position** field.

```csharp
void OnDropRecord(object sender, DropRecordEventArgs e) {
    var data = (RecordDragDropData)e.Data.GetData(typeof(RecordDragDropData));
    var target = (Employee)e.TargetRecord;

    foreach (Employee employee in data.Records) {
        employee.Position = target.Position;
        employee.Department = target.Department;
    }

    if (e.DropPosition == DropPosition.Inside) {
        foreach (Employee employee in data.Records)
            employee.Position = string.Empty;
    }
}
```

## Files to Review

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))

## Documentation

* [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl)
* [TreeListView](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView)
* [Drag & Drop Options](https://docs.devexpress.com/WPF/119241/controls-and-libraries/data-grid/drag-and-drop/drag-and-drop-options)
* [Process Drag & Drop Operations](https://docs.devexpress.com/WPF/400431/controls-and-libraries/data-grid/drag-and-drop/process-drag-and-drop-operations)
* [Drag & Drop](https://docs.devexpress.com/WPF/11346/controls-and-libraries/data-grid/drag-and-drop)

## More Examples

* [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/wpf-data-grid-implement-crud-operations)
* [WPF Grid - Resize Rows Using a Splitter](https://github.com/sergepilipchuk/wpf-grid-resize-rows-using-splitter)
* [WPF Data Grid - Specify Custom Content for Headers Displayed in the Column Chooser](https://github.com/DevExpress-Examples/wpf-data-grid-custom-content-for-column-chooser-headers)
* [WPF Data Grid - Bind to Dynamic Data](https://github.com/DevExpress-Examples/wpf-bind-gridcontrol-to-dynamic-data)
* [WPF Grid (TreeListView) - Sync TreeListNode Expansion with ViewModel](https://github.com/DevExpress-Examples/wpf-grid-sync-isnodeexpanded-with-view-model)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-handle-drag-and-drop&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-handle-drag-and-drop&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
