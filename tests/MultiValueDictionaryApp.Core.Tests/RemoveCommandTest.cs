using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class RemoveCommandTest
    {
        /// <summary>
        /// Unit test method for testing RemoveAll with empty dictionary return key does not exist
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsKeyDoesNotExistsError()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _removeCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("key does not exists", _result);
        }

        /// <summary>
        /// Unit test method for testing Remove with invalid key return key does not exist
        /// </summary>
        [Fact]
        public void Execute_InvalidKey_ReturnsKeyDoesNotExistsError()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _removeCommand.Execute(new ArgumentsModel { Key = "foos", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("key does not exists", _result);
        }

        /// <summary>
        /// Unit test method for testing remove command with no arguments
        /// </summary>
        [Fact]
        public void Execute_NoArguments_ThrowsArgumentNullException()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _removeCommand.Execute(null));
        }

        /// <summary>
        /// Unit test method for testing remove command with no key or members
        /// </summary>
        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("key", "")]
        [InlineData("", "Value")]
        public void Execute_NoKeyOrMember_ThrowsArgumentException(string key, string member)
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _removeCommand.Execute(new ArgumentsModel { Key = key, Member = member }));
        }

        /// <summary>
        /// Unit test method for testing Remove command with valid key and invalid member returns member does not exist
        /// </summary>
        [Fact]
        public void Execute_ValidKeyAndInvalidMember_ReturnsMemberDoesNotExistsError()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _removeCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bars" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("member does not exists.", _result);
        }

        /// <summary>
        /// Unit test method for testing Remove Command with valid key and member
        /// </summary>
        [Fact]
        public void Execute_ValidKeyAndValidMember_LastMemberForKey_RemovesMemberAndKey()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar" });

            // Act
            string _result = _removeCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Removed", _result);
            Assert.Empty(GeneratedData.KeyMemberCollection);
        }

        /// <summary>
        /// Unit test method for testing Remove Command with valid key and member
        /// </summary>
        [Fact]
        public void Execute_ValidKeyAndValidMember_RemovesMemberFromTheKey()
        {
            // Arrange
            RemoveCommand _removeCommand = new RemoveCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _removeCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Removed", _result);
        }
    }
}