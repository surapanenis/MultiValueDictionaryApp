using System.Collections.Generic;
using MultiValueDictionaryApp.Core.Commands;
using MultiValueDictionaryApp.Core.Models;
using Xunit;

namespace MultiValueDictionaryApp.Core.Tests
{
    public class AllMembersCommandTest
    {
        /// <summary>
        /// Unit test method for testing AllMembersCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_EmptyDictionary_ReturnsEmptySet()
        {
            // Arrange
            AllMembersCommand allMembersCommand = new AllMembersCommand();
            GeneratedData.KeyMemberCollection.Clear();

            // Act
            string _result = allMembersCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("empty set", _result);
        }

        /// <summary>
        /// Unit test method for testing AllMembersCommand with empty dictionary.
        /// </summary>
        [Fact]
        public void Execute_WithExistingKey_ReturnsAllMembers()
        {
            // Arrange
            AllMembersCommand allMembersCommand = new AllMembersCommand();
            GeneratedData.KeyMemberCollection.Clear();
            GeneratedData.KeyMemberCollection.Add("foo", new HashSet<string> { "bar" });

            // Act
            string _result = allMembersCommand.Execute(new ArgumentsModel());

            // Assert
            Assert.NotNull(_result);
            Assert.Contains("bar", _result);
        }
    }
}