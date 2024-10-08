using System;
using System.Globalization;
using System.Reflection;

namespace NailsGroupAssignment
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Simulator nailClipperSimulator = new Simulator();
            Menu menu = new Menu();

            nailClipperSimulator.Run(menu.ChooseNumberDays());

        }

    }
}