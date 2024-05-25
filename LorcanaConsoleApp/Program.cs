using LorcanaLogic;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ch = new CollectionHandler();
            ch.LoadCollectionFile("C:\\Users\\Sam\\Downloads\\export(4).csv");

            for (var i = 1; i <= 4; i++)
            {
                var boxSim = new BoxPullSimulation(i, ch.Cards);
                var (avg, stdev, values) = boxSim.PullBoxes(100000);
                var ressult =
                    $"Set {i}:\n" +
                    $"\tAvg: ${avg}\n" +
                    $"\tStDev: ${stdev}";
                Console.WriteLine(ressult);
            }

            ch.SaveCollectionFile();
        }
    }
}