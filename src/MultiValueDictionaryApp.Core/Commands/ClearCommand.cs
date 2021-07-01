using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for clearing all items in dictionary.
    /// </summary>
    public class ClearCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Clear;

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        public string Execute(ArgumentsModel data)
        {
            // Validate key. if dictionary is empty return empty string
            if (GeneratedData.KeyMemberCollection.Count == 0) { return "(empty set)"; }

            // Clear the dictionary
            GeneratedData.KeyMemberCollection.Clear();

            return DisplayFormatting.Indent(2) + "Cleared";
        }
    }
}