using RPSBackendLogic.Data;
using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RPSFight.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //public ICommand AddRoshambo;
        //public ICommand startBattle;
        //public ICommand resultsCommand;

        private readonly IDataStoreRepo dataStore;
        IDataStoreRepo DataStore => dataStore;

        GameBoard tehGameBoard;

        public ObservableCollection<Roshambo> PlayerRoshambos { get; set; }
        public ObservableCollection<Roshambo> EnemyRoshambos { get; set; }
        public ObservableCollection<Name> WinLog { get; set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            dataStore = context;
            PlayerRoshambos = new ObservableCollection<Roshambo>();
            EnemyRoshambos = new ObservableCollection<Roshambo>();
            WinLog = new ObservableCollection<Name>();
            tehGameBoard = new GameBoard();

            EnemyRoshambos.Add(new Roshambo("Baracuda", new Rock(5), new Paper(4), new Scissors(1)));
            EnemyRoshambos.Add(new Roshambo("Carmichael", new Rock(2), new Paper(7), new Scissors(3)));
            EnemyRoshambos.Add(new Roshambo("Shcali", new Rock(20), new Paper(13), new Scissors(17)));
            GetPlayerRoshambos();
            GetEnemyRoshambos();
        }
        private void GetPlayerRoshambos()
        {
            var Roshambos = DataStore.GetAllRoshambos().GetEnumerator();
            while (Roshambos.MoveNext())
            {
                var cur = Roshambos.Current;
                if (!cur.Enemy && !CheckId(cur.Id.Value, false))
                    PlayerRoshambos.Add(cur);
            }
        }
        private void GetEnemyRoshambos()
        {
            var Roshambos = DataStore.GetAllRoshambos().GetEnumerator();
            while (Roshambos.MoveNext())
            {
                var cur = Roshambos.Current;
                if (cur.Enemy && !CheckId(cur.Id.Value))
                    EnemyRoshambos.Add(cur);
            }
        }
        private bool CheckId(int id, bool enemy = true)
        {
            bool value = false;
            IEnumerator<Roshambo> loop;
            if (enemy)
                loop = EnemyRoshambos.GetEnumerator();
            else
                loop = PlayerRoshambos.GetEnumerator();
            while(loop.MoveNext())
            {
                var cur = loop.Current;
                if (cur.Id == id)
                {
                    value = true;
                    break;
                }
            }
            return value;
        }

        public Roshambo PlayerRoshambo { get; set; }
        public Roshambo EnemyRoshambo { get; set; }

        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set { SetField(ref playerName, value); }
        }

        private int playerRocks;
        public int PlayerRocks
        {
            get { return playerRocks; }
            set { SetField(ref playerRocks, value); }
        }

        private int playerPapers;
        public int PlayerPapers
        {
            get { return playerPapers; }
            set { SetField(ref playerPapers, value); }
        }

        private int playerScissors;
        public int PlayerScissors
        {
            get { return playerScissors; }
            set { SetField(ref playerScissors, value); }
        }

        private string enemyName;
        public string EnemyName
        {
            get { return enemyName; }
            set { SetField(ref enemyName, value); }
        }

        private int enemyRocks;
        public int EnemyRocks
        {
            get { return enemyRocks; }
            set { SetField(ref enemyRocks, value); }
        }

        private int enemyPapers;
        public int EnemyPapers
        {
            get { return enemyPapers; }
            set { SetField(ref enemyPapers, value); }
        }

        private int enemyScissors;
        public int EnemyScissors
        {
            get { return enemyScissors; }
            set { SetField(ref enemyScissors, value); }
        }

        private Roshambo winner;
        public Roshambo Winner
        {
            get { return winner; }
            set { SetField(ref winner, value); }
        }

        //private Command removePlayer;
        //public Command RemovePlayerCmd => removePlayer ?? (removePlayer = new Command(() =>
        //{

        //}));

        private Command saveEnemy;
        public Command SaveEnemyCmd => saveEnemy ?? (saveEnemy = new Command(() =>
        {
            try
            {
                var newRo = new Roshambo(new Name(EnemyName), new Rock(EnemyRocks), new Paper(EnemyPapers), new Scissors(EnemyScissors));
                DataStore.Add(newRo);
                GetEnemyRoshambos();
                //EnemyRoshambos.Add(newRo);
                EnemyName = "";
                EnemyRocks = EnemyPapers = EnemyScissors = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Values" + e.Message);
            }
        }));

        private Command removeEnemy;
        public Command RemoveEnemyCmd => removeEnemy ?? (removeEnemy = new Command(() =>
        {
            try
            {
                if (EnemyRoshambo != null && EnemyRoshambo.Id != 0)
                {
                    DataStore.Remove(EnemyRoshambo);
                    EnemyRoshambos.Remove(EnemyRoshambo);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Removing enemy" + e.Message);
            }
        }));

        private Command savePlayer;
        public Command SavePlayerCmd => savePlayer ?? (savePlayer = new Command(() =>
        {
            try
            {
                var newRo = new Roshambo(new Name(PlayerName), new Rock(PlayerRocks), new Paper(PlayerPapers), new Scissors(PlayerScissors), false);
                DataStore.Add(newRo);
                GetPlayerRoshambos();
                //PlayerRoshambos.Add(newRo);
                PlayerName = "";
                PlayerRocks = PlayerPapers = PlayerScissors = 0;
            } catch(Exception e)
            {
                Console.WriteLine("Values" + e.Message);
            }
        }));

        private Command removePlayer;
        public Command RemovePlayerCmd => removePlayer ?? (removePlayer = new Command(() =>
        {
            try
            {
                if (PlayerRoshambo != null && PlayerRoshambo.Id != 0)
                {
                    DataStore.Remove(PlayerRoshambo);
                    PlayerRoshambos.Remove(PlayerRoshambo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Removing enemy" + e.Message);
            }
        }));

        private Command startGame;
        public Command StartGameCmd => startGame ?? (startGame = new Command(() =>
        {
            if (PlayerRoshambo != null && EnemyRoshambo != null)
            {
                tehGameBoard.Player = PlayerRoshambo;
                tehGameBoard.Enemy = EnemyRoshambo;
                Winner = tehGameBoard.GameStart();
                var temp = tehGameBoard.WinLog.GetEnumerator();
                WinLog.Clear();
                while (temp.MoveNext())
                {
                    WinLog.Add(temp.Current);
                }
            }
        }));

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