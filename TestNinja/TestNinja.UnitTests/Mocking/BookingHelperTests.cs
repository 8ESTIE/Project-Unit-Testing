using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class BookingHelperTests
    {
        Mock<IUnitOfWork> _unitOfWork;
        Booking _booking;
        string _ref = "ref";
        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }
        [Test]
        public void OverlappingBookingsExist_CancelledBookingPassed_ReturnEmptyString()
        {
            _booking = new Booking() { Status = "Cancelled" };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.Empty);
        }
        [Test]
        public void OverlappingBookingsExist_AllCancelledBooking_ReturnEmptyString()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking { Status = "Cancelled" } }.AsQueryable());
            _booking = new Booking();
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.Empty);
        }
        [Test]
        public void OverlappingBookingsExist_AllSameIdBooking_ReturnEmptyString()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking { Id = 0 } }.AsQueryable());
            _booking = new Booking() { Id = 0 };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.Empty);
        }
        [Test]
        public void OverlappingBookingsExist_PassedBookingArrivesInBusyIntervals_ReturnOverlappingBookings()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking {
                ArrivalDate=new DateTime(1,1,1),
                DepartureDate = new DateTime(1, 1, 3),
                Reference=_ref,
                Id = 1
            }}.AsQueryable());
            _booking = new Booking() { ArrivalDate = new DateTime(1, 1, 2) };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.EqualTo(_ref));
        }
        [Test]
        public void OverlappingBookingsExist_PassedBookingDeparturesInBusyIntervals_ReturnOverlappingBookings()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking { 
                ArrivalDate = new DateTime(1, 1, 1), 
                DepartureDate = new DateTime(1, 1, 3), 
                Reference = _ref,
                Id=1
            }}.AsQueryable());
            _booking = new Booking() { DepartureDate = new DateTime(1, 1, 2) };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.EqualTo(_ref));
        }
        [Test]
        public void OverlappingBookingsExist_PassedBookingArrivesOutOfBusyIntervals_ReturnEmptyString()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking { ArrivalDate = new DateTime(1, 1, 2), DepartureDate = new DateTime(1, 1, 3) } }.AsQueryable());
            _booking = new Booking() { ArrivalDate = new DateTime(1, 1, 1) };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.Empty);
        }
        [Test]
        public void OverlappingBookingsExist_PassedBookingDeparturesOutOfBusyIntervals_ReturnEmptyString()
        {
            _unitOfWork.Setup(uof => uof.Query<Booking>()).Returns(new List<Booking>() { new Booking { ArrivalDate = new DateTime(1, 1, 2), DepartureDate = new DateTime(1, 1, 3) } }.AsQueryable());
            _booking = new Booking() { ArrivalDate = new DateTime(1, 1, 1) };
            Assert.That(BookingHelper.OverlappingBookingsExist(_unitOfWork.Object, _booking), Is.Empty);
        }
    }
}