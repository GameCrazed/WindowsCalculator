using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator {
    public partial class WindowsCalculator : Form {
        Double Value = 0;
        String Operation = "";
        bool OperationPressed = false;

        /// <summary>
        /// Initialise the calculator.
        /// </summary>
        public WindowsCalculator() {
            InitializeComponent();
        }

        /// <summary>
        /// Append the appropriate value to the string when a button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e) {
            if ((resultBox.Text == "0") || (OperationPressed)) {
                OperationPressed = false;
                resultBox.Clear();
            }

            var button = (Button)sender;
            if (button.Text == ".") {
                if (!resultBox.Text.Contains("."))
                    resultBox.Text = resultBox.Text + button.Text;
            } else {
                resultBox.Text = resultBox.Text + button.Text;
            }
        }

        /// <summary>
        /// Clear the results box when the user begins inputting values and keeps a live display of information inputted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operator_Click(object sender, EventArgs e) {
            var button = (Button)sender;

            if (Value != 0) {
                buttonEquals.PerformClick();
                resultBox.Text = "0";
            } else {
                Value = Double.Parse(resultBox.Text);
            }

            Operation = button.Text;
            OperationPressed = true;
            equation.Text = Value + " " + Operation;
        }

        /// <summary>
        /// Calculations performed when the equals button is clicked or when an operator is clicked that requires operating
        /// on two numbers before continuing, e.g. X + Y + Z would result in X + Y being executed when the + is clicked before
        /// Z is inputted by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEquals_Click(object sender, EventArgs e) {
            equation.Text = "";
            OperationPressed = false;
            switch (Operation) {
                case "+":
                    resultBox.Text = (Value + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (Value - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "*":
                    resultBox.Text = (Value * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "/":
                    resultBox.Text = (Value / Double.Parse(resultBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            Value = Int32.Parse(resultBox.Text);
            Operation = "";
        }

        /// <summary>
        /// Clear the information from the text box only, NOT the equation box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearEntry_Click(object sender, EventArgs e) => resultBox.Text = "0";

        /// <summary>
        /// Clear all information from the calculator in preperation for a new calculation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e) {
            resultBox.Text = "0";
            equation.Text = "";
            Value = 0;
        }

        /// <summary>
        /// Allows key-presses to correspond to calculator inputs by executing the corresponding click functions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar.ToString()) {
                case "0":
                    button0.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case "+":
                    buttonAdd.PerformClick();
                    break;
                case "-":
                    buttonSubtract.PerformClick();
                    break;
                case "*":
                    buttonMultiply.PerformClick();
                    break;
                case "/":
                    buttonDivide.PerformClick();
                    break;
                case "=":
                    buttonEquals.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}
