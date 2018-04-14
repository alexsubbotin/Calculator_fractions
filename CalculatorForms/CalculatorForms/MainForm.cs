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

            // Initially blocking the 2nd bracket button.
            Brac2But.Enabled = false;

            // Blocking both converters.
            ToDecBut.Enabled = false;
            ToSimpleBut.Enabled = false;
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

                // Text box clear.
                MainTextBox.Text = "";

                // Block converters.
                ToSimpleBut.Enabled = false;
                ToDecBut.Enabled = false;

                // Brackets initial settings.
                Brac1Count = 0;
                Brac2Count = 0;
                Brac2But.Enabled = false;
                Brac2But.BackColor = Color.PaleTurquoise;
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

                // Text box clear.
                MainTextBox.Text = "";

                // Block converters.
                ToSimpleBut.Enabled = false;
                ToDecBut.Enabled = false;

                // Brackets initial settings.
                Brac1Count = 0;
                Brac2Count = 0;
                Brac2But.Enabled = false;
                Brac2But.BackColor = Color.PaleTurquoise;
            }
        }

        private void PlusBut_Click(object sender, EventArgs e)
        {
            // If it's not the 1st symbol in the string and the previous symbol is a digit or a bracket.
            if (MainTextBox.Text != "" && (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) ||
                MainTextBox.Text[MainTextBox.Text.Length - 1] == ')'))
                // Adding the plus.
                MainTextBox.Text += "+";
        }

        private void MinusBut_Click(object sender, EventArgs e)
        {
            // If it's the previous is not + - * /.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != '-' &&
                MainTextBox.Text[MainTextBox.Text.Length - 1] != '+' && MainTextBox.Text[MainTextBox.Text.Length - 1] != '*' &&
                MainTextBox.Text[MainTextBox.Text.Length - 1] != '/')
                // Adding the minus.
                MainTextBox.Text += "-";

            // If the first.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "-";
        }

        private void MultBut_Click(object sender, EventArgs e)
        {
            // If it's not the 1st symbol in the string and the previous symbol is a digit or a bracket.
            if (MainTextBox.Text != "" && (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) ||
                MainTextBox.Text[MainTextBox.Text.Length - 1] == ')'))
                // Adding the multiplication sign.
                MainTextBox.Text += "*";
        }

        private void DivBut_Click(object sender, EventArgs e)
        {
            // If it's not the 1st symbol in the string and the previous symbol is a digit or a bracket.
            if (MainTextBox.Text != "" && (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) ||
                MainTextBox.Text[MainTextBox.Text.Length - 1] == ')'))
                // Adding the division sign.
                MainTextBox.Text += "/";
        }

        // The number of the opening brackets.
        public int Brac1Count = 0;
        // The number of the closing brackets.
        public int Brac2Count = 0;

        private void Brac1But_Click(object sender, EventArgs e)
        {
            if (MainTextBox.Text != "")
            {
                // If the previous is not a digit, a dot, a bracket.
                if (!Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) &&
                    MainTextBox.Text[MainTextBox.Text.Length - 1] != '.' && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                {
                    // Adding the 1st bracket.
                    MainTextBox.Text += "(";
                    Brac1Count++;

                    // Enabling the 2nd bracket button and color it.
                    Brac2But.Enabled = true;
                    Brac2But.BackColor = Color.Pink;
                }
            }
            else
            {
                // Adding the 1st bracket.
                MainTextBox.Text += "(";
                Brac1Count++;

                // Enabling the 2nd bracket button and color it.
                Brac2But.Enabled = true;
                Brac2But.BackColor = Color.Pink;
            }
        }

        private void Bruc2But_Click(object sender, EventArgs e)
        {
            // If previous is a digit or an another closing bracket.
            if (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) ||
                MainTextBox.Text[MainTextBox.Text.Length - 1] == ')')
            {
                // If there are not enough closing brackets.
                if (Brac2Count != Brac1Count)
                {
                    // Adding the closing bracket.
                    MainTextBox.Text += ")";
                    Brac2Count++;

                    // If all the brackets are closed now.
                    if (Brac2Count == Brac1Count)
                    {
                        // Coloring back.
                        Brac2But.BackColor = Color.PaleTurquoise;
                        // Disabling.
                        Brac2But.Enabled = false;
                    }
                }
            }
        }

        private void DotBut_Click(object sender, EventArgs e)
        {
            // If it's not the 1st symbol in the string and the previous symbol is a digit.
            if (MainTextBox.Text != "" && (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1])))
                // Adding the dot.
                MainTextBox.Text += ",";
        }

        private void But1_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "1";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "1";
        }

        private void But2_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "2";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "2";
        }

        private void But3_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "3";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "3";
        }

        private void But4_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "4";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "4";
        }

        private void But5_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "5";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "5";
        }

        private void But6_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "6";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "6";
        }

        private void but7_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "7";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "7";
        }

        private void But8_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "8";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "8";
        }

        private void But9_Click(object sender, EventArgs e)
        {
            // If previous is not a closing bracket.
            if (MainTextBox.Text != "" && MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                MainTextBox.Text += "9";

            // If it's empty.
            if (MainTextBox.Text == "")
                MainTextBox.Text += "9";
        }

        private void But10_Click(object sender, EventArgs e)
        {
            MainTextBox.Text += "0";
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            // If it's not empty then delete one last symbol.
            if (MainTextBox.Text != "")
            {
                // If the last symbol is the opening bracket.
                if (MainTextBox.Text[MainTextBox.Text.Length - 1] == '(')
                {
                    Brac1Count--;

                    if (Brac1Count == 0)
                    {
                        Brac2But.Enabled = false;
                        Brac2But.BackColor = Color.PaleTurquoise;
                    }
                }

                // If the last symbol is the closing bracket.
                if (MainTextBox.Text[MainTextBox.Text.Length - 1] == ')')
                {
                    Brac2Count--;
                    Brac2But.BackColor = Color.Pink;
                }

                // Deleting the last symbol.
                MainTextBox.Text = MainTextBox.Text.Substring(0, MainTextBox.Text.Length - 1);

                // If it has become empty then block converters.
                if (MainTextBox.Text == "")
                {
                    ToSimpleBut.Enabled = false;
                    ToDecBut.Enabled = false;
                }
            }
        }

        private void ClearBut_Click(object sender, EventArgs e)
        {
            // Clear all.
            MainTextBox.Text = "";

            // Blocking converters.
            ToSimpleBut.Enabled = false;
            ToDecBut.Enabled = false;
        }

        private void ResultBut_Click(object sender, EventArgs e)
        {
            // Indiciates whether the string has the right format or not.
            bool format = true;

            // If it's empty.
            if (format)
            {
                if (MainTextBox.Text == "")
                {
                    format = false;
                    MessageBox.Show("The string is empty!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If there are unclosed brackets.
            if (format)
            {
                if (Brac1Count != Brac2Count)
                {
                    format = false;
                    MessageBox.Show("There are unclosed brackets!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If the last symbol is not a digit or the closing bracket.
            if (format)
            {
                if (!Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) &&
                    MainTextBox.Text[MainTextBox.Text.Length - 1] != ')')
                {
                    format = false;
                    MessageBox.Show("The last symbol should be a digit or the closing bracket!", "Input error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If the input string has a right format
            if (format)
            {
                // Calculations.

                // Enabling converters.
                if (SimpFCheckBox.Checked)
                    ToDecBut.Enabled = true;
                else
                    ToSimpleBut.Enabled = true;

                // If it's the decimal calculations.
                string result = "";
                if (DecFCheckBox.Checked)
                    result = ControllerDecimal.DecFracCalcAll(MainTextBox.Text);
                else
                    result = ControllerSimple.SimpFracCalcAll(MainTextBox.Text);

                PreviousStrLabel.Text = MainTextBox.Text + "=" + result;
                MainTextBox.Text = result;

            }
        }
    }
}
