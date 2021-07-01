using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// COmmand class for checking if member exists for a key in dictionary.
    /// </summary>
    public class MemberExistsCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.MemberExists;

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
            if (string.IsNullOrWhiteSpace(data.Member)) { throw new ArgumentException("member is required"); }

            // if dictionary is empty return empty string
            if (GeneratedData.KeyMemberCollection.Count == 0) { return "(empty set)"; }

            // Add if key is not already in the dictionary
            if (!GeneratedData.KeyMemberCollection.ContainsKey(data.Key))
            {
                return DisplayFormatting.Indent(2) + "false";
            }

            if (GeneratedData.KeyMemberCollection.TryGetValue(data.Key, out HashSet<string> _members))
            {
                return DisplayFormatting.Indent(2) + $"{_members.Contains(data.Member)}";
            }
            else
            {
                return DisplayFormatting.Indent(2) + "false";
            }
        }
    }
}