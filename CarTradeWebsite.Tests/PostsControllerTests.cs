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
    internal class PostsControllerTests
    {
        private PostController _postController;
        private Mock<IPostRepository> _postRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _postRepositoryMock = new Mock<IPostRepository>();
            _postController = new PostController(_postRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllPosts_WithResults_ReturnsOk()
        {
            // Arrange
            var posts = new List<PostModel>
            {
                new PostModel
                {
                    ID = Guid.NewGuid(),
                    Title = "Car 1",
                    CarImages = new List<ImageModel>
                    {
                         new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                    CoverImageURL = "cover-image-url-1",
                    CarMake = "Make 1",
                    CarModel = "Model 1",
                    FuelType = "Fuel Type 1",
                    EngineLayout = "Engine Layout 1",
                    Mileage = 10000,
                    YearOfProduction = 2021,
                    Color = "Color 1",
                    EngineDisplacement = "Engine Displacement 1",
                    TransmissionType = "Transmission Type 1",
                    Description = "Description 1",
                    Location = "Location 1",
                    Price = 10000,
                    Options = new List<OptionModel>
                    {
                        new OptionModel 
                        { 
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        }
                    },
                    DateOfCreation = DateTime.UtcNow
                },
                new PostModel
                {
                    ID = Guid.NewGuid(),
                    Title = "Car 2",
                    CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                    CoverImageURL = "cover-image-url-2",
                    CarMake = "Make 2",
                    CarModel = "Model 2",
                    FuelType = "Fuel Type 2",
                    EngineLayout = "Engine Layout 2",
                    Mileage = 20000,
                    YearOfProduction = 2022,
                    Color = "Color 2",
                    EngineDisplacement = "Engine Displacement 2",
                    TransmissionType = "Transmission Type 2",
                    Description = "Description 2",
                    Location = "Location 2",
                    Price = 20000,
                    Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 2"
                        }
                    },
                    DateOfCreation = DateTime.UtcNow
                }
            };

            _postRepositoryMock.Setup(repo => repo.GetAllPostsAsync()).ReturnsAsync(posts);

            // Act
            var result = await _postController.GetAllPosts();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(posts, okResult.Value);
        }

        [Test]
        public async Task GetAllPosts_WithNoResults_ReturnsNoContent()
        {
            // Arrange
            _postRepositoryMock.Setup(repo => repo.GetAllPostsAsync()).ReturnsAsync(new List<PostModel>());

            // Act
            var result = await _postController.GetAllPosts();

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result.Result);
        }

        [Test]
        public async Task GetAllPostsCount_ReturnsOkWithCount()
        {
            // Arrange
            int postCount = 10;
            _postRepositoryMock.Setup(repo => repo.GetTotalPostsCountAsync()).ReturnsAsync(postCount);

            // Act
            var result = await _postController.GetAllPostsCount();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(postCount, okResult.Value);
        }

        [Test]
        public async Task CreatePost_ValidPost_ReturnsOkWithCreatedPost()
        {
            // Arrange
            var post = new PostModel
            {
                ID = Guid.NewGuid(),
                Title = "Car 2",
                CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 2"
                        }
                    },
                DateOfCreation = DateTime.UtcNow
            };

            var createdPost = new PostModel
            {
                ID = Guid.NewGuid(),
                Title = "Car 2",
                CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 2"
                        }
                    },
                DateOfCreation = DateTime.UtcNow
            };
            _postRepositoryMock.Setup(repo => repo.CreatePostAsync(post)).ReturnsAsync(createdPost);

            // Act
            var result = await _postController.CreatePost(post);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(createdPost, okResult.Value);
        }

        [Test]
        public async Task CreatePost_InvalidPost_ReturnsBadRequest()
        {
            // Arrange
            var post = new PostModel
            {
                ID = Guid.NewGuid(),
                Title = null,
                CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 2"
                        }
                    },
                DateOfCreation = DateTime.UtcNow
            }; 

            _postRepositoryMock.Setup(repo => repo.CreatePostAsync(post)).ReturnsAsync((PostModel)null);

            // Act
            var result = await _postController.CreatePost(post);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result.Result);
        }

        [Test]
        public async Task GetPostById_ExistingId_ReturnsOkWithPost()
        {
            // Arrange
            var postId = Guid.NewGuid();
            var post = new PostModel
            {
                ID = Guid.NewGuid(),
                Title = "Car 2",
                CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        }
                    },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 2"
                        }
                    },
                DateOfCreation = DateTime.UtcNow
            };

            _postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(post);

            // Act
            var result = await _postController.GetPostById(postId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(post, okResult.Value);
        }

        [Test]
        public async Task GetPostById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var postId = Guid.NewGuid();
            _postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync((PostModel)null);

            // Act
            var result = await _postController.GetPostById(postId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task EditPost_ValidPost_ReturnsOkWithUpdatedPost()
        {
            // Arrange
            var postId = Guid.NewGuid();
            var post = new PostModel
            {
                ID = postId,
                Title = "Car 2",
                CarImages = new List<ImageModel>
                    {
                        new ImageModel
                        {
                            ID = Guid.NewGuid(),
                            URL = "URL 1"
                        },
                    },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                    {
                        new OptionModel
                        {
                            ID = Guid.NewGuid(),
                            Name = "Option 1"
                        },
                    },
                DateOfCreation = DateTime.UtcNow
            };

            var updatedPost = new PostModel
            {
                ID = postId,
                Title = "Car 2",
                CarImages = new List<ImageModel>
                {
                    new ImageModel
                    {
                        ID = post.CarImages.First().ID,
                        URL = "URL 1"
                    },
                },
                CoverImageURL = "cover-image-url-2",
                CarMake = "Make 2",
                CarModel = "Model 2",
                FuelType = "Fuel Type 2",
                EngineLayout = "Engine Layout 2",
                Mileage = 20000,
                YearOfProduction = 2022,
                Color = "Color 2",
                EngineDisplacement = "Engine Displacement 2",
                TransmissionType = "Transmission Type 2",
                Description = "Description 2",
                Location = "Location 2",
                Price = 20000,
                Options = new List<OptionModel>
                {
                    new OptionModel
                    {
                        ID = post.Options.First().ID,
                        Name = "Option 1"
                    },
                },
                DateOfCreation = post.DateOfCreation
            };

            _postRepositoryMock.Setup(repo => repo.EditPostAsync(postId, post)).ReturnsAsync(updatedPost);

            // Act
            var result = await _postController.EditPost(postId, post);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(updatedPost, okResult.Value);
        }

        [Test]
        public async Task EditPost_InvalidPost_ReturnsBadRequest()
        {
            // Arrange
            var postId = Guid.NewGuid();
            var post = new PostModel
            {
                Description = "Description 2",
                Location = null
            };

            _postRepositoryMock.Setup(repo => repo.EditPostAsync(postId, post)).ReturnsAsync((PostModel)null);

            // Act
            var result = await _postController.EditPost(postId, post);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result.Result);
        }

        [Test]
        public async Task DeletePost_ExistingPost_ReturnsOk()
        {
            // Arrange
            var postId = Guid.NewGuid();
            _postRepositoryMock.Setup(repo => repo.DeletePostAsync(postId)).ReturnsAsync(true);

            // Act
            var result = await _postController.DeletePost(postId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result.Result);
        }

        [Test]
        public async Task DeletePost_NonExistingPost_ReturnsNotFound()
        {
            // Arrange
            var postId = Guid.NewGuid();
            _postRepositoryMock.Setup(repo => repo.DeletePostAsync(postId)).ReturnsAsync(false);

            // Act
            var result = await _postController.DeletePost(postId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = (NotFoundObjectResult)result.Result;
            Assert.AreEqual(postId, notFoundResult.Value);
        }
    }
}
