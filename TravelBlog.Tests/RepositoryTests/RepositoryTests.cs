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
        EFSuggestionRepository db = new EFSuggestionRepository( new TravelBlogTestDbContext());
        public void Dispose()
        {
            db.DeleteSuggestions();
        }

        [Fact]
        public void Db_GetAllSuggestsionsListOfSuggestions_Test()
        {
            //Arrange
            //DbSetup();
            //Act
            //Assert
            var result = db.AllSuggestions;
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
            db.Add(newSuggestion);
            db.SaveChanges();
            //Assert
            //Assert.True(true);
            Assert.Equal(db.AllSuggestions, list);
        }
    }
}
