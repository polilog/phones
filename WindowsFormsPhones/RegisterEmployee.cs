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
    public partial class RegisterEmployee : Form, IRegisterEmployee
    {
        private RegisterEmployeeController _controller;

        public RegisterEmployee()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.RegisterEmployee();
        }

        #endregion

        #region IRegisterEmployee implementation

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(RegisterEmployeeController controller)
        {
            _controller = controller;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ShowWarningMessage(string message)
        {
            DialogResult result;
            result = MessageBox.Show("Birthdate may be incorrect. Do you want to create employee?", "Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.No)
                return false;
            else
                return true;
        }

        public DateTime birthDate
        {
            get { return dateTimePicker1.Value.Date; }
        }

        public string name
        {
            get { return textBox1.Text; }
        }

        public string position
        {
            get { return textBox3.Text; }
        }

        public bool? sex
        {
            get
            {
                if (radioButton1.Checked)
                    return true;
                if (radioButton2.Checked)
                    return false;
                return null;
            }
        }

        public string surname
        {
            get { return textBox2.Text; }
        }

        #endregion
    }
}
