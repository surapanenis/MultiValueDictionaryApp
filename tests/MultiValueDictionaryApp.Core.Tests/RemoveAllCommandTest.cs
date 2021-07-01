using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class RemoveAllCommandTest
    {
        /// <summary>
        /// Unit test method for testing RemoveAll with empty dictionary return key does not exist
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsKeyDoesNotExistsError()
        {
            // Arrange
            RemoveAllCommand _removeAllCommaand = new RemoveAllCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _removeAllCommaand.Execute(new ArgumentsModel { Key = "foo" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("key does not exists", _result);
        }

        /// <summary>
        /// Unit test method for testing RemoveAll with invalid key return key does not exist
        /// </summary>
        [Fact]
        public void Execute_InvalidKey_ReturnsKeyDoesNotExistsError()
        {
            // Arrange
            RemoveAllCommand _removeAllCommaand = new RemoveAllCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _removeAllCommaand.Execute(new ArgumentsModel { Key = "foos" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("key does not exists", _result);
        }

        /// <summary>
        /// Unit test method for testing RemoveAll command with no key specified
        /// </summary>
        [Fact]
        public void Execute_KeyAsNull_ThrowsArgumentException()
        {
            // Arrange
            RemoveAllCommand _removeAllCommaand = new RemoveAllCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _removeAllCommaand.Execute(new ArgumentsModel()));
        }

        /// <summary>
        /// Unit test method for testing RemoveAll command with no arguments
        /// </summary>
        [Fact]
        public void Execute_NoArguments_ThrowsArgumentNullException()
        {
            // Arrange
            RemoveAllCommand _removeAllCommaand = new RemoveAllCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _removeAllCommaand.Execute(null));
        }

        /// <summary>
        /// Unit test method for testing RemoveAll with valid key
        /// </summary>
        [Fact]
        public void Execute_ValidKey_RemovesKeyAndAllMembersFromDictionary()
        {
            // Arrange
            RemoveAllCommand _removeAllCommaand = new RemoveAllCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _removeAllCommaand.Execute(new ArgumentsModel { Key = "foo" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Removed", _result);
            Assert.Empty(GeneratedData.KeyMemberCollection);
        }
    }
}