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
    public partial class Form1 : Form {
        Double Value = 0;
        String Operation = "";
        bool OperationPressed = false;

        public Form1() {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) {
            if ((resultBox.Text == "0") || (OperationPressed)) {
                OperationPressed = false;
                resultBox.Clear();
            }

            var button = (Button)sender;
            resultBox.Text = resultBox.Text + button.Text;
        }

        private void ButtonClearEntry_Click(object sender, EventArgs e) => resultBox.Text = "0";

        private void Operator_Click(object sender, EventArgs e) {
            var button = (Button)sender;
            Operation = button.Text;
            Value = Double.Parse(resultBox.Text);
            OperationPressed = true;
            equation.Text = Value + " " + Operation;
        }

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
        }

        private void ButtonClear_Click(object sender, EventArgs e) {
            resultBox.Text = "0";
            Value = 0;
        }
    }
}
