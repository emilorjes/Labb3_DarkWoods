﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Utility
{
    class ErrorHandling
    {
        //===================================================================================================================================================================================
        // Skriver ut ett rött felmeddelande
        //===================================================================================================================================================================================
        public static void ErrorMessage()
        {
            Tools.RedTextWr("Wrong input, try again...");
            Console.ReadLine();
        }





        //===================================================================================================================================================================================
        // Olika felhanteringmetoder beroende på hur många menyval dett finns i menyen
        //===================================================================================================================================================================================
        public static void FiveChoiceMenuHandling(string menuChoiceString)
        {
            if (!int.TryParse(menuChoiceString, out int menuChoiceInt) || menuChoiceInt < 1 || menuChoiceInt > 5)
            {
                ErrorMessage();
            }
        }
        //===================================================================================================================================================================================
        public static void FourChoiceMenuHandling(string menuChoiceString)
        {
            if (!int.TryParse(menuChoiceString, out int menuChoiceInt) || menuChoiceInt < 1 || menuChoiceInt > 4)
            {
                ErrorMessage();
            }
        }
        //===================================================================================================================================================================================
        public static void ThreeChoiceMenuHandling(string menuChoiceString)
        {
            if (!int.TryParse(menuChoiceString, out int menuChoiceInt) || menuChoiceInt < 1 || menuChoiceInt > 3)
            {
                ErrorMessage();
            }
        }
        //===================================================================================================================================================================================
        public static void TwoChoiceMenuHandling(string menuChoiceString)
        {
            if (!int.TryParse(menuChoiceString, out int menuChoiceInt) || menuChoiceInt < 1 || menuChoiceInt > 2)
            {
                ErrorMessage();
            }
        }
        //===================================================================================================================================================================================
    }
}
