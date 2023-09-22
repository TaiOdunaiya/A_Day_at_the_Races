using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Bet
    {
        public int Amount; // the amount of cash that was bet
        public int Dog; // The number on the dog with the bet is in
        public Guy Bettor; // the guy who placed the bet

        // return a string that says who placed  the bet, how much
        // cas was bet, and which dogg he bet on ("Joe bets 8 on
        //dogg #4"). If the amount is zero, no bet was placed 
        // ("joe hasn't placed a bet").
        public string GetDescription()
        {
           if(Amount > 0)
            {
                return Bettor.Name + " bets " + Amount + " bucks on dog # " + Dog;
            }
           else
            {
                return Bettor.Name + " has not placed any bets ";
            }
        }

        // The parameter is the minner of the race. If the dog won,
        // return the amount bet. Otherwise, return the negative of 
        // the amount bet.
        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }

   
        
}
