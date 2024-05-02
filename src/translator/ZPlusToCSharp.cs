namespace Compiler_Z__.translator
{
    class ZPlusToCSharp
    {
        public static string Convert(string[] codes)
        {
            string resultCodes = "";

            foreach (string line in codes)
            {
                if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line)) continue;

                string[] wordsInLine = line.Trim().Replace(",", "").Replace(";", "").Split(' ');

                if(wordsInLine.Length == 3) {
                    resultCodes += GenerationCodeCMD(wordsInLine[0], wordsInLine[1], wordsInLine[2]) + "\n";
                }
                else if(wordsInLine.Length == 2) {
                    resultCodes += GenerationCodeCMD(wordsInLine[0], wordsInLine[1]) + "\n";
                }
            }

            return resultCodes;
        }

        private static string GenerationCodeCMD(string command, string arg1, string arg2 = "")  {
            switch(command)
            {
                case "CREATE":
                    return $"\t\t\tdouble {arg1} = {arg2};";
                case "ADD":
                    return $"\t\t\t{arg1} = {arg1} + {arg2};";
                case "MUL":
                    return $"\t\t\t{arg1} = {arg1} * {arg2};";
                case "DIV":
                    return $"\t\t\t{arg1} = {arg1} / {arg2};";
                default:
                    return "\n";
            }
        }

        private static string GenerationCodeCMD(string command, string arg)
        {
            switch (command)
            {
                case "CREATE":
                    return $"\t\t\tdouble {arg} = 0;";
                case "OUT":
                    return $"\t\t\tSystem.Console.WriteLine({arg});";
                default:
                    return "\n";
            }
        }
    }
}
