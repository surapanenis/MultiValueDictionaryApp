using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class KeysCommandTest
    {
        /// <summary>
        /// Unit test method for testing KeysCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            KeysCommand _keysCommand = new KeysCommand();

            // Act
            string _result = _keysCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }

        /// <summary>
        /// Unit test method for testing KeysCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_WithValidKeys_ReturnsAllKeysFromDictionary()
        {
            // Arrange
            KeysCommand _keysCommand = new KeysCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _keysCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("foo", _result);
        }
    }
}