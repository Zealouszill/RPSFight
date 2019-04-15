using RPSBackendLogic.Data;
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

        private readonly IDataStoreRepo dataStore;
        IDataStoreRepo DataStore => dataStore;

        public ObservableCollection<Roshamo> Roshamos { get; set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            string testString = "test";
            testStringFunction = testString;
        }

        private string testString;
        public string TestStringFunction
        {
            get { return testString; }
            set { SetField(ref testString, value); }
        }

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