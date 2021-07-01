using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class KeyExistsCommandTest
    {
        /// <summary>
        /// Unit test method for testing KeyExists command with empty dictionary return empty set
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            KeyExistsCommand _keyExistsCommand = new KeyExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _keyExistsCommand.Execute(new ArgumentsModel { Key = "foo" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }

        /// <summary>
        /// Unit test method for testing KeyExists command with valid key returns true
        /// </summary>
        [Fact]
        public void Execute_InValidKey_ReturnsFalse()
        {
            // Arrange
            KeyExistsCommand _keyExistsCommand = new KeyExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _keyExistsCommand.Execute(new ArgumentsModel { Key = "foos" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("False", _result);
        }

        /// <summary>
        /// Unit test method for testing KeyExists command with no key throws argument exception
        /// </summary>
        [Fact]
        public void Execute_KeyAsNull_ThrowsArgumentException()
        {
            // Arrange
            KeyExistsCommand _keyExistsCommand = new KeyExistsCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _keyExistsCommand.Execute(new ArgumentsModel()));
        }

        /// <summary>
        /// Unit test method for testing KeyExists command with no arguments
        /// </summary>
        [Theory]
        [InlineData(null)]
        public void Execute_NoArguments_ThrowsArgumentNullException(ArgumentsModel model)
        {
            // Arrange
            KeyExistsCommand _keyExistsCommand = new KeyExistsCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _keyExistsCommand.Execute(model));
        }

        /// <summary>
        /// Unit test method for testing KeyExists command with valid key returns true
        /// </summary>
        [Fact]
        public void Execute_ValidKey_ReturnsTrue()
        {
            // Arrange
            KeyExistsCommand _keyExistsCommand = new KeyExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _keyExistsCommand.Execute(new ArgumentsModel { Key = "foo" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("True", _result);
        }
    }
}