using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheatreTicketBooking.Client.Entities;
using System.Collections.ObjectModel;

namespace TheatreTicketBooking.Client.Model
{
    public class PremiereModel
    {
        private ObservableCollection<Primiere> _premieres;
        public ObservableCollection<Primiere> Premieres
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
            _premieres = new ObservableCollection<_premieres>();
            _premieres.Add(new Primiere { Genre = "Drama1", Name = "Good Drama1", Price = "12.453", Description = "some thing is very good" });
            _premieres.Add(new Primiere { Genre = "Comedy2", Name = "Bad Commedy2", Price = "120.453" });
            _premieres.Add(new Primiere { Genre = "Drama3", Name = "Good Drama3", Price = "12.453" });
            _premieres.Add(new Primiere { Genre = "Comedy4", Name = "Bad Commedy4", Price = "120.453" });
            _premieres.Add(new Primiere { Genre = "Drama5", Name = "Good Drama5", Price = "12.453" });
            _premieres.Add(new Primiere { Genre = "Comedy6", Name = "Bad Commedy6", Price = "120.453" });
            _premieres.Add(new Primiere { Genre = "Drama7", Name = "Good Drama7", Price = "12.453" });
            _premieres.Add(new Primiere { Genre = "Comedy8", Name = "Bad Commedy8", Price = "120.453" });
        }
        
    }
}
