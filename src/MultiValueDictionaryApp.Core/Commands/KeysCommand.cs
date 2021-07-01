using System.Text;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for fetching all keys in dictionary.
    /// </summary>
    public class KeysCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Keys;

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        public string Execute(ArgumentsModel data)
        {
            // if dictionary is empty return empty string
            if (GeneratedData.KeyMemberCollection.Count == 0) { return "(empty set)"; }

            var sb = new StringBuilder();
            int count = 1;

            // Loop through Keys property to get all keys
            foreach (var key in GeneratedData.KeyMemberCollection.Keys)
            {
                sb.AppendLine(string.Format(DisplayFormatting.Indent(2) + "{0}) {1}", count, key));
                count++;
            }

            return sb.ToString();
        }
    }
}