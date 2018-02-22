using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;

        //when new game button is clicked, create a new instance of game class
        //enable name, ask, and disable start game button
        //redraw form
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
                return;
            }
            game = new Game(textName.Text, new List<string> { "Joe", "Bob" }, textProgress);
            buttonStart.Enabled = false;
            textName.Enabled = false;
            buttonAsk.Enabled = true;
            listHand.Enabled = true;
            UpdateForm();
        }

        //clear and repopulate the listbox that holds the players data
        private void UpdateForm()
        {
            listHand.Items.Clear();
            foreach (String cardName in game.GetPlayerCardNames())
            {
                listHand.Items.Add(cardName);
            }
            textBooks.Text = game.DescribeBooks();
            textProgress.Text += game.DescribePlayerHands();
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
        }

        //player select on of the cards and the button sees if any of the other players have the card
        //game class plays a round
        private void buttonAsk_Click(object sender, EventArgs e)
        {
            textProgress.Text = "";
            if (listHand.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a card");
                return;
            }

            if (game.PlayOneRound(listHand.SelectedIndex))
            {
                textProgress.Text += "The winner is..." + game.GetWinnerName();
                textBooks.Text = game.DescribeBooks();
                buttonAsk.Enabled = false;
                listHand.Enabled = false;
            }
            else
            {
                UpdateForm();
            }
        }
    }
}
