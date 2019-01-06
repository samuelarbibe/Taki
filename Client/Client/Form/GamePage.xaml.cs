﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;
using Form.TakiService;
using Form.Dialogs;


namespace Form
{
    /// <summary>
    /// Inter_action logic for GamePage.xaml
    /// </summary>
    public partial class GamePage
    {

        private bool _myTurn;
        private int _plusValue;
        private Card _openTaki;
        private Game _currentGame;
        private User _currentUser = MainWindow.CurrentUser;
        private Player _currentPlayer;
        private Player _table;
        private PlayerList _playersList = new PlayerList();
        private MessageList _localMessageList;
        private BackgroundWorker _backgroundProgress;
        private BackgroundWorker _saveChanges;
        private List<Card> _deck;

        private bool _active;
        private int _turn;
        private int _playersCount;
        private int _currentPlayerIndex;
        private bool _clockWiseRotation;

        public bool MyTurn { get => _myTurn;
            set {
                _myTurn = value;

                if (MyTurn)
                {
                    uctable.CanTakeCardFromDeck();
                }
                else uctable.CannotTakeCardFromDeck();
                }
        }
        public bool Active { get => _active; set => _active = value; }
        public int Turn { get => _turn; set => _turn = value; }
        public List<Card> Deck { get => _deck; set => _deck = value; }
        public bool ClockWiseRotation { get => _clockWiseRotation; set => _clockWiseRotation = value; }
        public MessageList LocalMessageList { get => _localMessageList; set => _localMessageList = value; }
        public BackgroundWorker BackgroundProgress { get => _backgroundProgress; set => _backgroundProgress = value; }
        public BackgroundWorker SaveChanges1 { get => _saveChanges; set => _saveChanges = value; }
        public int PlayersCount { get => _playersCount; set => _playersCount = value; }
        public int CurrentPlayerIndex { get => _currentPlayerIndex; set => _currentPlayerIndex = value; }

        private PlayerList PlayersList { get => _playersList; set => _playersList = value; }
        private Player Table { get => _table; set => _table = value; }
        private Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        private User CurrentUser { get => _currentUser; set => _currentUser = value; }
        private Game CurrentGame { get => _currentGame; set => _currentGame = value; }
        public Card OpenTaki { get => _openTaki; set => _openTaki = value; }
        public int PlusValue { get => _plusValue; set => _plusValue = value; }

        public GamePage(Game game)
        {
            InitializeComponent();

            MainWindow.CurrentGamePage = this;

            CurrentGame = game;

            SetBackgroundWorker();

            int firstPlayerUserId = CurrentGame.Players[0].UserId;

            ClockWiseRotation = true;
            uc1.SetAsNonActive();
            OpenTaki = null;
            MyTurn = false;
            Active = true;
            PlusValue = 0;

            ReorderPlayerList();

            //the first player is the one to request changes saving in the database every x seconds
            if (_currentUser.Id == firstPlayerUserId){

                InitialTurn();// broadcast that self is the first player in the game's players list

                SetSaveChanges();
            }

            uctable.TakeCardFromDeckButtonClicked += TakeCardFromDeck;

            uctable.PassCardToStackButtonClicked += PassCardToDeck;

            Deck = PlayersList[PlayersList.Count - 1].Hand.ToList();

            DataContext = PlayersList;

            uc1.SetCurrentPlayer(CurrentPlayer);

            switch (CurrentGame.Players.Count)
            {
                case 3:
                    uc2.Visibility = Visibility.Hidden;
                    uc3.SetCurrentPlayer(PlayersList[1]);
                    uc4.Visibility = Visibility.Hidden;
                    uctable.SetCurrentPlayer(Table);
                    break;
                case 4:
                    uc2.SetCurrentPlayer(PlayersList[1]);
                    uc3.SetCurrentPlayer(PlayersList[2]);
                    uc4.Visibility = Visibility.Hidden;
                    uctable.SetCurrentPlayer(Table);
                    break;
                case 5:
                    uc2.SetCurrentPlayer(PlayersList[1]);
                    uc3.SetCurrentPlayer(PlayersList[2]);
                    uc4.SetCurrentPlayer(PlayersList[3]);
                    uctable.SetCurrentPlayer(Table);
                    break;
            }

        }

        private void SetBackgroundWorker()
        {
            BackgroundProgress = new BackgroundWorker();
            BackgroundProgress.DoWork += FetchChanges;
            BackgroundProgress.RunWorkerCompleted += BackgroundProcess_RunWorkerCompleted;

            BackgroundProgress.RunWorkerAsync();
        }

