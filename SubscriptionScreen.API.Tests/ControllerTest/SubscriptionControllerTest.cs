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
    public class SubscriptionControllerTests
    {
        [Fact]
        public void SubscriptionController_GetAll_ReturnListOfSubscriptions()
        {
            // Arrange
            var mockService = new Mock<ISubscriptionService>();
            mockService.Setup(service => service.GetAll())
                       .Returns(new List<Subscription>
                       {
                           new Subscription { Id = Guid.NewGuid(), Name = "Subscription 1" },
                           new Subscription { Id = Guid.NewGuid(), Name = "Subscription 2" }
                       });

            var mockMapper = new Mock<IMapper>(); 

            var controller = new SubscriptionController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Subscription>>(okResult.Value);
            Assert.Equal(2, model.ToList().Count); 
        }

        [Fact]
        public void SubscriptionController_GetById_ReturnSingleSubscription()
        {
            //Arrange
            var subscriptionId = Guid.NewGuid();
            var expectedSubscription = new Subscription { Id = subscriptionId, Name = "Subscription 1" };

            var mockService = new Mock<ISubscriptionService>();
            mockService.Setup (service => service.GetById(subscriptionId))
                .Returns(expectedSubscription);

            var mockMapper = new Mock<IMapper>();
            
            var controller = new SubscriptionController(mockService.Object, mockMapper.Object);

            //Act 
            var result = controller.GetById(subscriptionId);

            //Assert 
            var okResult = Assert.IsType<OkObjectResult> (result);
            var model = Assert.IsAssignableFrom<Subscription>(okResult.Value);
            Assert.Equal(expectedSubscription.Id, model.Id);
            Assert.Equal(expectedSubscription.Name, model.Name);

        }

        [Fact]
        public void SubscriptionController_Add_ReturnsCreatedResultWithNewSubscription()
        {
            // Arrange
            var mockService = new Mock<ISubscriptionService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new SubscriptionController(mockService.Object, mockMapper.Object);

            var subscriptionRequest = new SubscriptionRequestDTO
            {
                Name = "Test Subscription"
            };

            var expectedSubscription = new Subscription
            {
                Id = Guid.NewGuid(), 
                Name = subscriptionRequest.Name
            };

            mockMapper.Setup(mapper => mapper.Map<Subscription>(subscriptionRequest))
                      .Returns(expectedSubscription);

            mockService.Setup(service => service.Add(It.IsAny<Subscription>()))
           .Returns((Subscription s) => 
           {
               return s;
           });

            // Act
            var result = controller.Post(subscriptionRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsAssignableFrom<Subscription>(createdResult.Value);
            Assert.Equal(expectedSubscription.Id, model.Id);
            Assert.Equal(expectedSubscription.Name, model.Name);

            mockService.Verify(service => service.Add(It.IsAny<Subscription>()), Times.Once);
        }

        [Fact]
        public void SubscriptionController_Update_ReturnsResultWithModifiedSubscription()
        {
            //Arrange
            var mockService = new Mock<ISubscriptionService>();
            var mockMapper = new Mock<IMapper> ();

            var controller = new SubscriptionController(mockService.Object, mockMapper.Object);

            var subscriptionId = Guid.NewGuid();
            var updateRequest = new UpdateSubscriptionRequestDTO
            {
                Name = "Updated Subscription Name"
            };

            //Act 
            var result = controller.Update(subscriptionId, updateRequest);

            //Assert 
            Assert.IsType<NoContentResult>(result);
            mockService.Verify(service => service.Update(subscriptionId, updateRequest), Times.Once);

        }

        [Fact]
        public void SubscriptionController_Delete_ReturnsResultWithDeletedSubscription()
        {
            // Arrange
            var mockService = new Mock<ISubscriptionService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new SubscriptionController(mockService.Object, mockMapper.Object);

            var subscriptionId = Guid.NewGuid();

            // Act
            var result = controller.Delete(subscriptionId);

            // Assert
            Assert.IsType<NoContentResult>(result);

           
            mockService.Verify(service => service.Delete(subscriptionId), Times.Once);
        }







    }
}
