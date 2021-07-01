using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class AddCommandTest
    {
        /// <summary>
        /// Unit test method for testing Add command with key and members
        /// </summary>
        [Fact]
        public void Execute_AddNewKey_SuccessfullyAddsKeyToDictonary()
        {
            // Arrange
            AddCommand _addCommand = new AddCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _addCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Added", _result);
        }

        /// <summary>
        /// Unit test method for testing Add command with existing key and members returns member already exists error
        /// </summary>
        [Fact]
        public void Execute_KeyAndMemberExists_ReturnsMemberAlreadyExistsError()
        {
            // Arrange
            AddCommand _addCommand = new AddCommand();

            Dictionary<string, HashSet<string>> _keyMemberCollection = new Dictionary<string, HashSet<string>>();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar" });

            // Act
            string _result = _addCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("member already exists for the key", _result);
        }

        /// <summary>
        /// Unit test method for testing Add command with key and members
        /// </summary>
        [Fact]
        public void Execute_KeyExists_SuccessfullyAddsMemberToKey()
        {
            // Arrange
            AddCommand _addCommand = new AddCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar" });

            // Act
            string _result = _addCommand.Execute(new ArgumentsModel { Key = "foo", Member = "baz" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("Added", _result);
        }

        /// <summary>
        /// Unit test method for testing Add command with no arguments
        /// </summary>
        [Theory]
        [InlineData(null)]
        public void Execute_NoArguments_ThrowsArgumentNullException(ArgumentsModel model)
        {
            // Arrange
            AddCommand _addCommand = new AddCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _addCommand.Execute(model));
        }

        /// <summary>
        /// Unit test method for testing Add command with no key or members
        /// </summary>
        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("key", "")]
        [InlineData("", "Value")]
        public void Execute_NoKeyOrMember_ThrowsArgumentException(string key, string member)
        {
            // Arrange
            AddCommand _addCommand = new AddCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _addCommand.Execute(new ArgumentsModel { Key = key, Member = member }));
        }
    }
}