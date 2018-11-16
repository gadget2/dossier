using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace dossier
{
    public partial class Manager : Form
    {
        private Player _player;       
        public Manager()
        {
            InitializeComponent();
            _player = new Player();
            _player.CurrentHP = 10;
            _player.MaxHP = 10;
            _player.Gold = 20;
            _player.Experience = 0;
            _player.Level = 1;
            labelHP.Text = _player.CurrentHP.ToString();
            labelGold.Text = _player.Gold.ToString();
            labelEXP.Text = _player.Experience.ToString();
            labelLevel.Text = _player.Level.ToString();
        }
    }
}
