﻿using System;
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
            // If it's not the 1st symbol in the string and the previous symbol is a digit or a bracket.
            if (MainTextBox.Text != "" && (Char.IsDigit(MainTextBox.Text[MainTextBox.Text.Length - 1]) ||
                MainTextBox.Text[MainTextBox.Text.Length - 1] == ')'))
                // Adding the minus.
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
            // Adding the 1st bracket.
            MainTextBox.Text += "(";
            Brac1Count++;

            // Enabling the 2nd bracket button and color it.
            Brac2But.Enabled = true;
            Brac2But.BackColor = Color.Pink;
        }

        private void Bruc2But_Click(object sender, EventArgs e)
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

        private void DotBut_Click(object sender, EventArgs e)
        {
            // Adding the dot for decimal fractions.
            MainTextBox.Text += ".";
        }
    }
}
