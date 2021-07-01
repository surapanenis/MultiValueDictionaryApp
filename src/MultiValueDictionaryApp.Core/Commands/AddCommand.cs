using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for adding items to dictionary.
    /// </summary>
    public class AddCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Add;

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        public string Execute(ArgumentsModel data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }

            // Validate key and member values.
            if (string.IsNullOrWhiteSpace(data.Key)) { throw new ArgumentException(DisplayFormatting.Indent(2) + "Key is required"); }
            if (string.IsNullOrWhiteSpace(data.Member)) { throw new ArgumentException(DisplayFormatting.Indent(2) + "member is required"); }

            // Add if key is not already in the dictionary
            if (!GeneratedData.KeyMemberCollection.ContainsKey(data.Key))
            {
                GeneratedData.KeyMemberCollection.Add(data.Key, new HashSet<string> { data.Member });
            }
            else if (GeneratedData.KeyMemberCollection.TryGetValue(data.Key, out HashSet<string> _members))
            {
                // if member already exists for the key then return error message otherwise add to the members.
                if (_members.Contains(data.Member)) { return DisplayFormatting.Indent(2) + "Error, member already exists for the key"; }

                GeneratedData.KeyMemberCollection[data.Key].Add(data.Member);
            }

            return DisplayFormatting.Indent(2) + "Added";
        }
    }
}