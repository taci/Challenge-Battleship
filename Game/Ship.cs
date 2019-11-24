using System;
using System.Collections.Generic;


public class Ship
{

    public EnumShip EnumShip { get; set; }

    public List<Coordinate> ListCoordinate {get; set;}

    public byte StateShip {get; set;}

    public Ship(){
        this.ListCoordinate = new List<Coordinate>();
    }

    public Ship(EnumShip shipType){
        this.EnumShip = shipType;
        this.ListCoordinate = new List<Coordinate>();
    }

    public Ship(EnumShip shipType, List<Coordinate> lstCoord, byte stateShip)
    {
        this.EnumShip = shipType;
        this.ListCoordinate = lstCoord;
        this.StateShip = stateShip;
    }

}