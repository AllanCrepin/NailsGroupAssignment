using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsGroupAssignment
{
    public class NailPainter
    {
        public ConsoleColor Color { get; set; }
        public NailPainter()
        {
            Color = GetRandomConsoleColor();
        }

        private ConsoleColor GetRandomConsoleColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            var validColors = new List<ConsoleColor>();

            // Filter out ConsoleColor.Black, because it doesn't show well in the console
            foreach (ConsoleColor color in colors)
            {
                if (color != ConsoleColor.Black)
                {
                    validColors.Add(color);
                }
            }

            Random random = new Random();
            int index = random.Next(validColors.Count);

            return validColors[index];
        }

        public void Paint(Nail nail)
        {
            nail.IsPainted = true;
            nail.color = Color;

        }

        public void PaintAll(List<Finger> fingers, List<Toe> toes)
        {

            foreach (Finger finger in fingers)
            {
                Paint(finger.Nail);
            }
            foreach (Toe toe in toes)
            {
                Paint(toe.Nail);
            }

        }

        public void MulticolorPaintAll(List<Finger> fingers, List<Toe> toes)
        {

            foreach (Finger finger in fingers)
            {
                MulticolorPaint(finger.Nail);
            }
            foreach (Toe toe in toes)
            {
                MulticolorPaint(toe.Nail);
            }

        }


        public void MulticolorPaint(Nail nail)
        {
            nail.IsPainted = true;
            nail.color = GetRandomConsoleColor();
        }
    }
}
