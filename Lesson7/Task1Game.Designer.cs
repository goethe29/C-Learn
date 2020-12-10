
namespace Lesson7
{
    partial class Task1Game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.commands = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.targetNumLabel = new System.Windows.Forms.Label();
            this.targetNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(228, 33);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(75, 23);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(228, 81);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(75, 23);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(228, 127);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(37, 39);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 17);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "0";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(23, 180);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Отменить";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // commands
            // 
            this.commands.AutoSize = true;
            this.commands.Location = new System.Drawing.Point(287, 180);
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(16, 17);
            this.commands.TabIndex = 5;
            this.commands.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Количество команд:";
            // 
            // targetNumLabel
            // 
            this.targetNumLabel.AutoSize = true;
            this.targetNumLabel.Location = new System.Drawing.Point(6, 13);
            this.targetNumLabel.Name = "targetNumLabel";
            this.targetNumLabel.Size = new System.Drawing.Size(201, 17);
            this.targetNumLabel.TabIndex = 7;
            this.targetNumLabel.Text = "Необходимо получить число:";
            // 
            // targetNum
            // 
            this.targetNum.AutoSize = true;
            this.targetNum.Location = new System.Drawing.Point(228, 12);
            this.targetNum.Name = "targetNum";
            this.targetNum.Size = new System.Drawing.Size(16, 17);
            this.targetNum.TabIndex = 8;
            this.targetNum.Text = "0";
            // 
            // Task1Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 241);
            this.Controls.Add(this.targetNum);
            this.Controls.Add(this.targetNumLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commands);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Name = "Task1Game";
            this.Text = "Task 1: Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1Game_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label commands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label targetNumLabel;
        private System.Windows.Forms.Label targetNum;
    }
}

