using System;
using System.Collections.Generic;

public class Game
{

    public List<Ship> ListShip { get; set; }
    public List<Board> ListBoard { get; set; }

    //I could have created a parameter to receive the number of players
    //and then create a FOR to feed the list of boards --EXPLICAR TACI
    public Game(int dimension)
    {
        Board board = new Board(dimension);
        this.ListBoard = new List<Board>();
        this.ListBoard.Add(board);
        InitShip();
        SetUpShipBoard(dimension);
    }

    public void printBoard()
    {
        foreach (Board board in ListBoard)
        {
            board.Print();
        }
    }

    private void InitShip()
    {
        List<Ship> lstShip = new List<Ship>();

        lstShip.Add(new Ship(EnumShip.Battleship));
        lstShip.Add(new Ship(EnumShip.Carrier));
        lstShip.Add(new Ship(EnumShip.Cruiser));
        lstShip.Add(new Ship(EnumShip.Destroyer));
        lstShip.Add(new Ship(EnumShip.Destroyer));
        lstShip.Add(new Ship(EnumShip.Submarine));
        lstShip.Add(new Ship(EnumShip.Submarine));

        ListShip = lstShip;
    }

    public string SetUpShipBoard(int dimension)
    {
        bool isReady;
        int orientation, startRow, startCol, endRow, endCol;
        string colLetter;
        string print_coord = "";
        Coordinate coord;

        foreach (Ship ship in ListShip)
        {
            ship.StateShip = 1; //ship active
            isReady = false;

            while (!isReady)
            {
                ship.ListCoordinate = new List<Coordinate>();
                startRow = Convert.ToInt32(General.GenerateRandomNum(dimension));
                startCol = Convert.ToInt32(General.GenerateRandomNum(dimension));

                //add first coordinate
                coord = new Coordinate();
                coord.Row = startRow;
                coord.Column = startCol;

                SetShipLetter(ship, coord);
                ship.ListCoordinate.Add(coord);

                endRow = startRow;
                endCol = startCol;

                colLetter = General.ConvertNumToStr(startCol, true);
                orientation = Convert.ToInt32(General.GenerateRandomNum(100)) % 2;

                //horizontal
                if (orientation == 0)
                {
                    for (int count = 1; count < (int)ship.EnumShip; count++)
                    {
                        //add others coordinates
                        endRow++;
                        coord = new Coordinate();
                        coord.Row = endRow;
                        coord.Column = startCol;

                        SetShipLetter(ship, coord);
                        ship.ListCoordinate.Add(coord);
                    }
                }
                else
                {
                    for (int count = 1; count < (int)ship.EnumShip; count++)
                    {
                        endCol++;
                        coord = new Coordinate();
                        coord.Row = startRow;
                        coord.Column = endCol;

                        SetShipLetter(ship, coord);
                        ship.ListCoordinate.Add(coord);
                    }
                }

                if (dimension < endRow || dimension < endCol)
                {
                    isReady = false;
                    continue;
                }

                if (isCoordAvailable(ship) == false)
                {
                    isReady = false;
                    continue;
                }

                isReady = true;
            }

            /*print_coord += ship.EnumShip.ToString() + " ";
            foreach (Coordinate item in ship.ListCoordinate)
            {
                print_coord += item.Row + "," + item.Column + " ";
            }*/

            foreach (Board board in ListBoard)
            {
                board.SetStatusCoord(ship);
            }

        }

        return print_coord;
    }

    private bool isCoordAvailable(Ship ship)
    {
        bool isAvailable = true;
        foreach (Board board in ListBoard)
        {
            foreach (Coordinate shipCoord in ship.ListCoordinate)
            {
                foreach (Coordinate boardCoord in board.ListCoordinate)
                {
                    if (shipCoord.Row == boardCoord.Row && shipCoord.Column == boardCoord.Column && boardCoord.State != EnumCoordinate.w)
                    {
                        isAvailable = false;
                        break;
                    }
                }
                if (isAvailable == false)
                {
                    break;
                }
            }
        }
        return isAvailable;
    }

    private void SetShipLetter(Ship ship, Coordinate coord)
    {
        if (ship.EnumShip == EnumShip.Battleship)
        {
            coord.State = EnumCoordinate.A;
        }
        else if (ship.EnumShip == EnumShip.Carrier)
        {
            coord.State = EnumCoordinate.B;
        }
        else if (ship.EnumShip == EnumShip.Cruiser)
        {
            coord.State = EnumCoordinate.C;
        }
        else if (ship.EnumShip == EnumShip.Destroyer)
        {
            coord.State = EnumCoordinate.D;
        }
        else
        {
            coord.State = EnumCoordinate.E;
        }
    }


    public string Attack(string row, string col)
    {

        int guessCol = General.ConvertStrToNumber(col);
        int guessRow = Convert.ToInt32(row);

        string result = "";

        foreach (Board board in ListBoard)
        {
            foreach (Coordinate coord in board.ListCoordinate)
            {
                if (guessRow == coord.Row && guessCol == coord.Column && coord.State != EnumCoordinate.w)
                {
                    if (coord.State != EnumCoordinate.H)
                    {
                        result = "Hit";
                        coord.State = EnumCoordinate.H;
                        break;
                    }
                    else
                    {
                        result = "Missed";
                    }
                }
                else
                {
                    result = "Missed";
                }

            }
        }

        foreach (Ship ship in ListShip)
        {
            foreach (Coordinate coord in ship.ListCoordinate)
            {
                if (guessRow == coord.Row && guessCol == coord.Column)
                {
                    coord.State = EnumCoordinate.H;
                }
            }
        }

        return result;

    }
    public bool isShipsKilled()
    {
        foreach (Ship ship in ListShip)
        {
            foreach (Coordinate coord in ship.ListCoordinate)
            {
                if (coord.State != EnumCoordinate.H)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool isDataValid(string row, string col)
    {
        bool result = true;

        foreach (Board board in ListBoard)
        {
            if (Convert.ToInt32(row) < 1 || Convert.ToInt32(row) > board.Dimension || General.ConvertStrToNumber(col) < 1 || General.ConvertStrToNumber(col) > board.Dimension) 
            {
                    result = false;
            }
            return result;
        }

        return result;
    }
}
