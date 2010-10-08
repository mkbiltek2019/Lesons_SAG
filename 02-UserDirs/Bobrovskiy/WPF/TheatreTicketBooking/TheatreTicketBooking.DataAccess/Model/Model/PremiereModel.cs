using TheatreTicketBooking.Client.Entities;
using System.Collections.ObjectModel;
using TheatreTicketBooking.Business;

namespace TheatreTicketBooking.Client.Model
{
    public class PremiereModel
    {
        private ObservableCollection<Premiere> _premieres;
        public ObservableCollection<Premiere> Premieres
        {
            get
            {
                return _premieres;
            }
        }

        public void CleareAllPremieres()
        {
            _premieres.Clear();
        }

        public void LoadPremieresList()
        {
            TicketManager manager = new TicketManager();
            _premieres = new ObservableCollection<Premiere>(manager.GetData());

            //_premieres.Add(new Premiere { Genre = "Drama1", Name = "Good Drama1", Price = 12 });
            //_premieres.Add(new Premiere { Genre = "Comedy2", Name = "Bad Commedy2", Price = 120 });
            //_premieres.Add(new Premiere { Genre = "Drama3", Name = "Good Drama3", Price = 2 });
            //_premieres.Add(new Premiere { Genre = "Comedy4", Name = "Bad Commedy4", Price = 120 });
            //_premieres.Add(new Premiere { Genre = "Drama5", Name = "Good Drama5", Price = 12 });
            //_premieres.Add(new Premiere { Genre = "Comedy6", Name = "Bad Commedy6", Price = 120 });
            //_premieres.Add(new Premiere { Genre = "Drama7", Name = "Good Drama7", Price = 12 });
            //_premieres.Add(new Premiere { Genre = "Comedy8", Name = "Bad Commedy8", Price = 120 });
        }

    }
}
