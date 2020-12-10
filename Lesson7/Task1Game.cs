using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Task1Game : Form
    {
        Game newGame;
        public Task1Game()
        {
            InitializeComponent();
            newGame = new Game();
            targetNum.Text = newGame.targetNum.ToString();
        }

        /// <summary>
        /// Checks whether you reach the traget number
        /// </summary>
        private void CheckWin()
        {
            if (newGame.targetNum == newGame.steps[newGame.steps.Count - 1])
            {
                MessageBox.Show("Вы победили");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(lblNumber.Text) + 1;
            newGame.SaveStep(n);
            lblNumber.Text = n.ToString();
            CountCommands();
            CheckWin();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(lblNumber.Text) * 2;
            newGame.SaveStep(n);
            lblNumber.Text = n.ToString();
            CountCommands();
            CheckWin();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int n = 1;
            newGame.SaveStep(n);
            lblNumber.Text = "1";
            CountCommands();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CountCommands()
        {
            commands.Text = (int.Parse(commands.Text) + 2).ToString();
        }

        private void Task1Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            int n = newGame.ReturnBack();
            lblNumber.Text = n.ToString();
            CountCommands();
        }
    }
}
