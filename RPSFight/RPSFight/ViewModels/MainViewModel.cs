using RPSBackendLogic.Data;
using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RPSFight.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand AddRoshambo;
        public ICommand startBattle;
        public ICommand resultsCommand;

        private readonly IDataStoreRepo dataStore;
        IDataStoreRepo DataStore => dataStore;

        public ObservableCollection<Roshamo> Roshamos { get; set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            string testingString = "test";
            TestStringFunction = testingString;

            dataStore = context;
            Roshamos = new ObservableCollection<Roshamo>();
            //Roshamos = DataStore.GetAllRoshamos();
            Roshamos.Add(new Roshamo("Baracuda", new Rock(), new Paper(), new Scissors()));
        }

        private string testString;
        public string TestStringFunction
        {
            get { return testString; }
            set { SetField(ref testString, value); }
        }


        public ICommand StartBattle => startBattle ?? (resultsCommand = new SimpleCommand(
            () =>
            {

                Console.WriteLine("We started an attack");
            }
            ));

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }

}