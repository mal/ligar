using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ligar
{

    static class WinApi
    {
        [DllImport("kernel32.dll", EntryPoint = "GetCommandLineA")]
        public static extern string GetCommandLineA();
    }

    public static class Ligar
    {
        const string DELIMITER = "---";
        const string QUOTE = "\"";

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 2) return;

            string argument = WinApi.GetCommandLineA();
            string handler = args[0];
            string original = args[1];

            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg.Contains(' '))
                    args[i] = QUOTE + arg + QUOTE;

                if (arg == DELIMITER)
                {
                    original = args[i + 1];
                    args = args.Skip(1).Take(i - 1).ToArray();
                }
            }

            original = DELIMITER + ' ' + QUOTE + original + QUOTE;
            argument = argument.Substring(argument.IndexOf(original) + original.Length).TrimStart();

            if (argument.Length > 0)
                argument = ' ' + QUOTE + argument + QUOTE;

            string arguments = String.Join(" ", args) + argument;

            #if DEBUG
                MessageBox.Show(arguments);
            #else
                Process.Start(handler, arguments);
            #endif
        }
    }
}
