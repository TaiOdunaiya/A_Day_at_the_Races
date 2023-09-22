using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet; // An instance of Bet that has his bet
        public int Cash; // How mch cash he has
        //The last two feilds are the guy's GUI controls on the form
        public RadioButton MyRadioButton; // My RadioButton
        public Label MyLabel; // My Label

        

        // Set my label to my bet's description, and the label on my 
        // radio button to show my cash ("joe has 43 bucks"
        public void UpdateLables()
        {
            if (MyBet == null)
            {
                MyLabel.Text = string.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = Name + " has " + Cash + " bucks";
            //MyRadioButton.Text = Name + " has " + Cash + " Bucks ";
            //MyLabel.Text = MyBet.GetDescription();
        }
        //Reset my bet so it's zero
        public void ClearBet()
        {
            PlaceBet(0, 0);
        }
        //place a new bet and store it in my bet feild
        // Return true id the guy had enough money to bet
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLables();
                return true;
            }
            else
            {
                return false;
            }
        }
        // Ask my bet to pay out, clear my bet and update my labels
        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLables();
        }
    }
    
}
