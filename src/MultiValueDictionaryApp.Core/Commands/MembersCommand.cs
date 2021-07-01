using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for fetching all members for a key in dictionary.
    /// </summary>
    public class MembersCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Members;

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        public string Execute(ArgumentsModel data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }

            // Validate key and member values.
            if (string.IsNullOrWhiteSpace(data.Key)) { throw new ArgumentException("Key is required"); }

            // if dictionary is empty return empty string
            if (GeneratedData.KeyMemberCollection.Count == 0) { return "(empty set)"; }

            var sb = new StringBuilder();
            int count = 1;

            if (!GeneratedData.KeyMemberCollection.TryGetValue(data.Key, out HashSet<string> _members))
            {
                return DisplayFormatting.Indent(2) + "Error, key does not exists.";
            }

            // Loop through all members and return
            foreach (var member in _members)
            {
                sb.AppendLine(string.Format(DisplayFormatting.Indent(2) + "{0}) {1}", count, member));
                count++;
            }

            return sb.ToString();
        }
    }
}