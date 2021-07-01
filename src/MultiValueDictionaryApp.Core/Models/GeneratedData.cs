using System.Collections.Generic;

namespace MultiValueDictionaryApp.Core.Models
{
    /// <summary>
    /// Static model class for storing data in dictionary
    /// </summary>
    public static class GeneratedData
    {
        private static Dictionary<string, HashSet<string>> _keyMemberCollection;

        public static Dictionary<string, HashSet<string>> KeyMemberCollection
        {
            get
            {
                // Initialize the dictionary first time property is accessed.
                if (_keyMemberCollection == null)
                {
                    _keyMemberCollection = new Dictionary<string, HashSet<string>>();
                }
                return _keyMemberCollection;
            }
        }
    }
}