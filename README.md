# Bind Syncfusion WinForms CheckBoxAdv to a SQL LocalDB (Boolean and Integer)

This repository contains two minimal WinForms samples that demonstrate data binding the Syncfusion CheckBoxAdv control to columns from a SQL LocalDB .mdf file. One sample binds to a boolean column, and the other binds to an integer column.

Both samples target .NET Framework 4.6.2 and use Syncfusion Windows Forms packages referenced via NuGet.

## How it works
Both samples follow the same pattern in Form1:

1. Build a connection string to attach the local database file:
   - In Form1.cs: `Path.GetFullPath("..\\..\\Database1.mdf")` is used to resolve the .mdf relative to the project output. The connection string is stored in `connectString` with `AttachDbFilename=...`.
2. Query the data:
   - `SqlDataAdapter` runs `SELECT * FROM [Table]` and fills a `DataTable` named "Table".
3. Bind the UI:
   - `dataGridView1.DataSource = dataTable;` shows the table for reference.
   - CheckBoxAdv binding differs per sample:
     - Boolean sample: in [BooleanValue/Form1.cs](BooleanValue/Form1.cs) the control binds its `BoolValue` property to the `CheckValue` column: `this.checkBoxAdv1.DataBindings.Add("BoolValue", dataTable, "CheckValue");`
     - Integer sample: in [IntegerValue/Form1.cs](IntegerValue/Form1.cs) the control binds its `IntValue` property to the `integerValue` column: `this.checkBoxAdv1.DataBindings.Add("IntValue", dataTable, "integerValue");`

The application entry point is standard WinForms in [BooleanValue/Program.cs](BooleanValue/Program.cs) and [IntegerValue/Program.cs](IntegerValue/Program.cs).

## Expected database schema
The samples expect a table named `[Table]` with columns matching the binding:
- Boolean sample: `CheckValue` (bit/boolean)
- Integer sample: `integerValue` (int)

If your local copy of Database1.mdf does not have these columns or names, update the binding map in Form1.cs accordingly.

## Notes and troubleshooting
- Framework/runtime: Confirm .NET Framework 4.6.2 is installed (see [App.config](App.config)).
- LocalDB: The connection string uses `(LocalDB)\MSSQLLocalDB` with `AttachDbFilename`. Ensure SQL Server Express LocalDB is available on your machine.
- Syncfusion licensing: The projects reference [Syncfusion.Licensing] via NuGet. If a license key is required at runtime, consult Syncfusion’s licensing documentation and initialize it in your app startup (not present in these files).
- Designer stubs: Some sections of `Form1.Designer.cs` are elided in this repo view. The critical parts used at runtime are the `DataGridView` and `Syncfusion.Windows.Forms.Tools.CheckBoxAdv` fields which are declared in the designer files in both samples.

## About the Sample
These WinForms samples demonstrate binding Syncfusion.Windows.Forms.Tools.CheckBoxAdv to database-backed fields while also displaying the same data in a System.Windows.Forms.DataGridView. The BooleanValue project uses the BoolValue property bound to a bit/boolean column (CheckValue). The IntegerValue project uses the IntValue property bound to an int column (integerValue). Use these as a starting point to bind CheckBoxAdv to your own tables and columns. Note: these samples focus on reading/displaying data and basic binding; persisting edits back to the database is not covered here.
