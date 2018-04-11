using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initial settings.

            // Suggested to work with simple fractions.
            SimpFCheckBox.Checked = true;
            DecFCheckBox.Checked = false;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // App stops working.
            Application.Exit();
        }

        private void SimpFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Unchecking decimal fraction check box.
            DecFCheckBox.Checked = false;

            // Dot button disabled.
            DotBut.Enabled = false;

            // Converting to simple fraction button disabled.
            ToSimpleBut.Enabled = false;
        }
    }
}
