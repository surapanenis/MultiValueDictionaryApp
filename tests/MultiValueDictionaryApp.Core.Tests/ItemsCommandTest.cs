using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class ItemsCommandTest
    {
        /// <summary>
        /// Unit test method for testing ItemsCommand to return all keys and their members.
        /// </summary>
        [Fact]
        public void Execute_DictionaryHasKeysAndMembers_ReturnsAllKeysAndTheirMembers()
        {
            // Arrange
            ItemsCommand _itemsCommand = new ItemsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _itemsCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("foo: bar", _result);
        }

        /// <summary>
        /// Unit test method for testing ItemsCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            ItemsCommand _itemsCommand = new ItemsCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _itemsCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }
    }
}