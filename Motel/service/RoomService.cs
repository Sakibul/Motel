using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motel.service
{
    class RoomService
    {
        public List<Room> GetAllRooms()
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                var query = from room in dbContext.Rooms
                            select room;

                return query.ToList<Room>();
            }
        }

        public void AddRoom(Room room)
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
            }
        }

        public bool EditRoom(Room roomWithNewValues)
        {
            using (MotelDBEntities dbContext = new MotelDBEntities())
            {
                var query = from room in dbContext.Rooms
                            where room.RoomId == roomWithNewValues.RoomId
                            select room;

                Room selectedRoom = query.First(); // I know the Room exists
                // ***************************************
                selectedRoom.Type = roomWithNewValues.Type;
                selectedRoom.NoOfBeds = roomWithNewValues.NoOfBeds;
                selectedRoom.Availability = roomWithNewValues.Availability;
                selectedRoom.RatePerDay = roomWithNewValues.RatePerDay;
                // ***************************************
                // dbContext.Rooms.Remove(selectedCustomer);
                dbContext.SaveChanges();
                // ***************************************
                // dbContext.Rooms.Add(selectedRoom);
                // dbContext.SaveChanges();
                // ***************************************
            }
            return true;
        }
    }
}