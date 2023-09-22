using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Greyhound
    {
        public int StartingPosition; // Where my PictureBox starts
        public int RacetrackLength; // How long the racetrack is
        public PictureBox MyPictureBox = null; // My pictureBox Object 
        public int Location = 0; // My location on the racetrack
        public Random Randomizer; // an instance of random

        // Move foward either 1, 2, 3, or 4 spaces at random
        // Upddate the posision of my PictureBox on the form like this:
        //          MyPictureBox.Left = StartingPosision + Locaton:
        // Return true if i won the race

        public bool Run()
        {
            Location += Randomizer.Next(4); // change the value to speed up the race!
            MyPictureBox.Left = StartingPosition + Location;
            MyPictureBox.Refresh();

            if (MyPictureBox.Left >= RacetrackLength - MyPictureBox.Width + 20)
                return true;
            else
                return false;
        }

        // Reset my location to 0 and my pictureBox to starting position
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }

    }
    
}
