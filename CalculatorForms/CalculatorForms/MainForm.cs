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
            if (SimpFCheckBox.Checked)
            {
                // Unchecking decimal fraction check box.
                DecFCheckBox.Checked = false;

                // Dot button disabled.
                DotBut.Enabled = false;

                // Converting to simple fraction button disabled.
                ToSimpleBut.Enabled = false;
                ToDecBut.Enabled = true;
            }
        }

        private void DecFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DecFCheckBox.Checked)
            {
                // Unchecking simple fraction check box.
                SimpFCheckBox.Checked = false;

                // Dot button enabled.
                DotBut.Enabled = true;

                // Converting to decimal fraction button disabled.
                ToDecBut.Enabled = false;
                ToSimpleBut.Enabled = true;
            }
        }

        private void MainTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only digits.
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Backspace.
            if(e.KeyChar == (char)Keys.Back && MainTextBox.Text != "" && MainTextBox.SelectionStart != 0)
            {
                // Creating stringbuilder to use "remove".
                StringBuilder buffer = new StringBuilder(MainTextBox.Text);

                // Storing current selection start.
                int currSecStart = MainTextBox.SelectionStart;

                // Removing a symbol.
                buffer.Remove(currSecStart - 1, 1);

                // Writing the new string.
                MainTextBox.Text = buffer.ToString();

                // Setting new selection start.
                MainTextBox.SelectionStart = currSecStart - 1;
            }

            // ENTER to start calculating.
            if(e.KeyChar == (char)Keys.Enter)
            {
                // function to check string (like if there isn't a second bracket etc.)

                // function to calculate
            }
        }

        private void PlusBut_Click(object sender, EventArgs e)
        {
            // Adding the plus.
            MainTextBox.Text += "+";
        }

        private void MinusBut_Click(object sender, EventArgs e)
        {
            // Adding the minus.
            MainTextBox.Text += "-";
        }

        private void MultBut_Click(object sender, EventArgs e)
        {
            // Adding the multiplication sign.
            MainTextBox.Text += "*";
        }

        private void DivBut_Click(object sender, EventArgs e)
        {
            // Adding the division sign.
            MainTextBox.Text += "/";
        }

        private void Brac1But_Click(object sender, EventArgs e)
        {
            // Adding both brackets.
            MainTextBox.Text += "(";
            MainTextBox.Text += ")";
        }

        private void Bruc2But_Click(object sender, EventArgs e)
        {
            // Adding the closing bracket.
            MainTextBox.Text += ")";
        }

        private void DotBut_Click(object sender, EventArgs e)
        {
            // Adding the dot for decimal fractions.
            MainTextBox.Text += ".";
        }
    }
}
