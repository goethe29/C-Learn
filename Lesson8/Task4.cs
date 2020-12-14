using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Lesson8
{
    public partial class Task4 : Form
    {
        Regex regex = new Regex($"[\\w.\\s]*$");

        // База данных с вопросами
        LearnEnglish database;

        // Проверяет наличие базы
        private bool ValidateDB() 
        {
            if (database == null)
            {
                MessageBox.Show("База данных еще не создана. Создайте новую базу данных", "Сообщение");
                return false;
            }
            return true;
        }

        // Add not saved flag to the File Name in the form header
        private void CheckStatus(string status) 
        {
            if (status == "updated" && database.isSaved != false)
            {
                database.isSaved = false;
                this.Text = this.Text + $" *(not saved)";
            }
            if (status == "saved" && database.isSaved == false)
            {
                database.isSaved = true;
                this.Text = this.Text.Replace($" *(not saved)", "");
            }
        }

        /// <summary>
        /// *Используя полученные знания и класс TrueFalse в качестве шаблона, 
        ///     разработать собственную утилиту хранения данных 
        ///     (Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).
        /// </summary>
        public Task4()
        {
            InitializeComponent();
        }

        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new LearnEnglish(sfd.FileName);
                database.Add("Пример", "Example");
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                this.Text = this.Name + " - " + regex.Match(sfd.FileName);
            };
        }

        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            if (ValidateDB() == true) 
            {
                database.Save();
                CheckStatus("saved");
            }  
        }

        // Обработчик пункта меню Save As
        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database.fileName = sfd.FileName;
                database.Save();
                this.Text = this.Name + " - " + regex.Match(sfd.FileName);
            }
            CheckStatus("saved");
        }

        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new LearnEnglish(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                this.Text = this.Text + " - " + regex.Match(ofd.FileName);            
            }
        }

        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateDB() == false)
            {
                return;
            } 
            else
            {
                database.Add($"Пример {(database.Count + 1).ToString()}", "Translation");
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
                CheckStatus("updated");
            }
        }

        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveCard_Click(object sender, EventArgs e)
        {
            if (ValidateDB() == false)
            {
                return;
            }
            else
            {
                database[(int)nudNumber.Value - 1].russian = tboxRussian.Text;
                database[(int)nudNumber.Value - 1].english = tboxEnglish.Text;
                CheckStatus("updated");
            }
        }

        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateDB() == false)
            {
                return;
            }
            else
            {
                if (nudNumber.Maximum == 1 || database == null) return;
                database.Remove((int)nudNumber.Value-1);
                nudNumber.Maximum--;
                tboxRussian.Text = database[(int)nudNumber.Value - 1].russian;
                tboxEnglish.Text = database[(int)nudNumber.Value - 1].english;
                CheckStatus("updated");
            }
        }

        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (ValidateDB() == false)
            {
                return;
            }
            else
            {
                tboxRussian.Text = database[(int)nudNumber.Value - 1].russian;
                tboxEnglish.Text = database[(int)nudNumber.Value - 1].english;
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа хранит базу данных LearnEnglish карточек.\n (с) Дмитрий Юдин \n 2020 ");
        }
    }
}
