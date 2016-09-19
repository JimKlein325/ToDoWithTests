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
        EFSuggestionRepository db = new EFSuggestionRepository(new TravelBlogDbContext());
        Mock<ISuggestionRepository> mock = new Mock<ISuggestionRepository>();

        //private void DbSetup()
        //{
        //    mock.Setup(m => m.GetAllSuggestions());//.Returns( 

        //    //    new List<Suggestion>()
        //    //{
        //    //    new Suggestion {Id = 1, City = "Portland", Country = "USA", Description = "Rainy" },
        //    //    new Suggestion {Id = 2, City = "Seattle", Country = "USA", Description = "Rainier than Portland" },
        //    //    new Suggestion {Id = 3, City = "Los Angeles", Country = "USA", Description = "Sunny all the time" }
        //    //}
        //    //);
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
