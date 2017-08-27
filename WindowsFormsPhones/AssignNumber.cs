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
    public partial class AssignNumber : Form, IAssignNumber
    {
        private AssignNumberController _controller;

        public AssignNumber()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.AssignNumber();
        }

        #endregion

        #region IAssignNumber implementation

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(AssignNumberController controller)
        {
            _controller = controller;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowEmployeeList(List<Employee> employeeList)
        {
            foreach (Employee employee in employeeList)
            {
                comboBox1.Items.Add(employee);
            }
        }

        public void ShowNumberList(List<Phone> phoneList)
        {
            foreach (Phone phone in phoneList)
            {
                comboBox2.Items.Add(phone);
            }
        }

        public Employee employee
        {
            get { return (Employee)comboBox1.SelectedItem; }
        }

        public Phone phone
        {
            get { return (Phone)comboBox2.SelectedItem; }
        }

        #endregion
    }
}
