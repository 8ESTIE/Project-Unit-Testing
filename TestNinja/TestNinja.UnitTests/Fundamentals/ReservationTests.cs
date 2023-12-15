using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnTrue()
        {
            Reservation reservation = new Reservation();

            bool result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.IsTrue(result);
        }
        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            User user = new User();
            Reservation reservation = new Reservation() { MadeBy = user };

            bool result = reservation.CanBeCancelledBy((user));

            Assert.IsTrue(result);
        }
        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            Reservation reservation = new Reservation();

            bool result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
