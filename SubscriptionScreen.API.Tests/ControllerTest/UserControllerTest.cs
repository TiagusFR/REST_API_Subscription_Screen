using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SubscriptionScreen.API.Controllers;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Services;
using System.Collections.Immutable;

namespace SubscriptionScreen.API.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void UserController_GetAll_ReturnListOfUsers()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetAll())
                       .Returns(new List<User>
                       {
                           new User { Id = Guid.NewGuid(), Name = "User 1" },
                           new User { Id = Guid.NewGuid(), Name = "User 2" }
                       });

            var mockMapper = new Mock<IMapper>();

            var controller = new UsersController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
            Assert.Equal(2, model.ToList().Count);
        }

        [Fact]
        public void UserController_GetById_ReturnSingleUser()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var expectedUser = new User { Id = userId, Name = "User 1" };

            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetById(userId))
                .Returns(expectedUser);

            var mockMapper = new Mock<IMapper>();

            var controller = new UsersController(mockService.Object, mockMapper.Object);

            //Act 
            var result = controller.GetById(userId);

            //Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<User>(okResult.Value);
            Assert.Equal(expectedUser.Id, model.Id);
            Assert.Equal(expectedUser.Name, model.Name);

        }

        [Fact]
        public void UserController_Add_ReturnsCreatedResultWithNewUser()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new UsersController(mockService.Object, mockMapper.Object);

            var userRequest = new UserRequestDTO
            {
                Name = "Test Subscription"
            };

            var expectedUser = new User
            {
                Id = Guid.NewGuid(),
                Name = userRequest.Name
            };

            mockMapper.Setup(mapper => mapper.Map<User>(userRequest))
                      .Returns(expectedUser);

            mockService.Setup(service => service.Add(It.IsAny<User>()))
           .Returns((User
           s) =>
           {
               return s;
           });

            // Act
            var result = controller.Post(userRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsAssignableFrom<User>(createdResult.Value);
            Assert.Equal(expectedUser.Id, model.Id);
            Assert.Equal(expectedUser.Name, model.Name);

            mockService.Verify(service => service.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void UserController_Update_ReturnsResultWithModifiedUSer()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new UsersController(mockService.Object, mockMapper.Object);

            var userId = Guid.NewGuid();
            var updateRequest = new UpdateUserRequestDTO
            {
                Name = "Updated Subscription Name"
            };

            //Act 
            var result = controller.Update(userId, updateRequest);

            //Assert 
            Assert.IsType<NoContentResult>(result);
            mockService.Verify(service => service.Update(userId, updateRequest), Times.Once);

        }

        [Fact]
        public void SubscriptionController_Delete_ReturnsResultWithDeletedSubscription()
        {
            // Arrange
            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new UsersController(mockService.Object, mockMapper.Object);

            var userID = Guid.NewGuid();

            // Act
            var result = controller.Delete(userID);

            // Assert
            Assert.IsType<NoContentResult>(result);

            mockService.Verify(service => service.Delete(userID), Times.Once);
        }







    }
}
