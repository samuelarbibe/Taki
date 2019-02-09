﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using BusinessLayer;
using System.Threading;

namespace Service
{
    public class Service : IService
    {
        private static MessageList _pendingChanges = new MessageList(); // pending messages for each player 

        public static MessageList PendingChanges { get => _pendingChanges; set => _pendingChanges = value; }

        public CardList BuildDeck()
        {
            Bl bl = new Bl();

            return bl.BlBuildDeck();
        }

        public CardList GetCardList()
        {
            return null;
        }

        public UserList GetAllUsers()
        {
            Bl bl = new Bl();
            return bl.BlGetAllUsers();
        }

        public User GetUserByUsername(string Username)
        {
            Bl bl = new Bl();
            return bl.BlGetUserByUsername(Username);
        }

        public User Login(string username, string password)
        {
            Bl bl = new Bl();
            return bl.BlLogin(username, password);
        }

        public bool Logout(int userId)
        {
            Bl bl = new Bl();
            return bl.BlLogout(userId);
        }

        public bool Register(string firstName, string lastName, string username, string password)
        {
            Bl bl = new Bl();
            return bl.BlRegister(firstName, lastName, username, password);
        }

        public int DeleteUser(User user)
        {
            Bl bl = new Bl();
            return bl.BlDeleteUser(user);
        }

        public int UpdateUser(User user)
        {
            Bl bl = new Bl();
            return bl.BlUpdateUser(user);
        }

        public bool PasswordAvailable(string password)
        {
            Bl bl = new Bl();
            return bl.BlPasswordAvailable(password);
        }

        public bool UsernameAvailable(string username)
        {
            Bl bl = new Bl();
            return bl.BlUsernameAvailable(username);
        }

        public GameList GetAllUserGames(int UserId)
        {
            Bl bl = new Bl();
            return bl.BlGetAllUserGames(UserId);
        }

        public Game StartGame(Player p, int playerCount)
        {
            Bl bl = new Bl();
            Game g = bl.BlStartGame(p, playerCount);

            return g;
        }

        public int GetPlayersFound(int playerCount)
        {
            Bl bl = new Bl();
            return bl.BlGetPlayersFound(playerCount);
        }

        public bool StopSearchingForGame(Player p)
        {
            Bl bl = new Bl();
            return bl.BlStopSearchingForGame(p);
        }

        public bool PlayerQuit(Player p)
        {
            Bl bl = new Bl();
            return bl.BlPlayerQuit(p);
        }

        public PlayerList GetPlayerList()
        {
            return null;
        }

        public void AddAction(Message m)
        {
            PendingChanges.Add(m);
        }

        public void AddActions(MessageList ml)
        {
            PendingChanges.AddRange(ml);
        }

        public int SaveChanges()
        {
            Bl bl = new Bl();
            return bl.SaveChanges();
        }

        public MessageList DoAction(int gameId, int playerId)
        {
            MessageList temp = new MessageList();

            if (PendingChanges == null || PendingChanges.Count == 0) return null;
            else
            {
                foreach (Message m in PendingChanges.ToList())
                {
                    if (m.GameId == gameId && m.Reciever == playerId)
                    {
                        temp.Add(m);
                        PendingChanges.Remove(m);

                        if (m.Reciever == m.Target.Id) // make sure this happens once for each message
                        {
                            switch (m.Action)
                            {
                                case Message._action.add:
                                    Bl bl = new Bl();
                                    bl.BlAddCard(m);
                                    break;

                                case Message._action.remove:
                                    bl = new Bl();
                                    bl.BlRemoveCard(m);
                                    break;

                                case Message._action.switch_hand:
                                    bl = new Bl();
                                    bl.BlSwitchHands(m);
                                    break;

                                case Message._action.win:
                                    bl = new Bl();
                                    bl.BlWin(m);
                                    break;

                                case Message._action.loss:
                                    bl = new Bl();
                                    bl.BlLoss(m);
                                    break;
                            }
                        }
                    }
                }
            }
            return temp;
        }

        
    }
}
