using System;

namespace SnapCrackle.Library
{
    /// <summary>
    /// Used to store the number and the word
    /// as event argument by extending EventArgs
    /// </summary>
    public class NumberFoundEventArg: EventArgs
    {
        public int Number { get; set; }

        public string Word { get; set; }

        public override string ToString()
        {
            return $"{Number} {Word}";
        }
    }
}