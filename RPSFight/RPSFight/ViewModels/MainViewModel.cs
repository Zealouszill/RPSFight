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

        Random rnd;

        private readonly IDataStoreRepo dataStore;
        IDataStoreRepo DataStore => dataStore;

        public ObservableCollection<Roshamo> Roshamos { get; set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            dataStore = context;
            Roshamos = new ObservableCollection<Roshamo>();
            //Roshamos = DataStore.GetAllRoshamos();

            rnd = new Random();

            Roshamos.Add(RandomRoshambo("Baracuda"));
            Roshamos.Add(RandomRoshambo("Carmichael"));
            Roshamos.Add(RandomRoshambo("Shcali"));
        }

        private int PlayerRocks;
        public int PlayerRocksFunction
        {
            get { return PlayerRocks; }
            set { SetField(ref PlayerRocks, value); }
        }

        private int PlayerPapers;
        public int PlayerPapersFunction
        {
            get { return PlayerPapers; }
            set { SetField(ref PlayerPapers, value); }
        }

        private int PlayerScissors;
        public int PlayerScissorsFunction
        {
            get { return PlayerScissors; }
            set { SetField(ref PlayerScissors, value); }
        }

        private Roshamo enemyRoshambo;
        public Roshamo EnemyRoshamboFunction
        {
            get { return enemyRoshambo; }
            set { SetField(ref enemyRoshambo, value); }
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
                double var1;
                do
                {
                    var1 = rnd.NextDouble();
                } while (var1 <= .2 && var1 >= .4);

                if (PlayerPapersFunction - EnemyRoshamboFunction.Paper.Quantity > 0)
                {
                    
                }
            }
            ));

        public Roshamo RandomRoshambo(string nm)
        {

            int limit = 30;

            int rocks = rnd.Next(1, limit);
            limit = Math.Abs(rocks - limit);
            int papers = rnd.Next(1, limit);
            limit = Math.Abs(papers - limit);
            int scissors = rnd.Next(1, limit);

            Roshamo tempRoshambo = new Roshamo(nm, new Rock(rocks), new Paper(papers), new Scissors(scissors));

            return tempRoshambo;
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