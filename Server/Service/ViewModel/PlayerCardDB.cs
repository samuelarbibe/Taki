﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class PlayerCardDb : BaseDb
    {

        protected override BaseEntity NewEntity()
        {
            return new Connection();
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Connection con = entity as Connection;
            con.Id = (int)Reader["ID"];
            con.SideA = (int)Reader["player_id"];
            con.SideB = (int)Reader["card_id"];
            con.ConnectionType = "player-card";
            return con;
        }

        public override void Insert(BaseEntity entity)
        {
            Connection c = entity as Connection;
            if (c != null)
            {
                Inserted.Add(new ChangeEntity(this.CreateInsertSql, entity));
            }
        }

        public void InsertList(ConnectionList entity)
        {
            ConnectionList cl = entity;
            foreach (var connection in cl)
            {
                if (connection != null)
                {
                    Inserted.Add(new ChangeEntity(this.CreateInsertSql, connection));
                }
            }
        }

        public ConnectionList SelectByGameId(int cardId)
        {
            Command.CommandText = ("SELECT * FROM Player_Card_Table WHERE 'card_id'= @id");


            //parameters
            Command.Parameters.Add(new OleDbParameter("@id", cardId));


            ConnectionList conList = new ConnectionList(Select());
            return conList;
        }

        public ConnectionList SelectByPlayerId(int playerId)
        {
            Command.CommandText = ("SELECT * FROM Player_Card_Table WHERE 'player_id'= @id");


            //parameters
            Command.Parameters.Add(new OleDbParameter("@id", playerId));


            ConnectionList conList = new ConnectionList(Select());
            return conList;
        }

        public override void CreateInsertSql(BaseEntity entity, OleDbCommand command)
        {
            Connection con = entity as Connection;

            command.CommandText = ("INSERT INTO Player_Card_Table (player_id, card_id) VALUES (@player_id, @card_id)");

            //parameters

            command.Parameters.Add(new OleDbParameter("@player_id", con.SideA));
            command.Parameters.Add(new OleDbParameter("@card_id", con.SideB));

            Console.WriteLine("connection between player [" + con.SideA + "] and card [" + con.SideB + "] has been created and inserted");
        }

        public override void CreateDeleteSql(BaseEntity entity, OleDbCommand command)
        {
            Connection con = entity as Connection;

            command.CommandText = ("DELETE FROM Player_Card_Table WHERE player_id = @player_id AND card_id = @card_id");

            //parameters

            command.Parameters.Add(new OleDbParameter("@player_id", con.SideA));
            command.Parameters.Add(new OleDbParameter("@card_id", con.SideB));

            Console.WriteLine("connection between player [" + con.SideA + "] and card [" + con.SideB + "] has been deleted");
        }


        //BUG
        //cannot update the SET the WHERE parameters
        //solution: use insert and delete for every player-card connection(delete the old, insert updated)

        public override void CreateUpdateSql(BaseEntity entity, OleDbCommand command)
        {
            Connection con = entity as Connection;

            command.CommandText = ("UPDATE Player_Card_Table SET card_id = @card_id");

            //parameters

            command.Parameters.Add(new OleDbParameter("@player_id", con.SideA));
            command.Parameters.Add(new OleDbParameter("@card_id", con.SideB));

            Console.WriteLine("connection between player" + con.SideA + " and card" + con.SideB + " has been updated");
        }
    }
}

