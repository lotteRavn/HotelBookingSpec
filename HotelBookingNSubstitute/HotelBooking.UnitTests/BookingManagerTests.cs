using HotelBooking.BusinessLogic;
using NUnit.Framework;
using System;
using NSubstitute;
using System.Collections.Generic;
using HotelBooking.Models;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        [Test]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today;
            Assert.Catch<ArgumentException>(() => manager.FindAvailableRoom(date, date));
        }

        [Test]
        public void FindAvailableRoom_StartDateIsTomorrowEndDateIsTomorrowAndRoomIsAvailable_RoomIdNotMinusOne()
        {
            DateTime startDate = DateTime.Today.AddDays(1);
            DateTime endDate = DateTime.Today.AddDays(1);
            FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne(startDate, endDate);
        }

        // I have created a private test method here, because I expect in a future version to test
        // FindAvailableRoom() with several combinations of start and end dates. You would normally
        // use the TestCase attribute in such a situation, but TestCase attribute values must be
        // constant expressions. DateTime.Today.AddDays() is not a constant expression.
        private void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne(DateTime startDate, DateTime endDate)
        {
            BookingManager manager = CreateBookingManager();

            int roomId = manager.FindAvailableRoom(startDate, endDate);

            Assert.AreNotEqual(-1, roomId);
        }

        [Test]
        public void CreateBooking_RoomNotAvailable_ReturnsFalse()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today.AddDays(10);
            Booking b = new Booking { StartDate = date, EndDate = date, };
            bool result = manager.CreateBooking(b);
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateBooking_RoomAvailable_ReturnsTrue()
        {
            BookingManager manager = CreateBookingManager();
            DateTime date = DateTime.Today.AddDays(21);
            Booking b = new Booking { StartDate = date, EndDate = date, };
            bool result = manager.CreateBooking(b);
            Assert.IsTrue(result);
        }


        private BookingManager CreateBookingManager()
        {
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            List<Booking> bookings = new List<Booking>
            {
                new Booking { Id=1, StartDate=start, EndDate=end, IsActive=true, CustomerId=1, RoomId=1 },
                new Booking { Id=2, StartDate=start, EndDate=end, IsActive=true, CustomerId=2, RoomId=2 },
            };

            List<Room> rooms = new List<Room>
            {
                new Room { Id = 1 },
                new Room { Id = 2 }
            };

            // Create a fake BookingRepository using NSubstitute
            IRepository<Booking> bookingRepository = Substitute.For<IRepository<Booking>>();

            // Set a return value for GetAll() 
            bookingRepository.GetAll().Returns(bookings);

            // Set a return value for Get() - not used
            bookingRepository.Get(2).Returns(bookings[1]);
            bookingRepository.Get(Arg.Any<int>()).Returns(bookings[1]);

            // Create a fake RoomRepository using NSubstitute
            IRepository<Room> roomRepository = Substitute.For<IRepository<Room>>();
            // Set a return value for GetAll() 
            roomRepository.GetAll().Returns(rooms);

            return new BookingManager(bookingRepository, roomRepository);
        }
    }
}
