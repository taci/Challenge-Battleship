using System.ComponentModel;



public enum EnumCoordinate
{
    [Description("Water")]
    w,
    [Description("Battleship")]
    A,
    
    [Description("Carrier")]
    B,
    
    [Description("Cruiser")]
    C,

    [Description("Destroyer")]
    D,

    [Description("Submarine")]
    E,

    [Description("Hit")]
    H
}