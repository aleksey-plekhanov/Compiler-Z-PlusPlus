using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Compiler_Z__.src.analyzer
{
    class SyntaxAnalyzer
    {
        private static List<string> storageVariable = new List<string>();
        private static int codeLine;

        public static bool Start(string[] codeFromFile)
        {
            ResetVariable();

            foreach (string line in codeFromFile)
            {
                codeLine++;

                if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line)) continue;
                string[] wordsInLine = line.Trim().Split(' ');
                

                if (wordsInLine.Last().Last() != ';')
                {
                    MessageBox.Show("Отсутствует закрывающая ';'\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (wordsInLine.Length < 2 || wordsInLine.Length > 3)
                {
                    MessageBox.Show("Недопустимое кол-во аргументов\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (wordsInLine.Length == 3)
                {
                    if (!AnalysisThreeArguments(wordsInLine))
                        return false;
                }
                else if (wordsInLine.Length == 2)
                {
                    if (!AnalysisTwoArguments(wordsInLine))
                        return false;
                }
            }

            return true;
        }

        private static void ResetVariable() {
            codeLine = 0;
            storageVariable.Clear();
        }

        private static bool isValidVariable(string name) {
            return Regex.IsMatch(name, "^[^0-9][A-Za-z]*$");
        }

        private static bool AnalysisTwoArguments(string[] wordsInLine)
        {
            wordsInLine[1] = wordsInLine[1].Replace(";", "");

            switch (wordsInLine.First())
            {
                case "CREATE":
                    {
                        if (storageVariable.Contains(wordsInLine[1]))
                        {
                            MessageBox.Show("Такая переменная уже существует!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (!isValidVariable(wordsInLine[1]))
                        {
                            MessageBox.Show("Неправильное именование переменной\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        storageVariable.Add(wordsInLine[1]);
                        return true;
                    }
                case "OUT":
                    {
                        if (!wordsInLine[1].All(char.IsDigit) && !storageVariable.Contains(wordsInLine[1]))
                        {
                            MessageBox.Show("Неизвестная переменная!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        return true;
                    }
                default:
                    MessageBox.Show("Неизвестная команда!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
        }

        private static bool AnalysisThreeArguments(string[] wordsInLine)
        {
            string[] commands = new string[4]
            {
                "CREATE",
                "DIV",
                "MUL",
                "ADD"
            };

            if (!commands.Contains(wordsInLine[0]))
            {
                MessageBox.Show("Неизвестная команда!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (wordsInLine[1].Last() != ',')
            {
                MessageBox.Show("Отсуствует запятая после первого параметра!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            wordsInLine[1] = wordsInLine[1].Replace(",", "");
            wordsInLine[2] = wordsInLine[2].Replace(";", "");

            if (wordsInLine.First() != commands.First())
            {
                if (wordsInLine[1].All(char.IsDigit))
                {
                    MessageBox.Show("Компилятор не поддерживание операции с первой аргументом 'число'!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                for(int i = 1; i <= 2; i++)
                {
                    if (!wordsInLine[i].All(char.IsDigit) && !storageVariable.Contains(wordsInLine[i]) && !string.IsNullOrEmpty(wordsInLine[i]) && (wordsInLine[i].All(char.IsNumber) 
                        || !(wordsInLine[i][0] == '-' && wordsInLine[i].Substring(1, wordsInLine[i].Length - 1).All(char.IsDigit))))
                    {
                        MessageBox.Show("Неизвестная переменная!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                if (storageVariable.Contains(wordsInLine[1]))
                {
                    MessageBox.Show("Такая переменная уже существует!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!isValidVariable(wordsInLine[1]))
                {
                    MessageBox.Show("Неправильное именование переменной\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!wordsInLine[2].All(char.IsDigit))
                {
                    MessageBox.Show("Второе значение должно число. Компилятор не подерживает присваивание переменных!\nСтрока: " + codeLine, "Синтаксический анализатор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                storageVariable.Add(wordsInLine[1]);
            }

            return true;
        }
    }
}
