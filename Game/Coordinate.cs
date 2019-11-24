using System;

public class Coordinate
{
    public int Row { get; set; }

    public int Column { get; set; }

    public EnumCoordinate State { get; set; }

    public Coordinate()
    {
        this.State = EnumCoordinate.w;

    }

    public Coordinate(int row, int column)
    {
        this.Row = row;
        this.Column = column;
        this.State = EnumCoordinate.w;
    }

}
