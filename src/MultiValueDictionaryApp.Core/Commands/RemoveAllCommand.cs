using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for removing all members for a key in dictionary.
    /// </summary>
    public class RemoveAllCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.RemoveAll;

        /// <summary>
        /// Method for executing the action
        /// </summary>
        /// <param name="data">Argument Data.</param>
        /// <returns>A string</returns>
        public string Execute(ArgumentsModel data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }

            // Validate key.
            if (string.IsNullOrWhiteSpace(data.Key)) { throw new ArgumentException("Key is required"); }

            // Add if key is not already in the dictionary
            if (!GeneratedData.KeyMemberCollection.ContainsKey(data.Key))
            {
                return DisplayFormatting.Indent(2) + "Error, key does not exists.";
            }

            // Removes all members for the key from dictionary
            GeneratedData.KeyMemberCollection.Remove(data.Key);

            return DisplayFormatting.Indent(2) + "Removed";
        }
    }
}