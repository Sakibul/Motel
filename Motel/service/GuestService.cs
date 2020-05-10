using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motel.service
{
    class GuestService
    {
        public List<Guest> GetAllGuests()
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                var query = from guest in dbContext.Guests
                            select guest;

                return query.ToList<Guest>();
            }
        }

        public void AddGuest(Guest guest)
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                dbContext.Guests.Add(guest);
                dbContext.SaveChanges();
            }
        }

        public bool EditGuest(Guest guestWithNewValues)
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                var query = from guest in dbContext.Guests
                            where guest.GuestId == guestWithNewValues.GuestId
                            select guest;

                Guest selectedGuest = query.First(); // I know the Guest exists
                // ***************************************
                /*
                selectedGuest.Type = guestWithNewValues.Type;
                selectedGuest.NoOfBeds = guestWithNewValues.NoOfBeds;
                selectedGuest.Availability = guestWithNewValues.Availability;
                selectedGuest.RatePerDay = guestWithNewValues.RatePerDay;
                */
                // ***************************************
                // dbContext.Guests.Remove(selectedCustomer);
                dbContext.SaveChanges();
                // ***************************************
                // dbContext.Guests.Add(selectedGuest);
                // dbContext.SaveChanges();
                // ***************************************
            }
            return true;
        }
    }
}
