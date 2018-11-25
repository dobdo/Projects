namespace ParsingVKChatV4.Forms
{
    partial class MainMenu
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
            this.ChatIDField = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DrawGraphButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AuthButton = new System.Windows.Forms.Button();
            this.AllTimeGraphButton = new System.Windows.Forms.Button();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChooseNewChatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatIDField
            // 
            this.ChatIDField.Location = new System.Drawing.Point(121, 68);
            this.ChatIDField.Name = "ChatIDField";
            this.ChatIDField.Size = new System.Drawing.Size(27, 20);
            this.ChatIDField.TabIndex = 0;
            this.ChatIDField.Visible = false;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(154, 68);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(116, 23);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Выгрузить";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Visible = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DrawGraphButton
            // 
            this.DrawGraphButton.Location = new System.Drawing.Point(154, 98);
            this.DrawGraphButton.Name = "DrawGraphButton";
            this.DrawGraphButton.Size = new System.Drawing.Size(116, 23);
            this.DrawGraphButton.TabIndex = 2;
            this.DrawGraphButton.Text = "Построить график";
            this.DrawGraphButton.UseVisualStyleBackColor = true;
            this.DrawGraphButton.Visible = false;
            this.DrawGraphButton.Click += new System.EventHandler(this.DrawGraphButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(13, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(102, 23);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Основное меню";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AuthButton
            // 
            this.AuthButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AuthButton.ForeColor = System.Drawing.Color.White;
            this.AuthButton.Location = new System.Drawing.Point(121, 13);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(189, 49);
            this.AuthButton.TabIndex = 4;
            this.AuthButton.Text = "Авторизация";
            this.AuthButton.UseVisualStyleBackColor = false;
            this.AuthButton.Visible = false;
            this.AuthButton.Click += new System.EventHandler(this.AuthButton_Click);
            // 
            // AllTimeGraphButton
            // 
            this.AllTimeGraphButton.Location = new System.Drawing.Point(154, 69);
            this.AllTimeGraphButton.Name = "AllTimeGraphButton";
            this.AllTimeGraphButton.Size = new System.Drawing.Size(116, 23);
            this.AllTimeGraphButton.TabIndex = 5;
            this.AllTimeGraphButton.Text = "Общий график";
            this.AllTimeGraphButton.UseVisualStyleBackColor = true;
            this.AllTimeGraphButton.Visible = false;
            this.AllTimeGraphButton.Click += new System.EventHandler(this.AllTimeGraphButton_Click);
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Location = new System.Drawing.Point(13, 305);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(427, 23);
            this.DownloadProgress.TabIndex = 11;
            this.DownloadProgress.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Сообщения выгружены";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ID Чата вконтакте";
            // 
            // ChooseNewChatButton
            // 
            this.ChooseNewChatButton.Location = new System.Drawing.Point(316, 11);
            this.ChooseNewChatButton.Name = "ChooseNewChatButton";
            this.ChooseNewChatButton.Size = new System.Drawing.Size(125, 27);
            this.ChooseNewChatButton.TabIndex = 14;
            this.ChooseNewChatButton.Text = "Выбрать другой чат";
            this.ChooseNewChatButton.UseVisualStyleBackColor = true;
            this.ChooseNewChatButton.Visible = false;
            this.ChooseNewChatButton.Click += new System.EventHandler(this.ChooseNewChatButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 377);
            this.Controls.Add(this.ChooseNewChatButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.AllTimeGraphButton);
            this.Controls.Add(this.AuthButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DrawGraphButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ChatIDField);
            this.Name = "MainMenu";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatIDField;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button DrawGraphButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AuthButton;
        private System.Windows.Forms.Button AllTimeGraphButton;
        private System.Windows.Forms.ProgressBar DownloadProgress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChooseNewChatButton;
    }
}

