using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public partial class Form1 : Form
    {
        Greyhound[] greyhound = new Greyhound[4]; // Array of Greyhound
        Guy[] guy = new Guy[3]; // Array of guy (joe,Bob,Al)
        Random MyRandomizer = new Random(); //Only one Randomizer! if you creat more and don't set the seed,
                                            //the dogg move is the same for all the dog, because therandom generate the same value
        public Form1()
        {
            InitializeComponent();

            greyhound[0] = new Greyhound()
            {
                MyPictureBox = dog1, // i changed the name of picturebox1 to dog1!
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dog1.Width,
                Randomizer = MyRandomizer
            };

            greyhound[1] = new Greyhound()
            {
                MyPictureBox = dog2, // i changed the name of picturebox1 to dog1!
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dog2.Width,
                Randomizer = MyRandomizer
            };

            greyhound[2] = new Greyhound()
            {
                MyPictureBox = dog3, // i changed the name of picturebox1 to dog1!
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dog3.Width,
                Randomizer = MyRandomizer
            };

            greyhound[3] = new Greyhound()
            {
                MyPictureBox = dog4, // i changed the name of picturebox1 to dog1!
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dog4.Width,
                Randomizer = MyRandomizer
            };


            guy[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel };
            guy[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            guy[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetLabel };

            //Mininum Bet Label
            minimumBetLabel.Text = "Minimum bet: " + cashBet.Minimum + " bucks";

            refreshGuyState();
        }

       //I creat a new function to clear the bet at the startup or at the end of the race.
       public void refreshGuyState()
       {
           for (int i = 0; i < guy.Length; i++)
           {
               guy[i].ClearBet();
           }
       }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = guy[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = guy[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = guy[2].Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
                guy[0].PlaceBet((int)cashBet.Value, (int)dogBet.Value);
            if (bobRadioButton.Checked)
                guy[1].PlaceBet((int)cashBet.Value, (int)dogBet.Value);
            if (alRadioButton.Checked)
                guy[2].PlaceBet((int)cashBet.Value, (int)dogBet.Value);
        }
        //the timer call the Run() for every dog, when a dog arrive to the "ending line" the dog win.
        //so stopping the timer, show a message box with the winnner dog and check if some guy have won
        // at the end, enable the group for another race!
        //ps: the break iis only for exit from the loop, this is not important for the scope of the lab, but continue the looping after the winner can ganerate another winner
        // so for fixing the bug simple call break or return at the end of the block
        private void timer1_Tick(object sender, EventArgs e)
        {
            int winningDog = 0;

            for (int i = 0; i < greyhound.Length; i++)
            {
                if(greyhound[i].Run())
                {
                    //we have a winner!!
                    timer1.Stop();
                    winningDog = i + 1;
                    MessageBox.Show("Dog #" + winningDog + " Won the Race!");

                    for(int b = 0; b < guy.Length; b++)
                    {
                        guy[b].Collect(winningDog);
                    }

                    refreshGuyState();
                    bettingGroup.Enabled = true;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < greyhound.Length; c++)
            {
                greyhound[c].TakeStartingPosition();
            }

            bettingGroup.Enabled = false;
            timer1.Start();
        }
    }
}
