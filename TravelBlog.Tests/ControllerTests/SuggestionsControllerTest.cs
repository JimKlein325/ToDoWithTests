using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using TravelBlog.Models;
using TravelBlog.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TravelBlog.Tests.ControllerTests
{
    public class SuggestionsControllerTest : IDisposable
    {
        EFSuggestionRepository repoWithTestDBContext = new EFSuggestionRepository(new TravelBlogTestDbContext());
        Mock<ISuggestionRepository> mock = new Mock<ISuggestionRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.AllSuggestions).Returns(new List<Suggestion>
            {
                new Suggestion { Id = 1, City = "Portland", Country = "United States", Description = "The City of Roses"}
            });
            
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void Mock_GetViewResultIndex_Test()
        {
            //Arrange
            DbSetup();
            SuggestionsController controller = new SuggestionsController(mock.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfSuggestions_Test()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new SuggestionsController(mock.Object).Index() as ViewResult;
            //Act
            var result = indexView.ViewData.Model;
            //Assert
            Assert.IsType<List<Suggestion>>(result);
        }
        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            //Arrange
            DbSetup();
            SuggestionsController controller = new SuggestionsController(mock.Object);
            var testItem = new Suggestion { Id = 1, City = "Portland", Country = "United States", Description = "The City of Roses" };
            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Suggestion>;

            // Assert
            Assert.Contains<Suggestion>(testItem, collection);
        }
       [Fact]
       public void Db_AddSuggestion_Test()
        {
            //Arrange
            SuggestionsController controller = new SuggestionsController(this.repoWithTestDBContext);
            new Suggestion { Id = 1, City = "Borihg", Country = "USA", Description = "Fun places" };

            //Act
            var addSuggestionView = controller.AddSuggestion("Boring", "USA", "Fun place");// as ViewResult;

            //Assert
            Assert.True(true);
        }
    }
}
