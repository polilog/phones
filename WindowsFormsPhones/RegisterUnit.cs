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
    public partial class RegisterUnit : Form, IRegisterUnit
    {
        RegisterUnitController _controller;

        public RegisterUnit()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.RegisterUnit();
        }

        #endregion

        #region IRegisterUnit implementation

        public string name
        {
            get { return textBox1.Text; }
        }

        public void SetController(RegisterUnitController controller)
        {
            _controller = controller;
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
