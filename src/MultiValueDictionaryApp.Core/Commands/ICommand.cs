using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Interface for all command actions.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the command action type.
        /// </summary>
        Action ActionType { get; }

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        string Execute(ArgumentsModel data);
    }
}