using Compiler_Z__.Properties;
using Compiler_Z__.src.analyzer;
using Compiler_Z__.translator;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Compiler_Z__.src.compiler
{
    class CompilerProgram
    {
        public static readonly string pathExeFile = @".//build//Program.exe";

        private static readonly string pathBuild = @".//build//Program.cs";
        private static readonly string pathFolder = @".//build//";

        public static void Start()
        {
            try
            {
                string[] codes = File.ReadAllLines(Settings.Default.pathFile);

                if (codes.Length == 0)
                {
                    MessageBox.Show("Файл с кодом пуст!", "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SyntaxAnalyzer.Start(codes))
                {
                    MessageBox.Show("Исправьте ошибки в синтаксе\nФайл не будет скомпилирован!", "Компилятор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CreateEmptyFile();
                WritingCodeFile(codes);
                BuildFileCS();

                MessageBox.Show("Файл скомпилировался!", "Компилятор");
            }
            catch (Exception e)
            {
                MessageBox.Show("Во время компиляции произошла ошибка!\n" + e.Message, "Компилятор", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateEmptyFile()
        {
            if (!Directory.Exists(pathFolder)) {
                Directory.CreateDirectory(pathFolder);
            }

            File.WriteAllText(pathBuild, String.Empty);
        }

        private static string GenerationCode(string[] Zcodes)
        {
            string firstPart = "namespace Program\r\n{\r\n    class Hello {         \r\n        static void Main(string[] args)\r\n        {\n";
            string secondPart = ZPlusToCSharp.Convert(Zcodes);
            string thirdPart = "\t\t\t        }\r\n    }\r\n}\n";

            return firstPart + secondPart + thirdPart;
        }

        private static void WritingCodeFile(string[] Zcodes)
        {
            File.WriteAllText(pathBuild, GenerationCode(Zcodes));
        }

        private static void BuildFileCS()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine("cd build");
            process.StandardInput.WriteLine("C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe Program.cs");
            process.StandardInput.WriteLine("exit");

            process.WaitForExit();
            process.Close();
        }
    }
}
