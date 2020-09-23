using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MandalorianDB.BusinessLayer;
using MandalorianDB.DataLayer;
using MandalorianDB.Model;

namespace MandalorianDB.ViewModel
{

    class JessViewModel : ObservableObject
    {
        #region Commands
        public ICommand SearchEpisodeCommand { get; set; }

        public ICommand AddEpisodeCommand { get; set; }

        public ICommand DeleteEpisodeCommand { get; set; }


        public ICommand QuitApplicationCommand { get; set; }


        public ICommand SortAscending { get; set; }
        public ICommand SortListByDirectorCommand { get; set; }
        #endregion

        #region Field
        private ObservableCollection<Episode> _episodes;
        private Episode _selectedEpisode;
        private Episode _episodeToAdd;
        private Episode _episodeToSearch;
        public  JessViewModel()
        {
            Episodes = new ObservableCollection<Episode>(SessionData.GetEpisodeList());
            if (Episodes.Any()) SelectedEpisode = Episodes[0];
      
           //ButtonAddCommand = new RelayCommand(new Action<object>(EpisodeToAdd()));
           // ButtonEditCommand = new RelayCommand(new Action<object>(EditEpisode()));
            SortAscending = new RelayCommand(new Action<object>(SortAsc));
            // RadioCommandSortDesc = new RelayCommand(new Action<object>(SortDesc));
            SortListByDirectorCommand = new RelayCommand(new Action<object>(OnSortListByDirector));
            //ButtonSearchCommand = new RelayCommand(new Action<object>(Search));
            QuitApplicationCommand = new RelayCommand(new Action<object>(OnQuitApplication));
         }
        #endregion

        #region Properties
        public ObservableCollection<Episode> Episodes
        {
            get { return _episodes; }
            set { _episodes = value; }
        }

        public Episode SelectedEpisode
        {
            get { return _selectedEpisode; }
            set
            {
                if (_selectedEpisode == value) { return; }
                _selectedEpisode = value;
                OnPropertyChanged(nameof(SelectedEpisode));
            }
        }
        public Episode EpisodeToAdd
        {
            get { return _episodeToAdd; }
            set
            {
                _episodeToAdd = value;
                OnPropertyChanged(nameof(EpisodeToAdd));
            }

        }
        public Episode EpisodeToSearch
        {
            get { return _episodeToSearch; }
            set { _episodeToSearch = value; }
        }

        #endregion

        #region Method
        private void OnSearchEpisode()
        {
           
          
        }
        private void OnAddEpisode()
        {

        }
        private void OnDeleteEpisode()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you Sure you want to delete {_selectedEpisode}", "Deleted Episode", System.Windows.MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                _episodes.Remove(_selectedEpisode);
            }
        }
        private void OnQuitApplication(object parameter)
        {
            //
            // call a house keeping method in the business class
            //
            System.Environment.Exit(1);
        }
        private void SortAsc(object parameter)
        {
            Episodes = new ObservableCollection<Episode>(Episodes.OrderBy(x => x.EpisodeNumber).ToList());


        }
        private void OnSortListByDirector(Object parameter)
        {
            Episodes = new ObservableCollection<Episode>(Episodes.OrderBy(x => x.Director).ToList());
        }
        #endregion
      
       

    }
}
