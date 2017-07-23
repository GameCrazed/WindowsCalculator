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
        public Form1() {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) {

            if (resultBox.Text == "0")
                resultBox.Clear();

            var button = (Button)sender;
            resultBox.Text = resultBox.Text + button.Text;
        }

        private void buttonClearEntry_Click(object sender, EventArgs e) => resultBox.Text = "0";
    }
}
