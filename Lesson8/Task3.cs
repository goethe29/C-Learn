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
    /*
     а) Создать приложение, показанное на уроке, 
        добавив в него защиту от возможных ошибок 
        (не создана база данных, 
        обращение к несуществующему вопросу, 
        открытие слишком большого файла и т.д.).
    б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов
        и добавив другие «косметические» улучшения на свое усмотрение.
    в) Добавить в приложение меню «О программе» с информацией о программе 
        (автор, версия, авторские права и др.).
    г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных 
    (элемент SaveFileDialog).
     */
    public partial class Task3 : Form
    {
        Regex regex = new Regex($"[\\w.\\s]*$");

        // База данных с вопросами
        TrueFalse database;

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

        public Task3()
        {
            InitializeComponent();
        }

        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
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
                database = new TrueFalse(ofd.FileName);
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
                database.Add((database.Count + 1).ToString(), true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
                CheckStatus("updated");
            }
        }

        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (ValidateDB() == false)
            {
                return;
            }
            else
            {
                database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
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
                /* Пофикшено удаление вопросов. В методичке код кривой был, удалял следующий вопрос, вместе текущего.
                А при создании нового, создавал сразу два.*/
                database.Remove((int)nudNumber.Value-1);
                nudNumber.Maximum--;
                /*Фиксит отображение нового текста первого вопроса (т.е. второго перед этим), при удалении первого вопроса
                Методичка содержала код с багом.*/
                if (nudNumber.Value == 1)
                {
                    tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                }
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
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа хранит базу данных TrueFalse вопросов.\n (с) Дмитрий Юдин \n 2020 ");
        }
    }
}
