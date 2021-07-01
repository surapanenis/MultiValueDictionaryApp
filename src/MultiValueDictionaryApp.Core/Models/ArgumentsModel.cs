using System;
using System.Collections.Generic;
using System.Text;

namespace MultiValueDictionaryApp.Core.Models
{
    /// <summary>
    /// A model class for command arguments.
    /// </summary>
    public class ArgumentsModel
    {
        /// <summary>
        /// The key argument.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The Member argument.
        /// </summary>
        public string Member { get; set; }
    }
}