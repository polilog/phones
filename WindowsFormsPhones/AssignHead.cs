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
    public partial class AssignHead : Form, IAssignHead
    {
        private AssignHeadController _controller;

        public AssignHead()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.AssignHead();
        }

        #endregion

        #region IAssignHead implementation

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(AssignHeadController controller)
        {
            _controller = controller;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowList(List<Employee> employeeList)
        {
            foreach (Employee employee in employeeList)
            {
                comboBox1.Items.Add(employee);
            }
        }

        public Employee employee
        {
            get { return (Employee)comboBox1.SelectedItem; }
        }

        #endregion
    }
}
