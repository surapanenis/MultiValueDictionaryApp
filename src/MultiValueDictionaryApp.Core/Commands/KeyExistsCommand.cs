using System;
using MultiValueDictionaryApp.Common;
using MultiValueDictionaryApp.Core.Models;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Command class for checking if key exists in the dictionary.
    /// </summary>
    public class KeyExistsCommand : ICommand
    {
        /// <summary>
        /// Gets the action type
        /// </summary>
        public Action ActionType => Action.KeyExists;

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

            return DisplayFormatting.Indent(2) + $"{GeneratedData.KeyMemberCollection.ContainsKey(data.Key)}";
        }
    }
}