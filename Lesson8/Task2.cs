using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class Task2 : Form
    {
        /// <summary>
        /// Создайте простую форму на котором свяжите свойство Text элемента TextBox 
        ///     со свойством Value элемента NumericUpDown
        /// </summary>
        public Task2()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            int.TryParse(textBox1.Text, out n);
            if (n > numericUpDown1.Maximum)
            {
                numericUpDown1.Maximum = n;
            }
            numericUpDown1.Value = n;
        }
    }
}
