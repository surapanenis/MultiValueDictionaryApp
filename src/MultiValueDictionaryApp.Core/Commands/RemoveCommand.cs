using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for removing a member from specified key.
    /// </summary>
    public class RemoveCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.Remove;

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

            // Add if key is not already in the dictionary
            if (!GeneratedData.KeyMemberCollection.ContainsKey(data.Key))
            {
                return DisplayFormatting.Indent(2) + "Error, key does not exists.";
            }
            else if (GeneratedData.KeyMemberCollection.TryGetValue(data.Key, out HashSet<string> _members))
            {
                // if member does not exists for the key then return error message otherwise continue to remove.
                if (!_members.Contains(data.Member)) { return DisplayFormatting.Indent(2) + "Error, member does not exists."; }

                _members.Remove(data.Member);

                // if member is the
                if (_members.Count == 0)
                {
                    GeneratedData.KeyMemberCollection.Remove(data.Key);
                }
            }

            return DisplayFormatting.Indent(2) + "Removed";
        }
    }
}