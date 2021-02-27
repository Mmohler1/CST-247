using Assessment_247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_247.Business
{
    public class Waiter
    {
        //Passes in food and reverses two strings 
        public Food newGuy(Food ticket)
        {
            //turn ingredients into arrays
            char[] ingred1 = ticket.ingredient1.ToCharArray();
            char[] ingred2 = ticket.ingredient2.ToCharArray();

            //mistake variables
            string mistake1="";
            string mistake2="";

            //for loop to reverse the string one at a time.
            int x = ingred1.Length;
            for(int y = 0; y < ingred1.Length; y++)
            {
                x--;
                mistake1 += ingred1[x];
                
            }

            //Now for the second one
            x = ingred2.Length;
            for (int y = 0; y < ingred2.Length; y++)
            {
                x--;
                mistake2 += ingred2[x];
                
            }


            //Make new Food model with new ingredients
            Food badTicket = ticket;
            badTicket.ingredient1 = mistake1;
            badTicket.ingredient2 = mistake2;



            return badTicket;


        }
    }
}
