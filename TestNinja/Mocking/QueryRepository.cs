using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public static class QueryRepository
    {
        public static string OverlappingBookings(IUnitOfWork unitOfWork, Booking booking)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate <= b.DepartureDate
                        && booking.DepartureDate >= b.ArrivalDate);
            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}