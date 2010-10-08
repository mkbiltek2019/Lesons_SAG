using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using TheatreTicketBooking.Business;
using TheatreTicketBooking.Client.Model;
using TheatreTicketBooking.Client.Entities;


namespace TheatreTicketBooking.Client.ViewModel
{
    public class PremiereViewModel : ViewModelBase, IAllTicketViewer
    {
        private TheatreTicketBooking.Client.Model.PremiereModel _premiereModel;

        public ObservableCollection<Premiere> AllPremiere
        {
            get
            {
                return _premiereModel.Premieres;
            }
        }

        public PremiereViewModel()
        {
            _premiereModel = new PremiereModel();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadPremiereCommand = new RelayCommand(ShowPremiereList);
            ClearPremiereListCommand = new RelayCommand(ClearPremiereList);
        }

        public RelayCommand LoadPremiereCommand { get; set; }
        public RelayCommand ClearPremiereListCommand { get; set; }

        public void ClearPremiereList()
        {
            _premiereModel.CleareAllPremieres();
            RaisePropertyChanged("AllPremiere");
        }

        public void ShowPremiereList()
        {
            _premiereModel.LoadPremieresList();
            RaisePropertyChanged("AllPremiere");
        }
    }
}
