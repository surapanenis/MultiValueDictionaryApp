using System.Text;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for fetching all members for all keys in dictionary.
    /// </summary>
    public class AllMembersCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.AllMembers;

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

            // Loop through Values property to get all members
            foreach (var members in GeneratedData.KeyMemberCollection.Values)
            {
                foreach (var member in members)
                {
                    sb.AppendLine(DisplayFormatting.Indent(2) + string.Format("{0}) {1}", count, member));
                    count++;
                }
            }

            return sb.ToString();
        }
    }
}