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
                    button.Name = string.Format("btn{0}", _countButton);
                    button.Size = new Size(50, 50);
                    button.TabIndex = _countButton;
                    button.Text = string.Format("{0}", _game[i, j].NumberCell);
                    button.UseVisualStyleBackColor = true;
                    button.Click += new System.EventHandler(this.btn_Click);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = FlatStyle.Flat;
                    this.Controls.Add(button);
                    _buttons[i, j] = button;
                }
            }

            _game.action(0,1);
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
                                _game.action(i, j);
                                ShowButton();
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


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
