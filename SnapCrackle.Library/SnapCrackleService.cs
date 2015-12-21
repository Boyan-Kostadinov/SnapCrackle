using System;
using System.Linq;

namespace SnapCrackle.Library
{
    public class SnapCrackleService
    {
        /// <summary>
        /// Called every time a matching number is found
        /// </summary>
        public EventHandler OnNumberFound;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="configuration">An instance of the configuration</param>
        public SnapCrackleService(SnappleCrackleConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Safe wrapper for the OnNumberFound event
        /// </summary>
        /// <param name="e"></param>
        public void FoundNumber(EventArgs e)
        {
            OnNumberFound?.Invoke(this, e);
        }

        /// <summary>
        /// Runs through the configuration and finds any matching numbers
        /// </summary>
        public void Run()
        {
            // Aggregate all the numbers by multiplying them to get the common denominator
            var commonDenominator = _configuration.Denominators.Aggregate(1, (x, y) => x * y.Number);

            // Aggregate all the words for all the numbers, this will be our common denominator word
            var commonDenominatorWord = _configuration.Denominators.Aggregate(string.Empty, (x, y) => $"{x} {y.Word}".Trim());

            // Loop over the numbers from the starting number to the end number
            Enumerable.Range(_configuration.FromNumber, _configuration.ToNumber).ToList().ForEach(item =>
            {
                // Find a common denominator
                var commonDenominatorFound = _configuration.Denominators.FirstOrDefault(i => item % commonDenominator == 0);

                if (commonDenominatorFound != null)
                {
                    FoundNumber(new NumberFoundEventArg() { Number = item, Word = commonDenominatorWord });
                }
                else
                {
                    // Find a divisible denominator
                    var divisibleFound = _configuration.Denominators.FirstOrDefault(i => item % i.Number == 0);

                    FoundNumber(divisibleFound != null
                        ? new NumberFoundEventArg() {Number = item, Word = divisibleFound.Word}
                        : new NumberFoundEventArg() {Number = item});
                }
            });
        }

        private readonly SnappleCrackleConfiguration _configuration;
    }
}
