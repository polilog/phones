using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace WindowsFormsPhones
{
    public partial class EmulateCall : Form, IEmulateCall
    {
        private EmulateCallController _controller;

        public EmulateCall()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.EmulateCall();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void SetController(EmulateCallController controller)
        {
            _controller = controller;
        }


        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string num
        {
            get { return textBox1.Text; }
        }
    }
}
