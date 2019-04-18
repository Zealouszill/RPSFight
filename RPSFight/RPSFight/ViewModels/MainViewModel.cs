using RPSBackendLogic.Data;
using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Entities;
using RPSBackendLogic.Exceptions;
using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public ObservableCollection<Log> Log { get; set; }
        public ObservableCollection<Sentence> WinLog { get; private set; }

        public MainViewModel(RPSDataStorage.Data.DataStoreRepo context)
        {
            dataStore = context;
            PlayerRoshambos = new ObservableCollection<Roshambo>();
            EnemyRoshambos = new ObservableCollection<Roshambo>();
            WinLog = new ObservableCollection<Sentence>();
            Log = new ObservableCollection<Log>();
            tehGameBoard = new GameBoard(dataStore);

            EnemyRoshambos.Add(new Roshambo("Baracuda", new Rock(5), new Paper(4), new Scissors(1)));
            EnemyRoshambos.Add(new Roshambo("Carmichael", new Rock(2), new Paper(7), new Scissors(3)));
            EnemyRoshambos.Add(new Roshambo("Shcali", new Rock(20), new Paper(13), new Scissors(17)));
            GetPlayerRoshambos();
            GetEnemyRoshambos();
        }
        private void GetPlayerRoshambos()
        {
            foreach(var cur in DataStore.GetAllRoshambos())
            {
                if (!cur.Enemy && !CheckId(cur.Id.Value, false))
                    PlayerRoshambos.Add(cur);
            }
        }
        private void GetEnemyRoshambos()
        {
            foreach(var cur in DataStore.GetAllRoshambos())
            {
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

        /******************************************************
         *                   Roshambo Values                  *
         *****************************************************/

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
            set {
                SetField(ref enemyRocks, value); }
        }

        private int enemyPapers;
        public int EnemyPapers
        {
            get { return enemyPapers; }
            set { SetField(ref enemyPapers,value); }
        }

        private int enemyScissors;
        public int EnemyScissors
        {
            get { return enemyScissors; }
            set { SetField(ref enemyScissors,value); }
        }

        private Roshambo winner;
        public Roshambo Winner
        {
            get { return winner; }
            set { SetField(ref winner, value); }
        }

        /******************************************************
         *                    Modifiers                       *
         *****************************************************/

        private int rkVsSs;
        public int RkVsSs
        {
            get { return rkVsSs; }
            set { SetField(ref rkVsSs, value); }
        }

        private int rkVsPp;
        public int RkVsPp
        {
            get { return rkVsPp; }
            set { SetField(ref rkVsPp, value); }
        }

        private int ssVsRk;
        public int SsVsRk
        {
            get { return ssVsRk; }
            set { SetField(ref ssVsRk, value); }
        }

        private int ssVsPp;
        public int SsVsPp
        {
            get { return ssVsPp; }
            set { SetField(ref ssVsPp, value); }
        }

        private int ppVsRk;
        public int PpVsRk
        {
            get { return ppVsRk; }
            set { SetField(ref ppVsRk, value); }
        }

        private int ppVsSs;
        public int PpVsSs
        {
            get { return ppVsSs; }
            set { SetField(ref ppVsSs, value); }
        }

        /******************************************************
         *                     Commands                       *
         *****************************************************/

        private Command showLog;
        public Command ShowLogCmd => showLog ?? (showLog = new Command(() =>
        {
            DataStore.Add(new Log("User requested to show log."));
            Log.Clear();
            foreach(var cur in DataStore.GetAllLogEntries())
                Log.Add(cur);
        }));

        private Command saveEnemy;
        public Command SaveEnemyCmd => saveEnemy ?? (saveEnemy = new Command(() =>
        {
            try
            {
                var newRo = new Roshambo(new Name(EnemyName), new Rock(EnemyRocks), new Paper(EnemyPapers), new Scissors(EnemyScissors));
                DataStore.Add(newRo);
                GetEnemyRoshambos();
                //EnemyRoshambos.Add(newRo);
                DataStore.Add(new Log("User saved an enemy named: " + EnemyName));
                EnemyName = "";
                EnemyRocks = EnemyPapers = EnemyScissors = 0;
            }
            catch (InvalidStringLengthException e)
            {
                DataStore.Add(new Log("Invalid name-length when saving enemy player. Message: " + e.Message));
                ErrorMessager("The length of the enemy name is too short or too long. Please pick a new name.");
            }
            catch (InvalidValueException e)
            {
                DataStore.Add(new Log("Invalid value when saving enemy player. Message: " + e.Message));
                ErrorMessager("You have placed an invalid value for the enemy player. Pick an appropriate value.");
            }
            catch (Exception e)
            {
                DataStore.Add(new Log("System Exception. Message: " + e.Message));
                ErrorMessager("Error: " + e.Message + " Please try again.");
            }
        }));

        private Command removeEnemy;
        public Command RemoveEnemyCmd => removeEnemy ?? (removeEnemy = new Command(() =>
        {
            try
            {
                if (EnemyRoshambo != null && EnemyRoshambo.Id != 0)
                {
                    DataStore.Add(new Log("User removed an enemy named: " + EnemyRoshambo.Name));
                    DataStore.Remove(EnemyRoshambo);
                    EnemyRoshambos.Remove(EnemyRoshambo);
                    EnemyRoshambo = null;
                }
            }catch(Exception e)
            {
                DataStore.Add(new Log("System Exception when trying to remove enemy player. Message: " + e.Message));
                ErrorMessager("Unable to remove enemy player.");
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
                DataStore.Add(new Log("User saved a player named: " + PlayerName));
                PlayerName = "";
                PlayerRocks = PlayerPapers = PlayerScissors = 0;
            }
            catch (InvalidStringLengthException e)
            {
                DataStore.Add(new Log("Invalid name-length when saving player. Message: " + e.Message));
                ErrorMessager("The length of the player name is too short. Please pick a new name.");
            }
            catch (InvalidValueException e)
            {
                DataStore.Add(new Log("Invalid value when saving player. Message: " + e.Message));
                ErrorMessager("You have placed an invalid value for the player player. Pick an appropriate value.");

            }
            catch (Exception e)
            {
                DataStore.Add(new Log("System Exception. Message: " + e.Message));
                ErrorMessager("Error: " + e.Message + " Please try again.");
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
                    DataStore.Add(new Log("User removed a player named: " + PlayerRoshambo.Name));
                    PlayerRoshambos.Remove(PlayerRoshambo);
                    PlayerRoshambo = null;
                }
            }
            catch (Exception e)
            {
                DataStore.Add(new Log("System Exception when trying to remove player. Message: " + e.Message));
                ErrorMessager("Unable to remove player.");

            }
        }));

        private Command startGame;
        public Command StartGameCmd => startGame ?? (startGame = new Command(() =>
        {
            
            try
            {
                int playerQuantityTotal = PlayerRoshambo.Rock.Quantity + PlayerRoshambo.Paper.Quantity + PlayerRoshambo.Scissors.Quantity;
                int enemyQuantityTotal = EnemyRoshambo.Rock.Quantity + EnemyRoshambo.Paper.Quantity + EnemyRoshambo.Scissors.Quantity;

                if (enemyQuantityTotal <= 0)
                    throw new InvalidOperationException("Please select an enemy with quantity that is more than 0.");

                if (playerQuantityTotal <= 0)
                    throw new InvalidOperationException("Please select a player with quantity that is more than 0.");

                ModifierSet tempVar = new ModifierSet(RkVsSs, RkVsPp, SsVsRk, SsVsPp, PpVsRk, PpVsSs);


                if (PlayerRoshambo != null && EnemyRoshambo != null)
                {
                    tehGameBoard.Player = PlayerRoshambo;
                    tehGameBoard.Enemy = EnemyRoshambo;
                    //tehGameBoard.UserModifiers.Add();
                    Winner = tehGameBoard.GameStart();
                    DataStore.Add(new Log("User started the game with player: " + PlayerRoshambo.Name.Value + " and enemy: " + EnemyRoshambo.Name.Value + ". Winner: " + Winner.Name.Value));
                    var temp = tehGameBoard.WinLog.GetEnumerator();
                    WinLog.Clear();
                    while (temp.MoveNext())
                    {
                        WinLog.Add(temp.Current);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                DataStore.Add(new Log("Player or enemy have zero quanties for rock, scissor, and paper."));
                ErrorMessager(e.Message);
            }
            catch (NullReferenceException)
            {
                DataStore.Add(new Log("No player or-and enemy selected."));
                ErrorMessager("Please select your combatants");
            }
            catch (Exception ex)
            {
                DataStore.Add(new Log("Cannot use user modifiers more than once per game."));
                ErrorMessager(ex.Message);
            }
        }));

        //public void testIfString<T>(ref T var)
        //{
        //    string aString = "string";
            

        //    if (var.GetType() == aString.GetType())
        //    {

        //    }
        //}

        public void ErrorMessager(string messageBox)
        {
            
            Xamarin.Forms.Page ourPage = App.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (ourPage != null)
            {
                ourPage.DisplayAlert("Error", messageBox, "Ok");
            }
            
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