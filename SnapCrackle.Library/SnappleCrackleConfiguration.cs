using System.Collections.Generic;

namespace SnapCrackle.Library
{
    public class SnappleCrackleConfiguration
    {
        public int FromNumber { get; set; }

        public int ToNumber { get; set; }

        public List<Denominator> Denominators { get; set; }

        public SnappleCrackleConfiguration()
        {
            Denominators = new List<Denominator>();
        }
    }
}