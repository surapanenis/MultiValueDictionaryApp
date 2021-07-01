using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class ClearCommandTest
    {
        /// <summary>
        /// Unit test method for testing ClearCommand to Removes All Keys And Members.
        /// </summary>
        [Fact]
        public void Execute_DictionaryHasKeys_RemovesAllKeysAndMembers()
        {
            // Arrange
            ClearCommand _clearCommand = new ClearCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _clearCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Cleared", _result);
            Assert.Empty(GeneratedData.KeyMemberCollection);
        }

        /// <summary>
        /// Unit test method for testing ClearCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            ClearCommand _clearCommand = new ClearCommand();

            // Act
            string _result = _clearCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }
    }
}