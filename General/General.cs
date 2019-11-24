using System;


public static class General
{

    public static string ConvertNumToStr(int number, bool isCaps)
    {
        Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
        return c.ToString();
    }


    public static int ConvertStrToNumber(string letter)
    {
        char c = Convert.ToChar(letter);;
        return char.ToUpper(c) - 64;
    }


    public static string GenerateRandomNum(int number)
    {

        Random rnd = new Random();
        return rnd.Next(1, number).ToString();

    }

}

