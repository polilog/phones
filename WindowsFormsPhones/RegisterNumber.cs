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
    public partial class RegisterNumber : Form, IRegisterNumber
    {
        private RegisterNumberController _controller;

        public RegisterNumber()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.RegisterNumber();
        }

        #endregion

        #region IRegisterNumber implementation

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(RegisterNumberController controller)
        {
            _controller = controller;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string number
        {
            get { return textBox2.Text; }
        }

        #endregion
    }
}
