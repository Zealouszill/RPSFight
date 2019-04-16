﻿using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.Exceptions;
using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RPSBackendLogic.Entities
{
    public class GameBoard
    {
        public Roshambo Player { get; set; }
        public Roshambo Enemy { get; set; }
        public Quantity GameLength { get; set; }
        private Random rnd;
        private bool[] PlayerWins { get; set; }
        private int[] enemyQ;
        private int count;
        public ObservableCollection<Name> WinLog { get; set; }

        public GameBoard()
        {
            rnd= new Random();
            GameLength = 20;
            WinLog = new ObservableCollection<Name>();
        }

        public Roshambo GameStart()
        {
            try
            {
                WinLog.Clear();
                count = 0;
                PlayerWins = new bool[GameLength];
                enemyQ = new int[3] { Enemy.Rock.Quantity, Enemy.Paper.Quantity, Enemy.Scissors.Quantity };
                var playerQ = new int[3] { Player.Rock.Quantity, Player.Paper.Quantity, Player.Scissors.Quantity };
                for (int i = 0; i < GameLength; i++)
                {
                    int participant = NewEnemy();
                    // 1, 2, 3 -> 2
                    if (playerQ[0] != 0)
                    {
                        if (participant == 1)
                            WinLog.Add("Player Rock vs Enemy Paper - " + Combat(Player.Rock.ModPaper, Enemy.Paper.ModRock).ToString());

                        else if (participant == 2)
                            WinLog.Add("Player Rock vs Enemy Scissors - " + Combat(Player.Rock.ModScissor, Enemy.Scissors.ModRock).ToString());
                        else
                            WinLog.Add("Player Rock vs Enemy Paper - " + Combat(0, 0).ToString());
                        playerQ[0] -= 1;
                    }
                    else if (playerQ[1] != 0)
                    {
                        if (participant == 0)
                            WinLog.Add("Player Paper vs Enemy Rock - " + Combat(Player.Paper.ModRock, Enemy.Rock.ModPaper).ToString());
                        else if (participant == 2)
                            WinLog.Add("Player Paper vs Enemy Scissor - " + Combat(Player.Paper.ModScissor, Enemy.Scissors.ModPaper).ToString());
                        else
                            WinLog.Add("Player Paper vs Enemy Paper - " + Combat(0, 0).ToString());
                        playerQ[1] -= 1;
                    }
                    else
                    {
                        if (participant == 0)
                            WinLog.Add("Player Scissor vs Enemy Rock - " + Combat(Player.Scissors.ModRock, Enemy.Rock.ModScissor).ToString());
                        else if (participant == 1)
                            WinLog.Add("Player Scissor vs Enemy Scissor - " + Combat(Player.Scissors.ModPaper, Enemy.Paper.ModScissor).ToString());
                        else
                            WinLog.Add("Player Scissor vs Enemy Paper - " + Combat(0, 0).ToString());
                        playerQ[2] -= 1;
                    }
                }
            }
            catch (InvalidStringLengthException e) { }
            int wincount = 0;
            for (int i = 0; i < PlayerWins.Length; i++)
            {
                if (PlayerWins[i])
                    wincount++;
            }
            if (wincount >= (GameLength / 2))
                return Player;
            else
                return Enemy;
        }
        private int NewEnemy()
        {
            if(enemyQ[0] != 0)
            {
                enemyQ[0] -= 1;
                return rnd.Next(1, 4);
            }
            else if (enemyQ[1] != 0)
            {
                enemyQ[1] -= 1;
                return rnd.Next(2, 4);
            }
            else
            {
                enemyQ[2] -= 1;
                return 3;
            }
        }
        private bool Combat(double playerMod, double enemyMod)
        {
            var temp = false;
            var playerVal = rnd.Next(1, GameLength+1) / (playerMod + .1);
            var enemyVal = rnd.Next(1, GameLength+1) / (enemyMod + .1);
            if (playerVal > enemyVal)
                temp = true;

            PlayerWins[count] = temp;
            count++;
            return temp;
        }
    }
}