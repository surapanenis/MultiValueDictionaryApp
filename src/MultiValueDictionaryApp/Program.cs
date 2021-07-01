using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Core;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp
{
    internal class Program
    {
        private static CommandManager _commandManager;

        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter a command.");

            // Create list of commands available at the startup
            List<ICommand> _commands = new List<ICommand>()
            {
                new AddCommand(),
                new KeysCommand(),
                new MembersCommand(),
                new ClearCommand(),
                new RemoveCommand(),
                new RemoveAllCommand(),
                new KeyExistsCommand(),
                new MemberExistsCommand(),
                new AllMembersCommand(),
                new ItemsCommand(),
            };

            // create manager object
            _commandManager = new CommandManager(_commands);

            // Call process commands
            ProcessCommands();
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                // get input:
                Console.Write("> ");

                // Read the command
                string _command = Console.ReadLine();

                // if command is null or empty do nothing
                if (string.IsNullOrWhiteSpace(_command)) continue;

                // if command is quit just eexit thee app
                if (_command.Trim().ToLower() == "quit") { return; }

                // Split command by space and ignore any empty entries
                string[] _commandArgs = _command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ArgumentsModel _model = new ArgumentsModel();

                // add key and member to model based on the command arguments length
                if (_commandArgs.Length > 1)
                {
                    _model.Key = _commandArgs[1];
                }

                if (_commandArgs.Length > 2)
                {
                    _model.Member = _commandArgs[2];
                }

                try
                {
                    // Execute commands
                    string _result = _commandManager.Execute(_commandArgs[0], _model);

                    // Write the result to console.
                    Console.WriteLine(_result);
                }
                catch (Exception ex)
                {
                    // Something went wrong - Write out the error message
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}