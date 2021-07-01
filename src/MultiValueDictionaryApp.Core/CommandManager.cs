using System;
using System.Collections.Generic;
using System.Linq;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core
{
    /// <summary>
    /// Manager class for handling all commands.
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// Gets collection of commands.
        /// </summary>
        private readonly IEnumerable<ICommand> _commands;

        public CommandManager(IEnumerable<ICommand> commands)
        {
            this._commands = commands;
        }

        /// <summary>
        /// Method to execute command
        /// </summary>
        /// <param name="commandText">Command type</param>
        /// <param name="model">Argument model with key and member.</param>
        /// <returns>A string.</returns>
        public string Execute(string commandText, ArgumentsModel model)
        {
            // Validate that command text is not null or empty
            if (string.IsNullOrWhiteSpace(commandText)) { throw new ArgumentNullException(nameof(commandText)); }

            // Get the command
            ICommand _command = this._commands.FirstOrDefault(x => x.ActionType.ToString().ToLower() == commandText.Trim().ToLower());

            // if command is null then return unsupported command message else execute the command and return result.
            return _command != null ? _command.Execute(model) : "Command not supported. Usage: Command Key Member";
        }
    }
}