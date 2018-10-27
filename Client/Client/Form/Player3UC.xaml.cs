﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Form.TakiService;

namespace Form
{
    /// <summary>
    /// Interaction logic for Player3UC.xaml
    /// </summary>
    public partial class Player3UC : UserControl
    {
        private Player _currentPlayer;
        private CardList _hand;

        public Player3UC()
        {
            InitializeComponent();
        }

        public void SetCurrentPlayer(Player currentPlayer)
        {
            _currentPlayer = currentPlayer;

            _hand = currentPlayer.Hand;

            DataContext = _currentPlayer;
        }
    }
}
