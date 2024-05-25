using LorcanaLogic;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ch = new CollectionHandler();
            ch.LoadCollectionFile("C:\\Users\\Sam\\Downloads\\export(4).csv");

            var boxSim = new BoxPullSimulation(4,ch.Cards);

            var ( avg, stdev) = boxSim.PullBoxes(100000);
            ch.SaveCollectionFile();
        }
    }
}
