﻿using RPSBackendLogic.Data;
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

        public ObservableCollection<Roshambo> EnemyRoshambos { get; set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            string testingString = "test";
            PlayerRocksFunction = testingString;

            dataStore = context;
            EnemyRoshambos = new ObservableCollection<Roshambo>();
            //Roshambos = DataStore.GetAllRoshambos();

            EnemyRoshambos.Add(new Roshambo("Baracuda", new Rock(5), new Paper(4), new Scissors(1)));
            EnemyRoshambos.Add(new Roshambo("Carmichael", new Rock(2), new Paper(7), new Scissors(3)));
            EnemyRoshambos.Add(new Roshambo("Shcali", new Rock(20), new Paper(13), new Scissors(17)));
        }

        private string PlayerRocks;
        public string PlayerRocksFunction
        {
            get { return PlayerRocks; }
            set { SetField(ref PlayerRocks, value); }
        }

        private string PlayerPapers;
        public string PlayerPapersFunction
        {
            get { return PlayerPapers; }
            set { SetField(ref PlayerPapers, value); }
        }

        private string PlayerScissors;
        public string PlayerScissorsFunction
        {
            get { return PlayerScissors; }
            set { SetField(ref PlayerScissors, value); }
        }

        private string EnemyRocks;
        public string EnemyRocksFunction
        {
            get { return EnemyRocks; }
            set { SetField(ref EnemyRocks, value); }
        }

        private string EnemyPapers;
        public string EnemyPapersFunction
        {
            get { return EnemyPapers; }
            set { SetField(ref EnemyPapers, value); }
        }

        private string EnemyScissors;
        public string EnemyScissorsFunction
        {
            get { return EnemyScissors; }
            set { SetField(ref EnemyScissors, value); }
        }

        private string Winner;
        public string WinnerFunction
        {
            get { return Winner; }
            set { SetField(ref Winner, value); }
        }

        public ICommand StartBattle => startBattle ?? (resultsCommand = new SimpleCommand(
            () =>
            {

                Console.WriteLine("We started an attack");
            }
            ));

        //public Roshambo RandomRoshambo()
        //{
        //    Roshambo tempRoshambo = new Roshambo();



        //    return tempRoshambo;
        //}


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