        private void SetSaveChanges()
        {
            SaveChanges1 = new BackgroundWorker();
            SaveChanges1.DoWork += SaveChanges;
            SaveChanges1.WorkerSupportsCancellation = true;
            SaveChanges1.RunWorkerCompleted += SaveChanges_RunWorkerCompleted;

            SaveChanges1.RunWorkerAsync();
        }

        //save the changes in the database every 2 seconds
        private void SaveChanges(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);

            MainWindow.Service.SaveChanges();
        }


        private void SaveChanges_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Active) SaveChanges1.RunWorkerAsync();
        }


        private void FetchChanges(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(200);

            LocalMessageList = MainWindow.Service.DoAction(CurrentGame.Id, CurrentPlayer.Id);
        }


        private void BackgroundProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Active)
            {
                // Update local variables
                if (LocalMessageList != null && LocalMessageList.Count != 0)
                {
                    foreach (Message m in LocalMessageList)
                    {
                        switch (m.Action)
                        {
                            case Message._action.add:

                                PlayersList.Find(p => p.Id == m.Target).Hand.Add(m.Card);
                                break;

                            case Message._action.remove:

                                Player tempPlayer = PlayersList.Find(p => p.Id == m.Target); // the target player
                                Card tempCard = tempPlayer.Hand.Find(c => c.Id == m.Card.Id); // the target card
                                tempPlayer.Hand.Remove(tempCard); // remove the target card from the target player's hand

                                break;

                            case Message._action.win:

                                Player WinningPlayer = PlayersList.Find(p => p.Id == m.Target); // the winning player

                                if (CurrentPlayer.Id == m.Target)
                                {
                                    PlayerWin();
                                    PlayerQuit();
                                    MainWindow.BigFrame.Navigate(new MainMenu());
                                }
                                else 
                                {
                                    PlayerWin pw = new PlayerWin(WinningPlayer.Username);
                                    pw.ShowDialog();

                                    if (PlayersList.Count == 3)
                                    {
                                        PlayerLoss();

                                        MainWindow.Service.AddAction(new Message()
                                        {
                                            Action = Message._action.loss,
                                            Target = CurrentPlayer.Id,
                                            Reciever = CurrentPlayer.Id,
                                            GameId = CurrentGame.Id
                                        });
                                    }

                                }
                                MainWindow.Service.SaveChanges();


                                break;

                            case Message._action.switch_hand:

                                CardList l1 = PlayersList.Find(p => p.Id == m.Target).Hand;

                                PlayersList.Find(p => p.Id == m.Target).Hand = PlayersList.Find(p => p.Id == m.Card.Id).Hand;
                                PlayersList.Find(p => p.Id == m.Card.Id).Hand = l1;

                                break;

                            case Message._action.plus_two:

                                PlusValue = m.Card.Id;

                                if(CurrentPlayer.Id == m.Target && PlusValue != 0)
                                {
                                    if (CurrentPlayer.Hand.Find(c => c.VALUE == Card.Value.PlusTwo) == null)
                                    {
                                        TakeMultipleCardsFromDeck(PlusValue);
                                    }
                                }   

                                break;

                            case Message._action.next_turn:

                                Turn = PlayersList.FindIndex(p => p.Id == m.Target);
                                MyTurn =(m.Target == CurrentPlayer.Id);

                                Win();

                                DeclareTurn();

                                break;

                            case Message._action.switch_rotation:

                                if (ClockWiseRotation) ClockWiseRotation = false;
                                else ClockWiseRotation = true;

                                break;

                            case Message._action.player_quit:

                                int prevChangesSaverId = PlayersList[0].UserId;

                                Player quitter = PlayersList.Find(p => p.Id == m.Target);
                                PlayersList.Remove(quitter); // remove the quitting player from the local players list

                                PlayersList.TrimExcess();
                                CurrentGame.Players.TrimExcess();

                                if (CurrentUser.Id == PlayersList[0].UserId)
                                {
                                    InitialTurn(); // broadcast that self is the first player in the game's players list

                                    uc1.SetAsActive();

                                    // if the player isn't already the player in charge of saving changes
                                    if (CurrentUser.Id != prevChangesSaverId)
                                    {
                                        // pass the save changes functionality to the target player.
                                        SetSaveChanges();
                                    }
                                }
                                else
                                {
                                    MyTurn = false;
                                }

                                DeclareTurn();

                                break;
                        }
                    }

                    UpdateUI();
                }

                // Run again
                BackgroundProgress.RunWorkerAsync();   // This will make the BgWorker run again, and never runs before it is completed.
            }
        }

        public void PrintCards()
        {
            string cards = "\n \n --------------------------------------";
            foreach (Player p in PlayersList)
            {
                cards += "\n \n Player "+ p.Username +":";
                foreach (Card c in p.Hand)
                {
                    cards += "\n value:" + c.VALUE + ", color:" + c.COLOR;
                }
            }
            Console.Write(cards);
        }

        // this function re-arranges the player in a particular way, to make sure that:
        // - list[First] is the current player
        // - all the players after him are arranged in order
        // - list[Last] is the table
        private void ReorderPlayerList()
        {
            PlayersCount = CurrentGame.Players.Count;

            CurrentPlayerIndex = CurrentGame.Players.FindIndex(p => p.UserId == CurrentUser.Id);

            for (int i = 0; i < PlayersCount - 1; i++)
            {
                if (CurrentPlayerIndex >= PlayersCount - 1)
                {
                    PlayersList.Add(CurrentGame.Players[CurrentPlayerIndex % (PlayersCount - 1)]);
                }
                else
                {
                    PlayersList.Add(CurrentGame.Players[CurrentPlayerIndex]);
                }

                CurrentPlayerIndex++;
            }

            PlayersList.Add(CurrentGame.Players.Find(q => q.Username == "table"));

            CurrentPlayer = PlayersList[0];

            Table = PlayersList[PlayersCount - 1];
        }

        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            ExitDialog dialog = new ExitDialog
            {
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                PlayerQuit();
                MainWindow.BigFrame.Navigate(new MainMenu());
            }

        }

        private void UpdateUI()
        {
            uc1.UpdateUI(PlayersList[0]);

            switch (PlayersList.Count)
            {
                case 2:
                    uc2.Visibility = Visibility.Hidden;
                    uc3.Visibility = Visibility.Hidden;
                    uc4.Visibility = Visibility.Hidden;
                    uctable.UpdateUI(PlayersList[1]);

                    Dialogs.ForceQuit dialog = new Dialogs.ForceQuit
                    {
                        Owner = Application.Current.MainWindow
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        PlayerQuit();
                        MainWindow.BigFrame.Navigate(new MainMenu());
                    }

                    break;

                case 3:
                    uc2.Visibility = Visibility.Hidden;
                    uc3.UpdateUI(PlayersList[1]);
                    uc4.Visibility = Visibility.Hidden;
                    uctable.UpdateUI(PlayersList[2]);
                    break;
                case 4:
                    uc2.UpdateUI(PlayersList[1]);
                    uc3.UpdateUI(PlayersList[2]);
                    uc4.Visibility = Visibility.Hidden;
                    uctable.UpdateUI(PlayersList[3]);
                    break;
                case 5:
                    uc2.UpdateUI(PlayersList[1]);
                    uc3.UpdateUI(PlayersList[2]);
                    uc4.UpdateUI(PlayersList[3]);
                    uctable.UpdateUI(PlayersList[4]);
                    break;
            }
        }

        private void PassCardToDeck(object sender, EventArgs e)
        {
            Player currentPlayer = PlayersList.First();
            Player table = PlayersList.Last();
            MessageList temp = new MessageList();
            Card givenCard = uc1.SelectedCard();


            if(givenCard.VALUE == Card.Value.TakiAll || givenCard.VALUE == Card.Value.Taki)
            {
                if(givenCard.VALUE == Card.Value.TakiAll)
                {
                    givenCard = new Card() { VALUE = Card.Value.Taki, COLOR = table.Hand[table.Hand.Count - 1].COLOR }; // replace the multi-color taki with the correct colored taki
                }
                OpenTaki = givenCard;
            }

            if (givenCard != null && CheckPlay(givenCard, table.Hand[table.Hand.Count - 1]))
            {
                for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
                {
                    temp.Add(new Message()// add the top card of the table to the current player
                    {
                        Action = Message._action.add,
                        Target = table.Id, // the person who's hand is modified
                        Reciever = PlayersList[i].Id, // the peron who this message is for
                        Card = givenCard, // the card modified
                        GameId = CurrentGame.Id // the game modified
                    });

                    temp.Add(new Message()// add the top card of the table to the current player
                    {
                        Action = Message._action.remove,
                        Target = currentPlayer.Id, // the person who's hand is modified
                        Reciever = PlayersList[i].Id, // the peron who this message is for
                        Card = givenCard, // the card modified
                        GameId = CurrentGame.Id // the game modified
                    });
                }

                MainWindow.Service.AddActions(temp);

                Switch(givenCard.VALUE);
            }
        }

        private void RemoveCardFromDeck()
        {
            Player table = PlayersList.Last();
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {

                temp.Add(new Message()// add the top card of the table to the current player
                {
                    Action = Message._action.remove,
                    Target = table.Id, // the person who's hand is modified
                    Reciever = PlayersList[i].Id, // the peron who this message is for
                    Card = new Card() { Id = 67 },
                    GameId = CurrentGame.Id // the game modified
                });
            }

            MainWindow.Service.AddActions(temp);
        }


        private void TakeCardFromDeck(object sender, EventArgs e) 
        {
            if (PlusValue != 0)
            {
                TakeMultipleCardsFromDeck(PlusValue);
            }
            else
            {
                Player currentPlayer = PlayersList.First();
                MessageList temp = new MessageList();
                Card takenCard = uctable.GetCardFromStack(); // get a random card

                for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
                {
                    temp.Add(new Message()// add the top card of the table to the current player
                    {
                        Action = Message._action.add,
                        Target = currentPlayer.Id, // the person who's hand is modified
                        Reciever = PlayersList[i].Id, // the peron who this message is for
                        Card = takenCard, // the card modified
                        GameId = CurrentGame.Id // the game modified
                    });
                }

                MainWindow.Service.AddActions(temp);

                TurnFinished(Card.Value.Nine); // give turn to next player
            }
        }

        private void TakeMultipleCardsFromDeck(int num)
        {
            Player currentPlayer = PlayersList.First();
            MessageList temp = new MessageList();

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < PlayersList.Count - 1; j++) //add for each player, not including the table
                {
                    temp.Add(new Message()// add the top card of the table to the current player
                    {
                        Action = Message._action.add,
                        Target = currentPlayer.Id, // the person who's hand is modified
                        Reciever = PlayersList[j].Id, // the peron who this message is for
                        Card = uctable.GetCardFromStack(), // the card modified
                        GameId = CurrentGame.Id // the game modified
                    });
                }
            }

            MainWindow.Service.AddActions(temp);

            PlusTwoMessage(0);

            TurnFinished(Card.Value.Nine); // give turn to next player
        }

        private int GetUserControlOfPlayer(int playerIndex)
        {
            if (uc1.CurrentPlayer != null && uc1.CurrentPlayer.Id == PlayersList[playerIndex].Id) return 1;
            if (uc2.CurrentPlayer != null && uc2.CurrentPlayer.Id == PlayersList[playerIndex].Id) return 2;
            if (uc3.CurrentPlayer != null && uc3.CurrentPlayer.Id == PlayersList[playerIndex].Id) return 3;
            return 4;
        }

        private void DeclareTurn() // declare the player with the turn as active
        {
            switch (GetUserControlOfPlayer(Turn))
            {
                case 1:

                    uc1.SetAsActive();
                    uc2.SetAsNonActive();
                    uc3.SetAsNonActive();
                    uc4.SetAsNonActive();
                    break;

                case 2:

                    uc1.SetAsNonActive();
                    uc2.SetAsActive();
                    uc3.SetAsNonActive();
                    uc4.SetAsNonActive();
                    break;

                case 3:

                    uc1.SetAsNonActive();
                    uc2.SetAsNonActive();
                    uc3.SetAsActive();
                    uc4.SetAsNonActive();
                    break;

                case 4:

                    uc1.SetAsNonActive();
                    uc2.SetAsNonActive();
                    uc3.SetAsNonActive();
                    uc4.SetAsActive();
                    break;

            }
        }


        public void TurnFinished(Card.Value value)
        {
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.next_turn, // give next turn to
                    Target = GetNextPlayerId(value),
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id
                });
            }

            MainWindow.Service.AddActions(temp);

            MyTurn = false;
        }

        private void InitialTurn()
        {
            uc1.SetAsActive();

            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.next_turn, // give next turn to self
                    Target = CurrentPlayer.Id,
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id
                });
            }

            MainWindow.Service.AddActions(temp);

            MyTurn = true;
        }

        public void PlayerQuit()
        {
            Console.WriteLine("Player"+ CurrentPlayer.Username +" removed from the game in the gameList: " + MainWindow.Service.PlayerQuit(CurrentPlayer));

            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.player_quit,
                    Target = CurrentPlayer.Id,
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id
                });
            }

            MainWindow.Service.AddActions(temp);

            if (MyTurn) TurnFinished(Card.Value.Nine);
            Active = false;
        }


        private bool CheckPlay(Card given, Card table)
        {

            if(PlusValue != 0)
            {
                if (given.VALUE == table.VALUE) return true;
            }

            // not multi-color
            if (given.COLOR == Card.Color.multi) return true;

            if (given.COLOR == table.COLOR || given.VALUE == table.VALUE) return true;

            return false;

        }

        private void Switch(Card.Value value)
        {
            if (OpenTaki != null)
            {
                int colorCount = CurrentPlayer.Hand.FindAll(c => c.COLOR == OpenTaki.COLOR).Count;

                if (colorCount == 0)
                {
                    OpenTaki = null;
                    TurnFinished(Card.Value.Nine);
                }
                else
                {
                    if (colorCount == 1) // if one playing options is left in open taki
                    {
                        OpenTaki = null;
                    }

                    TurnFinished(Card.Value.Plus);
                }
            }
            else
            {
                switch (value)
                {
                    case Card.Value.SwitchColor:
                    case Card.Value.SwitchColorAll:

                        SwitchColor dialog = new SwitchColor
                        {
                            Owner = Application.Current.MainWindow
                        };

                        dialog.ShowDialog();

                        SwitchColorMessage(dialog.SelectedColor);

                        break;

                    case Card.Value.PlusTwo:

                        PlusTwoMessage(PlusValue + 2);

                        break;

                    case Card.Value.SwitchDirection:

                        ChangeRotationMessage();

                        break;

                    case Card.Value.SwitchHandAll:

                        SwitchHandsMessage(CurrentPlayer.Id, GetNextPlayerId(Card.Value.Nine));

                        RemoveCardFromDeck();

                        break;
                }

                TurnFinished(value); // GetNextPlayerId will handle this 
            }
            
        }

        private void SwitchHandsMessage(int currentPlayerId, int playerId)
        {
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.switch_hand,
                    Target = currentPlayerId,
                    Card = new Card() {Id = playerId}, // pass the other Player's ID through the card field.
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id
                });
            }


            MainWindow.Service.AddActions(temp);
        }

        private void SwitchColorMessage(Card selectedColorCard)
        {
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.add,
                    Target = Table.Id,
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id,
                    Card = selectedColorCard
                });
            }


            MainWindow.Service.AddActions(temp);
        }

        private void PlusTwoMessage(int num)
        {
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.plus_two,
                    Target = GetNextPlayerId(Card.Value.Nine), // get the next player
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id,
                    Card = new Card() { Id = num }// the card's id represents the PlusValue Build-up
                });
            }

            MainWindow.Service.AddActions(temp);
        }

        private void ChangeRotationMessage()
        {
            MessageList temp = new MessageList();

            for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
            {
                temp.Add(new Message()
                {
                    Action = Message._action.switch_rotation,
                    Target = CurrentPlayer.Id,
                    Reciever = PlayersList[i].Id,
                    GameId = CurrentGame.Id
                });
            }


            MainWindow.Service.AddActions(temp);
        }
        

        private int GetNextPlayerId(Card.Value value)
        {
            // special card switch - case
            switch (value)
            {
                case Card.Value.Stop:
                    if (PlayersList.Count > 3)
                    {
                        if(ClockWiseRotation) return PlayersList[PlayersList.Count - 3].Id;
                        return PlayersList[2].Id;
                    }
                    return CurrentPlayer.Id;

                case Card.Value.Plus:
                case Card.Value.Taki:
                case Card.Value.TakiAll:
                    return CurrentPlayer.Id;

                case Card.Value.SwitchDirection:
                {
                    if (!ClockWiseRotation) return PlayersList[PlayersList.Count - 2].Id;
                    return PlayersList[1].Id;
                }

            }

            if(ClockWiseRotation) return PlayersList[PlayersList.Count - 2].Id;
            return PlayersList[1].Id;

        }

        private void Win()
        {
            if(CurrentPlayer.Hand.Count == 0)
            {
                MessageList temp = new MessageList();

                for (int i = 0; i < (PlayersList.Count - 1); i++) //add for each player, not including the table
                {
                    temp.Add(new Message()
                    {
                        Action = Message._action.win,
                        Target = CurrentPlayer.Id,
                        Reciever = PlayersList[i].Id,
                        GameId = CurrentGame.Id
                    });
                }
                MainWindow.Service.AddActions(temp);
            }
        }

        private void PlayerWin()
        {
            CurrentUser.Score += 1000;
            CurrentUser.Wins += 1;
        }

        private void PlayerLoss()
        {
            CurrentUser.Score += 200;
            CurrentUser.Losses += 1;
        }
    }
}
