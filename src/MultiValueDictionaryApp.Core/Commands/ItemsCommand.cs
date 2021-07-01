using System.Text;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for fetching all items in dictionary.
    /// </summary>
    public class ItemsCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Items;

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

            // Loop through all members and return
            foreach (var keyMemberPair in GeneratedData.KeyMemberCollection)
            {
                foreach (var member in keyMemberPair.Value)
                {
                    sb.AppendLine(DisplayFormatting.Indent(2) + string.Format("{0}) {1}: {2}", count, keyMemberPair.Key, member));
                    count++;
                }
            }

            return sb.ToString();
        }
    }
}