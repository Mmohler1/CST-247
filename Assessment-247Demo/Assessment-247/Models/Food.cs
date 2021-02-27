using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_247.Models
{
    //Food class for orders
    public class Food
    {
        //Intialize values with getters and setters
        public string name { get; set; }
        public int calories { get; set; }
        public string ingredient1 { get; set; }
        public string ingredient2 { get; set; }

        //Constructor
        public Food(string name, int calories, string ingredient1, string ingredient2)
        {
            this.name = name;
            this.calories = calories;
            this.ingredient1 = ingredient1;
            this.ingredient2 = ingredient2;
        }

        public Food()
        {

        }
    }
}
