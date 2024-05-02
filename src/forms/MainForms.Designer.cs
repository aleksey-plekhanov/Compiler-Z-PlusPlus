namespace Compiler_Z__.src.forms
{
    partial class MainForms
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
            this.label1 = new System.Windows.Forms.Label();
            this.pathFile_textBox = new System.Windows.Forms.TextBox();
            this.pathFile_btn = new System.Windows.Forms.Button();
            this.buildFile_btn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к файлу:";
            // 
            // pathFile_textBox
            // 
            this.pathFile_textBox.Location = new System.Drawing.Point(129, 17);
            this.pathFile_textBox.Name = "pathFile_textBox";
            this.pathFile_textBox.ReadOnly = true;
            this.pathFile_textBox.Size = new System.Drawing.Size(423, 22);
            this.pathFile_textBox.TabIndex = 1;
            // 
            // pathFile_btn
            // 
            this.pathFile_btn.Location = new System.Drawing.Point(570, 17);
            this.pathFile_btn.Name = "pathFile_btn";
            this.pathFile_btn.Size = new System.Drawing.Size(100, 25);
            this.pathFile_btn.TabIndex = 4;
            this.pathFile_btn.Text = "Указать";
            this.pathFile_btn.UseVisualStyleBackColor = true;
            this.pathFile_btn.Click += new System.EventHandler(this.pathFile_btn_Click);
            // 
            // buildFile_btn
            // 
            this.buildFile_btn.Location = new System.Drawing.Point(12, 420);
            this.buildFile_btn.Name = "buildFile_btn";
            this.buildFile_btn.Size = new System.Drawing.Size(270, 25);
            this.buildFile_btn.TabIndex = 5;
            this.buildFile_btn.Text = "Скомпилировать файл";
            this.buildFile_btn.UseVisualStyleBackColor = true;
            this.buildFile_btn.Click += new System.EventHandler(this.buildFile_btn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(400, 420);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(270, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "Запустить полученную программу ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.execultiveFile_btn_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(10, 85);
            this.textFile.Name = "textFile";
            this.textFile.ReadOnly = true;
            this.textFile.Size = new System.Drawing.Size(660, 320);
            this.textFile.TabIndex = 7;
            this.textFile.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Содержимое исходника";
            // 
            // MainForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 458);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buildFile_btn);
            this.Controls.Add(this.pathFile_btn);
            this.Controls.Add(this.pathFile_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForms";
            this.Text = "Компилятор Z++ (by alexgger)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForms_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathFile_textBox;
        private System.Windows.Forms.Button pathFile_btn;
        private System.Windows.Forms.Button buildFile_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox textFile;
        private System.Windows.Forms.Label label3;
    }
}