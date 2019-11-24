using System;
using System.Collections.Generic;


public class Board
{
    public string Identifier { get; set; }

    public int Dimension { get; set; }

    public List<Coordinate> ListCoordinate { get; set; }

    public Board(string identifier, int dimension)
    {
        this.Identifier = identifier;
        this.Dimension = dimension;
        this.ListCoordinate = new List<Coordinate>();
        Create();
    }

    public Board(int dimension)
    {
        this.Identifier = "Player 1";
        this.Dimension = dimension;
        this.ListCoordinate = new List<Coordinate>();
        Create();
    }


    public void Create()
    {
        for (int row = 1; row <= Dimension; row++)
        {
            for (int col = 1; col <= Dimension; col++)
            {
                ListCoordinate.Add(new Coordinate(row, col));

            }
        }

    }


    public void SetStatusCoord(Ship ship)
    {
        foreach (Coordinate shipCoord in ship.ListCoordinate)
        {
            foreach (Coordinate boardCoord in ListCoordinate)
            {
                if (shipCoord.Row == boardCoord.Row && shipCoord.Column == boardCoord.Column)
                {
                    if (boardCoord.State != EnumCoordinate.w)
                    {
                        boardCoord.State = shipCoord.State;
                    }
                    boardCoord.State = shipCoord.State;
                }
            }
        }
    }

    public void Print()
    {
        string currentRow = "";
        string header = "";

        foreach (Coordinate item in ListCoordinate)
        {
            currentRow += item.State + "    ";

            if (item.Row == 1)
            {
                header += General.ConvertNumToStr(item.Column, true) + "    ";
            }

            if (item.Column == Dimension)
            {
                if (header != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   " + header);
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(item.Row.ToString() + new System.String(' ', 3 - item.Row.ToString().Length));
                Console.ResetColor();

                Console.WriteLine(currentRow);

                currentRow = "";
                header = "";
            }
        }

    }

}