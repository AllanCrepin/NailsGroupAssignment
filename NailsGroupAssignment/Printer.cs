using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NailsGroupAssignment
{
    public class Printer
    {
        public Printer() { }

        public void ClipNailsDecidedPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Our nails have become too long. Today, we decide to cut our nails.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintDay(int day)
        {
            Console.WriteLine();
            Console.WriteLine($"Day number {day}:");
        }
        public void PrintNailInfo(List<Toe> toes, List<Finger> fingers, float desiredLength)
        {
            foreach (Finger finger in fingers)
            {
                if (finger.Nail.Length >= desiredLength + 2) { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write($"Finger {finger.TypeOfFinger}'s nail has reached " + finger.Nail.Length.ToString("F1") + "mm");
                PrintNailColor(finger);
                Console.ForegroundColor = ConsoleColor.White;
            }
            foreach (Toe toe in toes)
            {
                if (toe.Nail.Length >= desiredLength + 2) { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write($"Toe {toe.TypeOfToe}' nail has reached " + toe.Nail.Length.ToString("F1") + "mm");
                PrintNailColor(toe);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void PrintNailColor(Digit digit)
        {
            if(digit.Nail.color != null)
            {
                Console.ForegroundColor = digit.Nail.color;
                Console.WriteLine($" And its nail is colored: {digit.Nail.color}");
            }
        }
    }
}
