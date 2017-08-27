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
    public partial class MainMenu : Form, IMainMenu
    {
        private MainMenuController _controller;

        public MainMenu()
        {
            InitializeComponent();
        }

        #region Events raised back to controller

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterUnit regUnit = new RegisterUnit();
            _controller.OpenRegisterUnit(regUnit);
            regUnit.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterEmployee regEmployee = new RegisterEmployee();
            _controller.OpenRegisterEmployee(regEmployee);
            regEmployee.Show();
        }

        private void numberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterNumber regNumber = new RegisterNumber();
            _controller.OpenRegisterNumber(regNumber);
            regNumber.Show();
        }

        private void numberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AssignNumber assignNumber = new AssignNumber();
            _controller.OpenAssignNumber(assignNumber);
            assignNumber.Show();
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignHead assignHead = new AssignHead();
            _controller.OpenAssignHead(assignHead);
            assignHead.Show();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLists showLists = new ShowLists();
            _controller.OpenShowLists(showLists, true);
            showLists.Show();
        }

        private void phonebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLists showLists = new ShowLists();
            _controller.OpenShowLists(showLists, false);
            showLists.Show();
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmulateCall emulateCall = new EmulateCall();
            _controller.OpenEmulateCall(emulateCall, this);
            emulateCall.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ClearLists();
            else
                _controller.AddList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ChooseUnit();
        }


        #endregion

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           if (radioButton2.Checked)
                ClearLists();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                ClearLists();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                ClearLists();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked && comboBox1.SelectedIndex != -1)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                label4.Enabled = true;
                comboBox2.Enabled = true;
                label5.Enabled = false;
                comboBox3.Enabled = false;

                foreach (Unit unit in ((Unit)comboBox1.SelectedItem).getUnitList())
                {
                    comboBox2.Items.Add(unit);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked && comboBox2.SelectedIndex != -1)
            {
                comboBox3.Items.Clear();

                label5.Enabled = true;
                comboBox3.Enabled = true;


                foreach (Unit unit in ((Unit)comboBox2.SelectedItem).getUnitList())
                {
                    comboBox3.Items.Add(unit);
                }
            }
        }

        public void ClearLists()
        {
            label4.Enabled = false;
            label5.Enabled = false;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;


            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            if (radioButton1.Checked)
            {
                label3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox1.Items.Clear();
            }
            else
            {
                label3.Enabled = true;
                comboBox1.Enabled = true;
                comboBox1.SelectedIndex = -1;
            }
        }

        #region IMainMenu implementations

        public void SetController(MainMenuController controller)
        {
            _controller = controller;
        }  

        public void ShowList(List<Unit> list)
        {
                foreach (Unit unit in list)
                {
                    comboBox1.Items.Add(unit);
                }
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
        }

        public void ShowTitle(string title)
        {
            label2.Text = title;
        }

        public Unit currentUnit
        {
            get
            {
                if (radioButton2.Checked)
                    return (Unit)comboBox1.SelectedItem;
                if (radioButton3.Checked)
                    return (Unit)comboBox2.SelectedItem;
                if (radioButton4.Checked)
                    return (Unit)comboBox3.SelectedItem;
                return null;
            }
        }

       public string type
        {
            get
            {
                if (radioButton1.Checked)
                    return "company";
                if (radioButton2.Checked)
                    return "department";
                if (radioButton3.Checked)
                    return "office";
                return "branch";
            }
        }

        #endregion

       public void ShowStatusInfo()
       {
           toolStripStatusLabel2.Text = Call.TotalNumber.ToString();
           toolStripStatusLabel4.Text = Call.TotalAmount.ToString();
       }


       public void ForbidCreate()
       {
           unitToolStripMenuItem.Enabled = false; ;
       }
    }
}
