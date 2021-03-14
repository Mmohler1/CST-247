using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{



    public class MinesweeperController : Controller
    {
        FieldService board = new FieldService();
        private int rows, cols;
        bool win = false;
        public string user;

        //static Space[,] buttons;
        static List<Space> buttons = new List<Space>();

        public IActionResult Index()
        {


            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    buttons.Add(new Space(X, Y));
                }
            }

            board.MakeMines(buttons);
            board.mineCheck(buttons);

            return View("Index", buttons);
        }

        //To be used with ajax and javascript to refreash the page without reloading it. 
        public IActionResult _ViewMinesweeperPartial(string squareNumber)
        {
            int bttnInt = int.Parse(squareNumber);

            //If a mine is there show all the spaces and print lose text.
            if (buttons.ElementAt(bttnInt).CurrentlyOccupied == true)
            {
                buttons.ElementAt(bttnInt).visited = true;
                for (int i = 0; i < 100; i++)
                {
                    buttons.ElementAt(i).visited = true;
                }
                ViewBag.theResult = "You lose";
                return PartialView(buttons);
            }
            //If a bomb is not clicked, set the button to visited and run through the functions within the FieldService
            else
            {
                board.floodFill(buttons.ElementAt(bttnInt).row, buttons.ElementAt(bttnInt).col, buttons);
                buttons.ElementAt(bttnInt).visited = true;
                
                //Iterate through the whole list to determine if a win condition has been met
                for (int i = 0; i < 100; i++)
                {
                    win = false;
                    //If all spaces have been either visted or occupied by a bomb, you have won
                    if (buttons.ElementAt(i).visited == true || buttons.ElementAt(i).CurrentlyOccupied == true)
                    {
                        win = true;
                    }
                    //exception handling so that the last button being visited doesn't produce a win con
                    else
                    {
                        break;
                    }
                }
            }

            if (win == true)
            {
                ViewBag.theResult = "You Win!";
                return PartialView(buttons);
            }
            else
            {
                ViewBag.theResult = "Start";
                return PartialView(buttons);
            }
        }



        //Adds or removes square's image to flag with javascript
        public IActionResult RightClickFlag(string squareNumber)
        {
            int bttnInt = int.Parse(squareNumber);

            //Checks if the space has already been selected. If not don't put flag, if so then continue.
            if (buttons.ElementAt(bttnInt).visited == false)
            {
                //If a flag isn't there place when, if it is then don't place one.
                if (buttons.ElementAt(bttnInt).flag == false)
                {
                    buttons.ElementAt(bttnInt).flag = true;
                    return PartialView(buttons);
                }
                else
                {
                    buttons.ElementAt(bttnInt).flag = false;
                    return PartialView(buttons);
                }

            }
            else
            {

                return PartialView(buttons);
            }

        }


    }

}
