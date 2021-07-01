using System;
using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class MemberExistsCommandTest
    {
        /// <summary>
        /// Unit test method for testing MemberExists command with empty dictionary return empty set
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _memberExistsCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with invalid key
        /// </summary>
        [Fact]
        public void Execute_InvalidKey_ReturnsFalse()
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _memberExistsCommand.Execute(new ArgumentsModel { Key = "foos", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("false", _result);
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with no arguments
        /// </summary>
        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("key", "")]
        [InlineData("", "Value")]
        public void Execute_keyOrMemberNull_ThrowsArgumentException(string key, string member)
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _memberExistsCommand.Execute(new ArgumentsModel { Key = key, Member = member }));
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with no arguments
        /// </summary>
        [Fact]
        public void Execute_NoArguments_ThrowsArgumentNullException()
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _memberExistsCommand.Execute(null));
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with valid key and member
        /// </summary>
        [Fact]
        public void Execute_ValidKeyAndInvalidMember_ReturnsFalse()
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _memberExistsCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bars" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("False", _result);
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with valid key and member
        /// </summary>
        [Fact]
        public void Execute_ValidKeyAndMember_ReturnsTrue()
        {
            // Arrange
            MemberExistsCommand _memberExistsCommand = new MemberExistsCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _memberExistsCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("True", _result);
        }
    }
}