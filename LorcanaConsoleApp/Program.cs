using LorcanaLogic;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ch = new CollectionHandler();
            //ch.LoadCollectionFile("C:\\Users\\Sam\\Downloads\\export.csv");

            var boxSim = new BoxPullSimulation(3,ch.Cards);
            boxSim.PullBox();

            
            ch.SaveCollectionFile();
        }
    }
}
