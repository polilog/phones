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

namespace WindowsFormsPhones
{
    public partial class ShowLists : Form, IShowLists
    {
        private ShowListsController _controller;

        public ShowLists()
        {
            InitializeComponent();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(ShowListsController controller)
        {
            _controller = controller;
        }

        public void SetupDataGridView(bool type)
        {
            if (type)
            {
                dataGridView1.ColumnCount = 7;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Surname";
                dataGridView1.Columns[2].Name = "Position";
                dataGridView1.Columns[3].Name = "Sex";
                dataGridView1.Columns[4].Name = "Birthdate";
                dataGridView1.Columns[5].Name = "Unit";
                dataGridView1.Columns[6].Name = "Phone";
            }
            else
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Phone number";
                dataGridView1.Columns[1].Name = "Unit";
                dataGridView1.Columns[2].Name = "Employee";
            }
        }


        public void ShowList(params string[] list)
        {
                dataGridView1.Rows.Add(list);
        }


        public int currentPhone
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                    return dataGridView1.CurrentRow.Index;
                else
                    return -1;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_controller.CheckPhone())
            {
                CallLog callLog = new CallLog();
                _controller.OpenCallLog(callLog);
                callLog.Show();
            }
        }
    }
}
