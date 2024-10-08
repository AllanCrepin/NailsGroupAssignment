using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NailsGroupAssignment
{
    public class Simulator
    {
        public float DesiredLength { get; set; } = 2.0f;
        public List<Finger> Fingers { get; set; }
        public List<Toe> Toes { get; set; }
        NailClipper NailClipper { get; set; }
        NailPainter NailPainter { get; set; }

        public Simulator()
        {
            NailPainter = new NailPainter();
            NailClipper = new NailClipper(2);
            Fingers = new List<Finger>();
            Toes = new List<Toe>();

            PopulateData(DesiredLength, 3.5f);
        }

        public void Run(int numberOfDays)
        {
            Printer printer = new Printer();
            List<Digit> digits = new List<Digit>();

            digits.AddRange(Fingers);
            digits.AddRange(Toes);

            for (int i = 0; i < numberOfDays; i++) //how many days -> repeat
            {
                printer.PrintDay(i);

                foreach (Digit digit in digits) //grow nails every day
                {

                    digit.Nail.Grow();
                }

                if (CheckIfShouldClip(Fingers, Toes, DesiredLength)) //check if to cut -> cut
                {
                    printer.ClipNailsDecidedPrint();
                    NailClipper.ClipAll(Fingers, Toes, DesiredLength);
                }

                if(DecideIfShouldPaint(Fingers, Toes))
                {
                    if (DecideIfSpecialDay())
                    {
                        NailPainter.MulticolorPaintAll(Fingers, Toes);
                    }
                    else
                    {
                        NailPainter.PaintAll(Fingers, Toes);
                    }
                }

                printer.PrintNailInfo(Toes, Fingers, DesiredLength); //print out all of the nail-info
            }
        }

        public void PopulateData(float desiredLength, float startLength)
        {

            foreach (TypeOfFinger fingerType in Enum.GetValues(typeof(TypeOfFinger)))
            {
                Fingers.Add(new Finger(fingerType, desiredLength, startLength));
                Fingers.Add(new Finger(fingerType, desiredLength, startLength));
            }

            foreach (TypeOfToe toeType in Enum.GetValues(typeof(TypeOfToe)))
            {
                Toes.Add(new Toe(toeType, desiredLength, startLength));
                Toes.Add(new Toe(toeType, desiredLength, startLength));
            }

        }

        public bool CheckIfShouldClip(List<Finger> fingers, List<Toe> toes, float DesiredLength)
        {
            float allAddedLength = 0; //create a sum.Length
            foreach (Finger finger in fingers)
            {
                allAddedLength += finger.Nail.Length;
            }
            foreach (Toe toe in toes)
            {
                allAddedLength += toe.Nail.Length;
            }
            //create an average-value of length
            float averageLength = allAddedLength / (fingers.Count + toes.Count);

            if (averageLength <= DesiredLength + 2) //if it's smaller than desired, return false (don't clip)
            {
                return false;
            }
            return true;
        }

        public bool DecideIfShouldPaint(List<Finger> fingers, List<Toe> toes)
        {
            Random random = new Random();

            if (random.Next(0,5) == 3 && !fingers[1].Nail.IsPainted)
            {
                return true;
            }

            return false;
        }

        public bool DecideIfSpecialDay()
        {
            Random random = new Random();
            int specialDay = random.Next(0, 4);
            if (specialDay == 2) { return true; }
            return false;
        }
    }
}
