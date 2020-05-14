using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace CompareExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnFile1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Title = "Seleccione el archivo 1",
                InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}",
                Filter = "Libro de Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LblFile1.Text = dialog.FileName;
            }
        }

        private void BtnFile2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Title = "Seleccione el archivo 2",
                InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}",
                Filter = "Libro de Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LblFile2.Text = dialog.FileName;
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            BtnCompare.Enabled = false;

            if (string.IsNullOrEmpty(LblFile1.Text))
            {
                MessageBox.Show("Debe seleccionar el archivo 1");
                BtnCompare.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(LblFile2.Text))
            {
                MessageBox.Show("Debe seleccionar el archivo 2");
                BtnCompare.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(TxtSheetName.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la hoja");
                BtnCompare.Enabled = true;
                return;
            }

            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\DifferentRecords.xlsx";
            CompareExcelFiles(LblFile1.Text, LblFile2.Text, TxtSheetName.Text, path);

            if (CbxStartExcel.Checked)
            {
                Process.Start(path);
            }

            BtnCompare.Enabled = true;
        }

        public void CompareExcelFiles(string file1, string file2, string sheet, string path)
        {
            var dataTable = new DataTable();
            
            try
            {
                var dt1 = GetDataTableFromExcel(file1, sheet);
                var dt2 = GetDataTableFromExcel(file2, sheet);

                dataTable = GetDifferentRecords(dt1, dt2);
                ExportToExcel(dataTable, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetDataTableFromExcel(string file, string sheet)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   $"Data Source={file};" +
                                   $"Extended Properties=Excel 12.0;";

            var query = $"SELECT * FROM [{sheet}$]";
            var adapter = new OleDbDataAdapter(query, connectionString);

            var ds = new DataSet();

            adapter.Fill(ds, file + sheet);

            return ds.Tables[file + sheet];
        }

        public DataTable GetDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)
        {
            //Create Empty Table  
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            //use a Dataset to make use of a DataRelation object  
            using (DataSet ds = new DataSet())
            {
                //Add tables  
                ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });
                //Get Columns for DataRelation  
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }
                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }
                //Create DataRelation  
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);
                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2);
                //Create columns for return table  
                for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                {
                    ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                }
                //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.  
                ResultDataTable.BeginLoadData();
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.  
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                ResultDataTable.EndLoadData();
            }
            return ResultDataTable;
        }

        private void ExportToExcel(DataTable dt, string path)
        {
            var workbook = new XLWorkbook();
            workbook.Worksheets.Add(dt);
            workbook.SaveAs(path);
        }

        //private void ExportToExcel(DataTable dt, string path)
        //{
        //    // Create the CSV file to which grid data will be exported.
        //    var sw = new StreamWriter(path, false);

        //    // First we will write the headers.
        //    var iColCount = dt.Columns.Count;
        //    for (int i = 0; i < iColCount; i++)
        //    { 
        //        sw.Write(dt.Columns[i]);
        //        if (i < iColCount - 1)
        //        {
        //            sw.Write(",");
        //        }
        //    }
        //    sw.Write(sw.NewLine);
            
        //    // Now write all the rows.
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        for (int i = 0; i < iColCount; i++)
        //        {
        //            if (!Convert.IsDBNull(dr[i]))
        //            {
        //                sw.Write(dr[i].ToString());
        //            }
        //            if (i < iColCount - 1)
        //            {
        //                sw.Write(",");
        //            }
        //        }
        //        sw.Write(sw.NewLine);
        //    }
        //    sw.Close();
        //}
    }
}