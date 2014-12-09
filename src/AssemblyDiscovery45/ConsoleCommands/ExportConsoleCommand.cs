using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManyConsole;

namespace AssemblyDiscovery.ConsoleCommands
{
    public class MainConsoleCommand : ConsoleCommand
    {
        public override int Run(string[] remainingArguments)
        {
            var inputAssembly = getInputAssemblyArgument(remainingArguments);

            var extraArguments = extractMyArguments(remainingArguments);

            int consoleResult;

            if ((!string.IsNullOrWhiteSpace(inputAssembly)) && (extraArguments != null) && (extraArguments.Length > 0))
            {
                var listOfCommands = GetCommands();

                consoleResult = ConsoleCommandDispatcher.DispatchCommand(listOfCommands, extraArguments, Console.Out);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormPrincipal(inputAssembly));

                consoleResult = 0;
            }

            return consoleResult;
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program)).Where(c => !(c is MainConsoleCommand));
        }

        private string[] extractMyArguments(string[] args)
        {
            var inputAssembly =  getInputAssemblyArgument(args);

            if (string.IsNullOrWhiteSpace(inputAssembly))
            {
                return args;
            }

            return args.Skip(1).ToArray();
        }

        private string getInputAssemblyArgument(string[] args)
        {
            if (args.Any() && (File.Exists(args.First())))
            {
                return args.First();
            }

            return null;
        }
    }

    public class ExportConsoleCommand : ConsoleCommand
    {
        public ExportConsoleCommand()
        {
            IsCommand("export", "Export dependencies.");

            HasAdditionalArguments(1);
        }

        public override int Run(string[] remainingArguments)
        {
            return 0;
        }
    }
}
