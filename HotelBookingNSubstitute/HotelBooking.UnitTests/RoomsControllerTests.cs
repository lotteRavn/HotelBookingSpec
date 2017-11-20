using HotelBooking.Controllers;
using NUnit.Framework;
using System;
using NSubstitute;
using HotelBooking.Models;

namespace HotelBooking.UnitTests
{
    class RoomsControllerTests
    {
        // These tests demonstrates interaction testing using NSubstitute to create
        // a mock object.

        [Test]
        public void DeleteConfirmed_WhenIdIsLargerThanZero_RemoveIsCalled()
        {
            // Arrange

            // Create a mock object
            IRepository<Room> fakeRoomRepos = Substitute.For<IRepository<Room>>();

            // Create RoomsController instance and inject the fake RoomRepository
            RoomsController controller = new RoomsController(fakeRoomRepos);
            int id = 1;

            // Act
            controller.DeleteConfirmed(id);

            // Assert
            // Assert against the mock object
            fakeRoomRepos.Received().Remove(id);
        }

        [Test]
        //[Ignore]
        public void DeleteConfirmed_WhenIdIsLessThanOne_RemoveIsNotCalled()
        {
            // Arrange
            IRepository<Room> fakeRoomRepos = Substitute.For<IRepository<Room>>();
            RoomsController controller = new RoomsController(fakeRoomRepos);
            int id = 0;

            // Act
            controller.DeleteConfirmed(id);

            // Assert
            fakeRoomRepos.DidNotReceive().Remove(id);
        }

        [Test]
        public void DeleteConfirmed_WhenIdIsLargerThan1000_RemoveThrowsException()
        {
            // Arrange
            IRepository<Room> fakeRoomRepos = Substitute.For<IRepository<Room>>();
            fakeRoomRepos.When(repos => repos.Remove(Arg.Is<int>(id => id > 1000))).
                Do(context => { throw new Exception("Room id cannot be larger than 1000"); });
            RoomsController controller = new RoomsController(fakeRoomRepos);

            // Assert
            Assert.Throws<Exception>(() => controller.DeleteConfirmed(1001));
        }
    }
}
