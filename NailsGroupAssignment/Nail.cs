using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsGroupAssignment
{
    public class Nail
    {
        public float Length { get; set; }
        public bool IsPainted { get; set; }
        public bool VitaminContent { get; set; }
        public float VitaminDefficiency { get; set; }
        public float GrowthRate { get; set; }
        public float DesiredLength { get; set; }
        public ConsoleColor color { get; set; }

        public Nail(float length, float desiredLength)
        {
            DesiredLength = desiredLength;
            Length = length;
        }
        public void Grow()
        {
            Length += 0.1f;
        }
    }
}

