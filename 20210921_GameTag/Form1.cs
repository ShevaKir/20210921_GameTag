using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210921_GameTag
{
    partial class Form1 : Form
    {
        private const int SHIFT = 50;
        private GameField _game;
        private int _countButton = 0;
        private Button[,] _buttons;

        public Form1(GameField game)
        {
            _buttons = new Button[game.Size, game.Size];
            _game = game;

            for (int i = 0; i < _game.Size; i++)
            {
                for (int j = 0; j < _game.Size; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * SHIFT, i * SHIFT);
                    button.Name = string.Format("{0}", _game[i, j].NumberCell);
                    button.Size = new Size(50, 50);
                    button.TabIndex = _countButton;
                    button.Text = string.Format("{0}", _game[i, j].NumberCell);
                    button.UseVisualStyleBackColor = true;
                    button.Click += new EventHandler(btn_Click);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = FlatStyle.Flat;
                    this.Controls.Add(button);
                    _buttons[i, j] = button;
                }
            }

            _game.Shuffle();
            ShowButton();
            InitializeComponent();
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Text != "0")
                {
                    for (int i = 0; i < _game.Size; i++)
                    {
                        for (int j = 0; j < _game.Size; j++)
                        {
                            if(_game[i, j].NumberCell == int.Parse(button.Text))
                            {
                                _game.Action(i, j);
                                ShowButton();
                                break;
                            }
                        }
                    }
                }
            }

            if (_game.IsWin())
            {
                MessageBox.Show("WIN");
            }
        }

        private void ShowButton()
        {
            for (int i = 0; i < _game.Size; i++)
            {
                for (int j = 0; j < _game.Size; j++)
                {
                    _buttons[i, j].Text = string.Format("{0}", _game[i, j].NumberCell);
                }
            }
        }


    }
}
