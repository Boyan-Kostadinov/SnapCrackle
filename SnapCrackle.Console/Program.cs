using SnapCrackle.Library;

namespace SnapCrackle.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the configuration
            var config = new SnappleCrackleConfiguration
            {
                FromNumber = 1,
                ToNumber = 100
            };

            // Add some numbers to look for and their corresponding text
            config.Denominators.Add(new Denominator() {Number = 2, Word = "Snap!"});
            config.Denominators.Add(new Denominator() {Number = 3, Word = "Crackle!"});
            config.Denominators.Add(new Denominator() {Number = 5, Word = "Dog!"});
            config.Denominators.Add(new Denominator() { Number = 7, Word = "Cat!" });

            // Create the service with the configuration
            var service = new SnapCrackleService(config);

            // Tie the OnNumberFound event to print to the console
            service.OnNumberFound += (sender, eventArgs) => System.Console.WriteLine("{0}", eventArgs);

            service.Run();

            System.Console.ReadLine();
        }
    }
}