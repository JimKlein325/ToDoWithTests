using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using TravelBlog.Models;
using TravelBlog.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TravelBlog.Tests.RepositoryTests
{
    public class RepositoryTests : IDisposable
    {
        EFSuggestionRepository repo = new EFSuggestionRepository( new TravelBlogTestDbContext());
        public void Dispose()
        {
            repo.DeleteSuggestions();
        }

        [Fact]
        public void Db_GetAllSuggestsionsListOfSuggestions_Test()
        {
            //Arrange
            //DbSetup();
            //Act
            //Assert
            var result = repo.AllSuggestions;
            Assert.IsType<List<Suggestion>>(result);
        }
        [Fact]
        public void Db_SaveSavesSuggestionToDb_Test()
        {
            //Arrange
            Suggestion newSuggestion = new Suggestion() {
                City = "Portland",
                Country = "USA",
                Description = "Rainy"
            };
            var list = new List<Suggestion>();
            list.Add(newSuggestion);
            //Act
            repo.Add(newSuggestion);
            repo.SaveChanges();
            //Assert
            //Assert.True(true);
            Assert.Equal(repo.AllSuggestions, list);
        }
        [Fact]
        public void Db_FindSuggestion_Test()
        {
            //Arrange
            //Arrange
            Suggestion newSuggestion = new Suggestion()
            {
                City = "Portland",
                Country = "USA",
                Description = "Rainy"
            };
            repo.Add(newSuggestion);
            repo.SaveChanges();
            var suggestionId = newSuggestion.Id;
            // Act
            Suggestion foundSuggestion = repo.Find(suggestionId);
            //Assert
            Assert.Equal(newSuggestion, foundSuggestion);
        }
        [Fact]
        public void Db_DeleteIndividualSuggestion_Test()
        {
            //Arrange
            Suggestion newSuggestion = new Suggestion()
            {
                City = "Portland",
                Country = "USA",
                Description = "Rainy"
            };
            repo.Add(newSuggestion);
            repo.SaveChanges();
            var suggestionId = newSuggestion.Id;
            //Act
            repo.Delete(suggestionId);
            //Assert
            Assert.DoesNotContain<Suggestion>(newSuggestion, repo.AllSuggestions);
        }
        [Fact]
        public void Db_UpdatesChanges_Test()
        {
            //Arrange
            Suggestion newSuggestion = new Suggestion()
            {
                City = "Portland",
                Country = "USA",
                Description = "Rainy"
            };
            repo.Add(newSuggestion);
            repo.SaveChanges();
            var suggestionId = newSuggestion.Id;
            var foundSuggestion = repo.Find(suggestionId);
            //Act
            var newName = "Houston";
            foundSuggestion.City = newName;
            repo.Edit(foundSuggestion);
            var changedSuggestion = repo.Find(suggestionId);
            //Assert
            Assert.Equal(newName, changedSuggestion.City);
        }
    }
}
