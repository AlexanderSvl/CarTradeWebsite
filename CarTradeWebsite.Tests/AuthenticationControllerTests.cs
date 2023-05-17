using CarTradeWebsite.API.Controllers;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
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
    internal class AuthenticationControllerTests
    {
        private AuthenticationController _authenticationController;
        private Mock<IAuthenticationRepository> _authenticationRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _authenticationRepositoryMock = new Mock<IAuthenticationRepository>();
            _authenticationController = new AuthenticationController(_authenticationRepositoryMock.Object);
        }

        [Test]
        public async Task Login_ValidUser_ReturnsOk()
        {
            // Arrange
            var user = new UserLoginModel
            {
                Email = "aleksander.svilarovv@gmail.com",
                Password = "!23123123Wer"
            };

            var authenticatedResponse = new AuthenticatedResponseModel
            {
                Token = "token"
            };

            _authenticationRepositoryMock.Setup(repo => repo.Login(user)).ReturnsAsync(authenticatedResponse);

            // Act
            var result = await _authenticationController.Login(user);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;

            Assert.AreEqual(authenticatedResponse, okResult.Value);
        }

        [Test]
        public async Task Login_InvalidUser_ReturnsUnauthorized()
        {
            // Arrange
            var user = new UserLoginModel
            {
                Email = "invalidEmail@",
                Password = "password"
            };

            _authenticationRepositoryMock.Setup(repo => repo.Login(user)).ReturnsAsync((AuthenticatedResponseModel)null);

            // Act
            var result = await _authenticationController.Login(user);

            // Assert
            Assert.IsInstanceOf<UnauthorizedResult>(result.Result);
        }
    }
}
