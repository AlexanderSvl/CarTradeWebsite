using CarTradeWebsite.API.Controllers;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using CarTradeWebsite.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTradeWebsite.Tests
{
    internal class SearchControllerTests
    {
        private SearchController _searchController;
        private Mock<ISearchRepository> _searchRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _searchRepositoryMock = new Mock<ISearchRepository>();
            _searchController = new SearchController(_searchRepositoryMock.Object);
        }

        [Test]
        public async Task Search_WithResults_ReturnsOk()
        {
            // Arrange
            var searchParameters = new SearchParameters
            {
                CarMake = "Honda"
            };

            var posts = new List<PostModel>
            {
                new PostModel { CarMake = "Honda" } 
            };

            _searchRepositoryMock.Setup(repo => repo.SearchPosts(searchParameters)).ReturnsAsync(posts);

            // Act
            var result = await _searchController.Search(searchParameters);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(posts, okResult.Value);
        }

        [Test]
        public async Task Search_WithNoResults_ReturnsNotFound()
        {
            // Arrange
            var searchParameters = new SearchParameters
            {
                CarMake = "notAnExistingCarMake"
            };

            _searchRepositoryMock.Setup(repo => repo.SearchPosts(searchParameters)).ReturnsAsync(new List<PostModel>());

            // Act
            var result = await _searchController.Search(searchParameters);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }
    }
}
