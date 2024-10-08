using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsGroupAssignment
{
    public abstract class Digit
    {
        public Nail Nail { get; set; }

        public Digit(float desiredLength, float startLength)
        {
            Nail = new Nail(startLength, desiredLength);
        }
    }
}
