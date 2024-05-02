using Compiler_Z__.Properties;
using Compiler_Z__.src.compiler;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Compiler_Z__.src.forms
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();

            pathFile_textBox.Text = Settings.Default.pathFile;

            if(File.Exists(pathFile_textBox.Text)) {
                textFile.Text = File.ReadAllText(Settings.Default.pathFile);
            }
        }

        private void pathFile_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Title = "Выберите файл";
                dialog.InitialDirectory = Settings.Default.pathFile;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.pathFile = dialog.FileName;
                    pathFile_textBox.Text = Settings.Default.pathFile;

                    textFile.Text = File.ReadAllText(Settings.Default.pathFile);
                    MessageBox.Show($"Вы выбрали файл: {Settings.Default.pathFile}", "Выбор файла");
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MainForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void buildFile_btn_Click(object sender, EventArgs e)
        {
            CompilerProgram.Start();
        }

        private void execultiveFile_btn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(CompilerProgram.pathExeFile)) {
                MessageBox.Show("Скомпилированная программа не найдена", "Ошибка | Поиск скомпилированной программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine("cd build");
            process.StandardInput.WriteLine("Program.exe");
            //process.StandardInput.WriteLine("exit");

            process.WaitForExit();
            process.Close();
        }
    }
}
