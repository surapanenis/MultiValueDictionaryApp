using System;
using System.Collections.Generic;
using System.Text;

namespace MultiValueDictionaryApp.Core.Commands
{
    /// <summary>
    /// Defines the types of command actions.
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// Represents action type as undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Represents action type for adding items to dictionary.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents action type for fetching all members from dictionary.
        /// </summary>
        AllMembers = 2,

        /// <summary>
        /// Represents action type for clearing dictionary.
        /// </summary>
        Clear = 3,

        /// <summary>
        /// Represents action type for fetching all items from dictionary.
        /// </summary>
        Items = 4,

        /// <summary>
        /// Represents action type for fetching all keys from dictionary.
        /// </summary>
        Keys = 5,

        /// <summary>
        /// Represents action type for fetching all keys from dictionary.
        /// </summary>
        KeyExists = 6,

        /// <summary>
        /// Represents action type for fetching all members from dictionary by key.
        /// </summary>
        Members = 7,

        /// <summary>
        /// Represents action type for finding if member exists in dictionary by key.
        /// </summary>
        MemberExists = 8,

        /// <summary>
        /// Represents action type for removing member in dictionary by key.
        /// </summary>
        Remove = 9,

        /// <summary>
        /// Represents action type for removing all members in a dictionary by key.
        /// </summary>
        RemoveAll = 10
    }
}