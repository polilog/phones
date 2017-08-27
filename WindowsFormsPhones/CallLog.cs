using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;
using Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsPhones
{
    public partial class CallLog : Form, ICallLog
    {
        private CallLogController _controller;

        public CallLog()
        {
            InitializeComponent();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(CallLogController controller)
        {
            _controller = controller;
        }


        public void ShowInfo(string phone, string unit, string employee)
        {
            label4.Text = phone;
            label5.Text = unit;
            label6.Text = employee;
        }

        public void ShowList(params string[] row)
        {
            dataGridView1.Rows.Add(row);
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            ExcelApp.Workbooks.Add(Type.Missing);

            Excel.Worksheet ExcelSheet = (Excel.Worksheet)ExcelApp.Sheets[1];

            ExcelSheet.Columns.ColumnWidth = 20;


            ExcelSheet.Cells[1, 1] = label1.Text;
            ExcelSheet.Cells[1, 2] = label4.Text;
            ExcelSheet.Cells[2, 1] = label2.Text;
            ExcelSheet.Cells[2, 2] = label5.Text;
            ExcelSheet.Cells[3, 1] = label3.Text;
            ExcelSheet.Cells[3, 2] = label6.Text;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    ExcelApp.Cells[j + 4, i + 1] = (dataGridView1[i, j].Value).ToString();
                }
            }

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx";

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                ExcelSheet.SaveAs(SaveFileDialog1.FileName);

            ExcelApp.Quit();
        }
    }
}
