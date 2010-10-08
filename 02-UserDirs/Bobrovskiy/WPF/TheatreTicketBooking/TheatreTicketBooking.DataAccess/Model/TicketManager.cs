using System.Collections.Generic;
using System.Linq;
using TheatreTicketBooking.DataAccess;

namespace TheatreTicketBooking.Business
{
    public class TicketManager
    {
        private TicketBookingEntities dataEntity;

        public void SubTicket(TheatreTicketBooking.Client.Entities.Premiere current)
        {
            foreach (Premiere cur in dataEntity.Premiere.Where(cur => cur.PremiereID == current.ID))
            {
                cur.TicketCapacity = current.TicketCount - 1; 
            }

            dataEntity.SaveChanges();
        }

        public TicketManager()
        {
            dataEntity = new TicketBookingEntities();
        }

        public List<TheatreTicketBooking.Client.Entities.Premiere> GetData()
        {
            List<TheatreTicketBooking.Client.Entities.Premiere> current = 
                                new List<TheatreTicketBooking.Client.Entities.Premiere>();

            var premiere = from p in dataEntity.Premiere
                           from g in dataEntity.Genre
                           where p.GenreID == g.GenreID
                           select new 
                               { Genre = g.Name, 
                                   p.Name, 
                                   p.Price, 
                                   p.PremiereID, 
                                   p.TicketCapacity 
                               };

            foreach (var data in premiere)
            {
                current.Add(new TheatreTicketBooking.Client.Entities.Premiere()
                                 {
                                     Genre = data.Genre,
                                     Name = data.Name,
                                     Price = data.Price,
                                     ID = data.PremiereID,
                                     TicketCount = data.TicketCapacity
                                 });
            }

            return current;
        }



    }
}
