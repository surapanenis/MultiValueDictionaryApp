using System;
using System.Collections.Generic;
using System.Text;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class MembersCommandTest
    {
        /// <summary>
        /// Unit test method for testing MembersCommand with empty dictionary return empty set
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            MembersCommand _membersCommand = new MembersCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = _membersCommand.Execute(new ArgumentsModel { Key = "foo", Member = "bar" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }

        /// <summary>
        /// Unit test method for testing MembersCommand with empty dictionary return empty set
        /// </summary>
        [Fact]
        public void Execute_InvalidKey_ReturnsKeyDoesNotExistsError()
        {
            // Arrange
            MembersCommand _membersCommand = new MembersCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _membersCommand.Execute(new ArgumentsModel { Key = "foos" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("key does not exists", _result);
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with no key specified
        /// </summary>
        [Fact]
        public void Execute_KeyAsNull_ThrowsArgumentException()
        {
            // Arrange
            MembersCommand _membersCommand = new MembersCommand();

            // Assert
            Assert.Throws<ArgumentException>(() => _membersCommand.Execute(new ArgumentsModel()));
        }

        /// <summary>
        /// Unit test method for testing MemberExists command with no arguments
        /// </summary>
        [Fact]
        public void Execute_NoArguments_ThrowsArgumentNullException()
        {
            // Arrange
            MembersCommand _membersCommand = new MembersCommand();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _membersCommand.Execute(null));
        }

        /// <summary>
        /// Unit test method for testing MembersCommand with empty dictionary return empty set
        /// </summary>
        [Fact]
        public void Execute_ValidKey_ReturnsAllMembersForGivenKey()
        {
            // Arrange
            MembersCommand _membersCommand = new MembersCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar", "baz" });

            // Act
            string _result = _membersCommand.Execute(new ArgumentsModel { Key = "foo" });

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("baz", _result);
        }
    }
}