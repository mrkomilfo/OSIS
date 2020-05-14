namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.goButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(837, 23);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(86, 24);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Перейти";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(21, 24);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(810, 22);
            this.pathBox.TabIndex = 1;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(21, 92);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(377, 340);
            this.listBox.TabIndex = 2;
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(21, 52);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(63, 34);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(90, 52);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(76, 34);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(172, 52);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(88, 34);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(266, 52);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(132, 34);
            this.renameButton.TabIndex = 6;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(404, 52);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(110, 34);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "Скопировать";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(520, 52);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(118, 34);
            this.moveButton.TabIndex = 8;
            this.moveButton.Text = "Переместить";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(644, 52);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 34);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(741, 52);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(90, 35);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(837, 53);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(86, 34);
            this.infoButton.TabIndex = 11;
            this.infoButton.Text = "Инфо";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(404, 92);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(519, 340);
            this.textBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.goButton);
            this.Name = "Form1";
            this.Text = "Repo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.TextBox textBox;
    }
}

