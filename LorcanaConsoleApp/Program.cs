using LorcanaLogic;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ch = new CollectionHandler();
            ch.LoadCollectionFile("C:\\Users\\Sam\\Downloads\\export(4).csv");

            var boxSim = new BoxPullSimulation(1,ch.Cards);

            var numboxes = 100000; 
            var values = new List<decimal>();
            for(var i = 0; i < numboxes; i++)
            {
                var (cards, foils) = boxSim.PullBox();
                var value = boxSim.CalcBoxValue(cards, foils);
                values.Add(value);
            }
            var avg = values.Average();
            decimal stDev = 0;

            foreach (var value in values)
            {
                var dev = value - avg;
                if (dev < 0)
                    dev *= -1; 
                stDev += dev;
            }
            stDev = stDev/ values.Count();
            ch.SaveCollectionFile();
        }
    }
}
