using System;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string guessRow = "";
            string guessCol;

            //board board = new Board("RAFA", 10);

            Game game = new Game(10);


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------ WELCOME TO BATTLESHIP GAME, " + game.ListBoard[0].Identifier + "! ------------ ");
            Console.WriteLine();
            Console.WriteLine(" --- Type QX to quite anytime ---");
            Console.WriteLine();
            Console.WriteLine("Your board dimension is: " + game.ListBoard[0].Dimension);
            Console.ResetColor();
            Console.WriteLine();

            do
            {
                Console.Write("Enter a row number: " );
                guessRow = Console.ReadLine();
                Console.WriteLine();
                if (guessRow.ToUpper() == "QX")
                {
                    break;
                }

                Console.Write("Enter a column letter: ");
                guessCol = Console.ReadLine();
                Console.WriteLine();
                if (guessCol.ToUpper() == "QX")
                {
                    break;
                }

                Console.WriteLine();
                if (game.isDataValid(guessRow, guessCol)){
                    Console.WriteLine("Attack's result: " + game.Attack(guessRow, guessCol));
                }else{
                    Console.WriteLine("Please, insert a valid data");
                }
                

                //Console.WriteLine();
                //game.printBoard();
                Console.WriteLine();
            }
            while (game.isShipsKilled());

            if (guessRow.ToUpper() == "QX" || guessRow.ToUpper() == "QX")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Oh no! You lost the game");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Congratulations, you won!");
                Console.ResetColor();

            }

            //Console.WriteLine("Random: " + game.SetUpShipBoard(10));
            Console.WriteLine();

            //game.printBoard();
        }
    }
}
